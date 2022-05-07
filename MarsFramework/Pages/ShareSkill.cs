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
            PageFactory.InitElements(driver, this);
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

        //Click on Manage Listings Link
        [FindsBy(How = How.LinkText, Using = "Manage Listings")]
        private IWebElement manageListingsLink { get; set; }      

        #endregion


        public void EnterShareSkill()
        {
            // Referencing to an excel file and sheet name
            ExcelLib.PopulateInCollection(Base.ExcelPath, "ShareSkill");
            
            try
            {
                ShareSkillButton.Click();
                WaitForShareSkillPageToLoad();
                Title.SendKeys(ExcelLib.ReadData(2, "Title"));
                Description.SendKeys(ExcelLib.ReadData(2, "Description"));
                CategoryDropDown.SendKeys(ExcelLib.ReadData(2, "Category"));
                SubCategoryDropDown.SendKeys(ExcelLib.ReadData(2, "Subcategory"));
                Tags.SendKeys(ExcelLib.ReadData(2, "Tags"));
                Tags.SendKeys(Keys.Enter);
                ServiceTypeOptions.Click();
                LocationTypeOption.Click();
                StartDateDropDown.SendKeys(ExcelLib.ReadData(2, "Start date"));
                EndDateDropDown.SendKeys(ExcelLib.ReadData(2, "End date"));
                Days.Click();
                PopulateTimeInfo("start", ExcelLib.ReadData(2, "Start time"));
                PopulateTimeInfo("end", ExcelLib.ReadData(2, "End time"));
                SkillTradeOption.Click();
                SkillExchange.SendKeys(ExcelLib.ReadData(2, "Skill-Exchange"));
                SkillExchange.SendKeys(Keys.Enter);
                WorkSample.Click();

                // AutoIT is working but through a compiled version of fileupload_x64.au3 (fileupload_x64.exe)
                // Source file of fileupload_x64.exe is found in \MarsFramework\AutoIT\fileupload_x64.au3
                // AutoIT script below for some reason does not work if ran from this project but fileupload_x64.exe does the job
                //      AutoItX3 autoIt = new AutoItX3();
                //      autoIt.WinActivate("Open");
                //      autoIt.Send(@"G:\onboarding.nunit\MarsFramework\AutoIT\Fileupload\worksample.txt");
                //      autoIt.Send("{ENTER}")

                // Uploading worksample.txt
                Process.Start(@"G:\onboarding.nunit\MarsFramework\AutoIt\fileupload_x64.exe");

                // Wait for work samples listing to load
                WaitForElement(driver, By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[9]/div/div[2]/section/div/label/div/div/i"), 10);

                // Taking a screenshot of Work Sample as reinforcement that AutoIT worked
                // string img = SaveScreenShotClass.SaveScreenshot(driver, "Worksample");
                // Base.test.AddScreenCaptureFromPath(img);

                ActiveOption.Click();
                Save.Click();
                Thread.Sleep(1000);
            }
            catch (Exception e) 
            {
                Console.WriteLine(e);
            }
        }


        public void EditShareSkill()
        {
            // Referencing to an excel file and sheet name
            ExcelLib.PopulateInCollection(Base.ExcelPath, "ShareSkill");

            try
            {             
                manageListingsLink.Click();
                WaitForManageListingToLoad();
                ManageListings manageLsObj = new ManageListings();
                manageLsObj.edit.Click();
                WaitForShareSkillPageToLoad();
                Title.Clear();
                Title.SendKeys(ExcelLib.ReadData(3, "Title"));
                wait(1);
                Description.Clear();
                Description.SendKeys(ExcelLib.ReadData(3, "Description"));
                wait(1);
                CategoryDropDown.SendKeys(ExcelLib.ReadData(3, "Category"));
                wait(1);
                Save.Click();
                WaitForManageListingToLoad();
            }
            catch (Exception e) 
            {
                Console.WriteLine(e);
            }
        }





        public void PopulateTimeInfo(string whichTime, string timeToExtract) 
        {
            // breaking strings apart to extract date
            string[] _eTime = timeToExtract.Split(' ');

            // breaking date to hour and minute chunks
            string[] eTime = _eTime[1].Split(':');

            if (whichTime == "start")
            {
                // hours
                StartTimeDropDown.SendKeys(eTime[0]);

                // minutes
                StartTimeDropDown.SendKeys(eTime[1]);

                // am/pm
                StartTimeDropDown.SendKeys(timeToExtract.Substring(eTime.Length - 2));
            }
            else if (whichTime == "end") 
            {
                // hours
                EndTimeDropDown.SendKeys(eTime[0]);

                // minutes
                EndTimeDropDown.SendKeys(eTime[1]);

                // am/pm
                EndTimeDropDown.SendKeys(timeToExtract.Substring(eTime.Length - 2));
            }
        }
    }
}