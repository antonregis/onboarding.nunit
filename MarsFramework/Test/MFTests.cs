using NUnit.Framework;
using MarsFramework.Global;
using MarsFramework.Pages;
using AventStack.ExtentReports.Reporter;
using MarsFramework.Config;
using AventStack.ExtentReports;
using System;


namespace MarsFramework
{
    [TestFixture]
    class MFTests : Base
    {
         [OneTimeSetUp]
        public void StartExtentReports()
        {
            // Initialize ExtentReports
            var htmlReporter = new ExtentHtmlReporter(MarsResource.ReportPath);
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
                shareSkillObj.EnterShareSkill();

                // Assertion
                string enteredCategory = shareSkillObj.GetCategory();
                string enteredTitle = shareSkillObj.GetTitle();
                string expectedCategory = GlobalDefinitions.ExcelLib.ReadData(2, "Category");
                string expectedTitle = GlobalDefinitions.ExcelLib.ReadData(2, "Title");
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

        

        //[Test]
        //public void Test2()
        //{
        //    // Create Extentreport test, name extracted from current method name
        //    test = extent.CreateTest(System.Reflection.MethodBase.GetCurrentMethod().Name);

        //    try
        //    {
        //        // Action
        //        string actualResult = "doll";
        //        string expectedResult = "dummy";

        //        // Does nothing really but just to change screenshot image
        //        GlobalDefinitions.driver.Navigate().GoToUrl("http://localhost:5000/Home/ListingManagement");

        //        // Assertion
        //        Assert.That(actualResult, Is.EqualTo(expectedResult));

        //        // Log status in Extentreports
        //        test.Log(Status.Pass, "Passed, Action successfull");
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log status in Extentreports
        //        test.Log(Status.Fail, "Failed, Action unsuccessfull");
        //        test.Log(Status.Info, ex.Message);
        //    }
        //}



        [OneTimeTearDown]
        public void SaveExtentReports()
        {
            // Save Extentereport html file
            extent.Flush();
        }
    }
}