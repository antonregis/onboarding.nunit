using MarsFramework.Global;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace MarsFramework.Pages
{
    class SignIn
    {
        public SignIn()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        #region  Initialize Web Elements 
        //Finding the Sign Link
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Sign')]")]
        private IWebElement SignIntab { get; set; }

        // Finding the Email Field
        [FindsBy(How = How.Name, Using = "email")]
        private IWebElement Email { get; set; }

        //Finding the Password Field
        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement Password { get; set; }

        //Finding the Login Button
        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Login')]")]
        private IWebElement LoginBtn { get; set; }

        #endregion


        public void LoginSteps()
        {
            // Referencing to an excel file and sheet name
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath + "TestData.xlsx", "SignIn");

            // Go to base Url
            GlobalDefinitions.driver.Navigate().GoToUrl(GlobalDefinitions.ExcelLib.ReadData(2, "Url"));

            // Click signin button
            SignIntab.Click();

            // Picking up excel data from "Username" column, in row 2
            Email.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Username"));

            // Picking up excel data from "Password" column, in row 2
            Password.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Password"));

            // Click login button
            LoginBtn.Click();

            // Wait for the page to load successfully
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//button[contains(text(),'Sign Out')]"), 8);
        }
    }
}