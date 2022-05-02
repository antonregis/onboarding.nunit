using MarsFramework.Config;
using MarsFramework.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;


namespace MarsFramework.Global
{
    class Base
    {
        #region To access Path from resource file

        public static int Browser = Int32.Parse(MarsResource.Browser);
        public static String ExcelPath = MarsResource.ExcelPath;
        public static string ScreenshotPath = MarsResource.ScreenshotPath;
        public static string ReportPath = MarsResource.ReportPath;

        #endregion


        #region setup and tear down

        [SetUp]
        public void Inititalize()
        {
            switch (Browser)
            {
                case 1:
                    GlobalDefinitions.driver = new FirefoxDriver();
                    break;
                case 2:
                    GlobalDefinitions.driver = new ChromeDriver();
                    break;
            }

            // Maximize browser window
            GlobalDefinitions.driver.Manage().Window.Maximize();

            
            if (MarsResource.IsLogin == "true")
            {
                SignIn loginobj = new SignIn();
                loginobj.LoginSteps();
            }
            else
            {
                SignUp obj = new SignUp();
                obj.register();
            }
        }


        [TearDown]
        public void TearDown()
        {            
            // Close the driver :)            
           GlobalDefinitions.driver.Close();
        }

        #endregion
    }
}