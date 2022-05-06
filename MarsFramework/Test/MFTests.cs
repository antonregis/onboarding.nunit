using NUnit.Framework;
using MarsFramework.Global;
using MarsFramework.Pages;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using System;
using static MarsFramework.Global.GlobalDefinitions;


namespace MarsFramework
{
    [TestFixture]
    class MFTests : Base
    {        
        [OneTimeSetUp]
        public void StartExtentReports()
        {
            // Initialize ExtentReports
            var htmlReporter = new ExtentHtmlReporter(ReportPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }


        [Test]
        public void T01_EnterShareSkill()
        {
            // Create Extentreport test, name extracted from current method name
            test = extent.CreateTest(System.Reflection.MethodBase.GetCurrentMethod().Name);

            try
            {
                // Action
                ShareSkill shareSkillObj = new ShareSkill();
                ManageListings manageListingsObj = new ManageListings();
                shareSkillObj.EnterShareSkill();

                // Assertion
                string enteredCategory = manageListingsObj.GetCategory();
                string enteredTitle = manageListingsObj.GetTitle();
                string expectedCategory = ExcelLib.ReadData(2, "Category");
                string expectedTitle = ExcelLib.ReadData(2, "Title");
                Assert.That(enteredCategory, Is.EqualTo(expectedCategory));
                Assert.That(enteredTitle, Is.EqualTo(expectedTitle));

                // Log status in Extentreports
                test.Log(Status.Pass, "Passed, action successfull.");
            }
            catch (Exception ex)
            {
                // Log status in Extentreports
                test.Log(Status.Fail, "Failed, action unsuccessfull.");
                test.Log(Status.Info, ex.Message);
            }
        }


        [Test]
        public void T02_EditShareSkill()
        {
            // Create Extentreport test, name extracted from current method name
            test = extent.CreateTest(System.Reflection.MethodBase.GetCurrentMethod().Name);

            try
            {
                // Action
                ShareSkill shareSkillObj = new ShareSkill();
                ManageListings manageListingsObj = new ManageListings();
                shareSkillObj.EditShareSkill();

                // Assertion
                string enteredCategory = manageListingsObj.GetCategory();
                string enteredTitle = manageListingsObj.GetTitle();
                string enteredDescription = manageListingsObj.GetDescription();
                string expectedCategory = ExcelLib.ReadData(3, "Category");
                string expectedTitle = ExcelLib.ReadData(3, "Title");
                string expectedDescription = ExcelLib.ReadData(3, "Description").Substring(0, 30);
                Assert.That(enteredCategory, Is.EqualTo(expectedCategory));
                Assert.That(enteredTitle, Is.EqualTo(expectedTitle));
                Assert.That(enteredDescription.Contains(expectedDescription));

                // Log status in Extentreports
                test.Log(Status.Pass, "Passed, action successfull");
            }
            catch (Exception ex)
            {
                // Log status in Extentreports
                test.Log(Status.Fail, "Failed, action unsuccessfull");
                test.Log(Status.Info, ex.Message);
            }
        }


        [Test]
        public void T03_DeleteShareSkill()
        {
            // Create Extentreport test, name extracted from current method name
            test = extent.CreateTest(System.Reflection.MethodBase.GetCurrentMethod().Name);

            try
            {
                // Action                
                ManageListings manageListingsObj = new ManageListings();
                manageListingsObj.DeleteShareSkill();

                // Assertion              
                string resultStatusNotification = manageListingsObj.GetNotification();
                string expectedStatusNotification = "has been deleted";
                Assert.That(resultStatusNotification.Contains(expectedStatusNotification));                

                // Log status in Extentreports
                test.Log(Status.Pass, "Passed, action successfull");
            }
            catch (Exception ex)
            {
                // Log status in Extentreports
                test.Log(Status.Fail, "Failed, action unsuccessfull");
                test.Log(Status.Info, ex.Message);
            }
        }


        [OneTimeTearDown]
        public void SaveExtentReports()
        {
            // Save Extentereport html file
            extent.Flush();
        }
    }
}