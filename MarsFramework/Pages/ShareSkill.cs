using MarsFramework.Global;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Threading;
using System.Diagnostics;
using static MarsFramework.Global.GlobalDefinitions;


namespace MarsFramework.Pages
{
    public class ShareSkill 
    {
        public ShareSkill()
        {
            PageFactory.InitElements(GlobalDefinitions.driver, this);
        }

        #region Initialize Web Elements (Page Factory style)

        //Click on ShareSkill Button
        [FindsBy(How = How.LinkText, Using = "Share Skill")]
        private IWebElement ShareSkillButton { get; set; }

        //Enter the Title in textbox
        [FindsBy(How = How.Name, Using = "title")]
        private IWebElement Title { get; set; }

        //Enter the Description in textbox
        [FindsBy(How = How.Name, Using = "description")]
        private IWebElement Description { get; set; }

        //Click on Category Dropdown
        [FindsBy(How = How.Name, Using = "categoryId")]
        private IWebElement CategoryDropDown { get; set; }

        //Click on SubCategory Dropdown
        [FindsBy(How = How.Name, Using = "subcategoryId")]
        private IWebElement SubCategoryDropDown { get; set; }

        //Enter Tag names in textbox
        [FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[contains(@class,'ui container')]/div[contains(@class,'listing')]/form[contains(@class,'ui form')]/div[contains(@class,'tooltip-target ui grid')]/div[contains(@class,'twelve wide column')]/div[contains(@class,'')]/div[contains(@class,'ReactTags__tags')]/div[contains(@class,'ReactTags__selected')]/div[contains(@class,'ReactTags__tagInput')]/input[1]")]
        private IWebElement Tags { get; set; }

        //Select the Service type
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[5]/div[2]/div[1]/div[1]/div")]
        private IWebElement ServiceTypeOptions { get; set; }

        //Select the Location Type
        [FindsBy(How = How.XPath, Using = "//form/div[6]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        private IWebElement LocationTypeOption { get; set; }

        //Click on Start Date dropdown
        [FindsBy(How = How.Name, Using = "startDate")]
        private IWebElement StartDateDropDown { get; set; }

        //Click on End Date dropdown
        [FindsBy(How = How.Name, Using = "endDate")]
        private IWebElement EndDateDropDown { get; set; }

        //Storing the table of available days
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[3]/div[1]/div/input")]
        private IWebElement Days { get; set; }

        //Click on StartTime dropdown
        [FindsBy(How = How.XPath, Using = "//div[3]/div[2]/input[1]")]
        private IWebElement StartTimeDropDown { get; set; }

        //Click on EndTime dropdown
        [FindsBy(How = How.XPath, Using = "//div[3]/div[3]/input[1]")]
        private IWebElement EndTimeDropDown { get; set; }

        //Click on Skill Trade option
        [FindsBy(How = How.XPath, Using = "//form/div[8]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        private IWebElement SkillTradeOption { get; set; }

        //Enter Skill Exchange
        [FindsBy(How = How.XPath, Using = "//div[@class='form-wrapper']//input[@placeholder='Add new tag']")]
        private IWebElement SkillExchange { get; set; }

        //Click on Work Sample
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[9]/div/div[2]/section/div/label/div/span/i")]
        private IWebElement WorkSample { get; set; }

        //Enter the amount for Credit
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Amount']")]
        private IWebElement CreditAmount { get; set; }

        //Click on Active/Hidden option
        [FindsBy(How = How.XPath, Using = "//form/div[10]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        private IWebElement ActiveOption { get; set; }

        //Click on Save button
        [FindsBy(How = How.XPath, Using = "//input[@value='Save']")]
        private IWebElement Save { get; set; }

        //Storing the Category
        [FindsBy(How = How.XPath, Using = "//tbody/tr[1]/td[2]")]
        private IWebElement categoryManageListing { get; set; }

        //Storing the Title
        [FindsBy(How = How.XPath, Using = "//tbody/tr[1]/td[3]")]
        private IWebElement titleManageListing { get; set; }

        #endregion

        public void EnterShareSkill()
        {
            // Referencing to an excel file and sheet name
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ShareSkill");
            try
            {
                ShareSkillButton.Click();
                Title.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Title"));
                Description.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));
                CategoryDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Category"));
                SubCategoryDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Subcategory"));
                Tags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Tags"));
                Tags.SendKeys(Keys.Enter);
                ServiceTypeOptions.Click();
                LocationTypeOption.Click();
                StartDateDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Start date"));
                EndDateDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "End date"));
                Days.Click();

                string startTime = (GlobalDefinitions.ExcelLib.ReadData(2, "Start time"));
                StartTimeDropDown.SendKeys(ExtractTimeInfo(startTime, "hh"));
                StartTimeDropDown.SendKeys(ExtractTimeInfo(startTime, "mm"));
                StartTimeDropDown.SendKeys(ExtractTimeInfo(startTime, "ampm"));

                string endTime = (GlobalDefinitions.ExcelLib.ReadData(2, "End time"));
                EndTimeDropDown.SendKeys(ExtractTimeInfo(endTime, "hh"));
                EndTimeDropDown.SendKeys(ExtractTimeInfo(endTime, "mm"));
                EndTimeDropDown.SendKeys(ExtractTimeInfo(endTime, "ampm"));
                
                SkillTradeOption.Click();
                SkillExchange.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Skill-Exchange"));
                SkillExchange.SendKeys(Keys.Enter);
                WorkSample.Click();

                //AutoIT is working but through a compiled version of fileupload_x64.au3 (fileupload_x64.exe)
                //AutoIT script below for some reason does not work if ran from this file but fileupload_x64.exe does the job
                    //AutoItX3 autoIt = new AutoItX3();
                    //autoIt.WinActivate("Open");
                    //autoIt.Send(@"G:\onboarding.nunit\MarsFramework\AutoIT\Fileupload\worksample.txt");
                    //autoIt.Send("{ENTER}")

                // Uploading worksample.txt
                // Source file in \MarsFramework\AutoIT\fileupload_x64.au3
                Process.Start(@"G:\onboarding.nunit\MarsFramework\AutoIt\fileupload_x64.exe");

                // Wait for the page to load (uploaded file in the work samples listing)
                GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[9]/div/div[2]/section/div/label/div/div/i"), 4);

                // Taking a screenshot of Work Sample as reinforcement that AutoIT worked
                string img = SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "Worksample");
                Base.test.AddScreenCaptureFromPath(img);

                ActiveOption.Click();
                Save.Click();

                // Go to Manage Listing
                GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SignIn");
                GlobalDefinitions.driver.Navigate().GoToUrl(GlobalDefinitions.ExcelLib.ReadData(2, "Url")+ "/Home/ListingManagement");

                // Wait for Manage listings page to load 
                Thread.Sleep(2000);

                // Restoring reference to excel sheet ShareSkill for assertion purposes
                GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ShareSkill");
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

        public static string ExtractTimeInfo(string timeToExtract, string extractWhat)
        {
            string[] _eTime = timeToExtract.Split(' ');
            string[] eTime = _eTime[1].Split(':');
            string returnValue;

            if (extractWhat == "hh")
            {
                returnValue = eTime[0];
            }
            else if (extractWhat == "mm")
            {
                returnValue = eTime[1];
            }
            else if (extractWhat == "ampm")
            {
                returnValue = timeToExtract.Substring(eTime.Length - 2);
            }
            else 
            {
                returnValue = "00";
            }

            return returnValue;
        }


        public void EditShareSkill()
        {
            // do nothing yet
        }
    }
}
