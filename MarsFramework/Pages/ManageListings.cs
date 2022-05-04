using MarsFramework.Global;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Threading;

namespace MarsFramework.Pages
{
    internal class ManageListings
    {
        public ManageListings()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }


        #region Initialize Web Elements (Page Factory style)

        //Click on Manage Listings Link
        [FindsBy(How = How.LinkText, Using = "Manage Listings")]
        private IWebElement manageListingsLink { get; set; }

        //View the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='eye icon'])[1]")]
        private IWebElement view { get; set; }

        //Delete the listing
        [FindsBy(How = How.XPath, Using = "//tbody/tr[1]/td[8]/div[1]/button[3]")]
        private IWebElement delete { get; set; }

        //Edit the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='outline write icon'])[1]")]
        public IWebElement edit { get; set; }

        //Click on Yes or No
        [FindsBy(How = How.XPath, Using = "//div[@class='actions']")]
        private IWebElement clickActionsButton { get; set; }

        //Click on Yes
        [FindsBy(How = How.XPath, Using = "//body/div[2]/div[1]/div[3]/button[2]")]
        private IWebElement yesButton { get; set; }        

        //Storing the Category
        [FindsBy(How = How.XPath, Using = "//tbody/tr[1]/td[2]")]
        private IWebElement categoryManageListing { get; set; }

        //Storing the Title
        [FindsBy(How = How.XPath, Using = "//tbody/tr[1]/td[3]")]
        private IWebElement titleManageListing { get; set; }

        //Storing the Description
        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr/td[4]")]
        private IWebElement descriptionManageListing { get; set; }

        //Storing the Notification
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]")]
        private IWebElement notification { get; set; }

        

        #endregion

        public void DeleteShareSkill() 
        {
            try
            {
                manageListingsLink.Click();

                // Wait for the page to load
                GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("(//i[@class='outline write icon'])[1]"), 4);

                delete.Click();
                yesButton.Click();

                // Wait for the page to load
                Thread.Sleep(1000);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }    
        }



        public string GetCategory()
        {
            return categoryManageListing.Text;
        }

        public string GetTitle()
        {
            return titleManageListing.Text;
        }

        public string GetDescription()
        {
            return descriptionManageListing.Text;
        }

        public string GetNotification()
        {
            return notification.Text;
        }

    }
}
