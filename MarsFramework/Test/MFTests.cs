using NUnit.Framework;
using MarsFramework.Global;
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
        public void Test1()
        {
            // Create Extentreport test, name extracted from current method name
            test = extent.CreateTest(System.Reflection.MethodBase.GetCurrentMethod().Name);

            try
            {
                // Action
                string actualResult = "dummy";
                string expectedResult = "dummy";

                // Assertion
                Assert.That(actualResult, Is.EqualTo(expectedResult));

                // Log status in Extentreports
                test.Log(Status.Pass, "Passed, Action successfull");
            }
            catch (Exception ex) 
            {
                // Log status in Extentreports
                test.Log(Status.Fail, "Failed, Action unsuccessfull");
                test.Log(Status.Info, ex.Message);
            }
        }


        [Test]
        public void Test2()
        {
            // Create Extentreport test, name extracted from current method name
            test = extent.CreateTest(System.Reflection.MethodBase.GetCurrentMethod().Name);

            try
            {
                // Action
                string actualResult = "doll";
                string expectedResult = "dummy";

                // Does nothing really but just to change screenshot image
                GlobalDefinitions.driver.Navigate().GoToUrl("http://localhost:5000/Home/ListingManagement");

                // Assertion
                Assert.That(actualResult, Is.EqualTo(expectedResult));

                // Log status in Extentreports
                test.Log(Status.Pass, "Passed, Action successfull");
            }
            catch (Exception ex)
            {
                // Log status in Extentreports
                test.Log(Status.Fail, "Failed, Action unsuccessfull");
                test.Log(Status.Info, ex.Message);
            }
        }


        [OneTimeTearDown]
        public void SaveExtentReportsAndQuitBrowser()
        {
            // Save Extentereport html file
            extent.Flush();

            // Quit browser
            GlobalDefinitions.driver.Quit();
        }
    }
}