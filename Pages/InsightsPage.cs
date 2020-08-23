
using MongoDB.Bson.Serialization.Serializers;
using Octopus.Enums;
using Octopus.Helpers;
using Octopus.Resources;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Configuration;


namespace Octopus.Pages
{
    public class InsightsPage : BasePage
{
        public InsightsPage(IWebDriver driver) : base(driver) { }
    
        private string InsightsPageTitle =  ConfigurationManager.AppSettings["InsightsPageTitle"];
        private string InsightsPageUrl = ConfigurationManager.AppSettings["Website"];
       
       private string ExpectedResultText = ConfigurationManager.AppSettings["SearchKeyword"];
       private  string ExpectedResultValue = ConfigurationManager.AppSettings["DropdownValue"];

        private By InsightsLinkLocator => By.XPath("//*[@id='main']/section[1]/div[1]/div/h1");
        private By ContactLinkLocator => By.LinkText("Contact");
  
        private By Home => By.CssSelector("div.primaryNav--desktop > a.header-logo > svg");
   
        private By AboutLinkLocator => By.LinkText("About us");
        private By BusinessLinkLocator => By.LinkText("Businesses");
        private By CareersLinkLocator => By.Id("//*[@id='menu-item-95']/a");
        private By OctopusEnergyLocator => By.XPath("//*[@id='main']/section[3]/div/div[1]/div[1]/article/div/div[1]/span[2]");

        private By FilterByBusinessLocator => By.XPath("//*[@id='main']/section[2]/div/form/div[2]/select");
        private By SearchKeywordLocator => By.XPath("//*[@id='main']/section[2]/div/form/div[1]/input");
        private By SubmitButton => By.XPath("//*[@id='main']/section[2]/div/form/div[1]/i");

        private By OctopusGroupLocator => By.XPath("//*[@id='main']/section[3]/div/div[1]/div[1]/article/div/div[1]/span[1]");
        internal void GoTo()
        {
            Driver.Navigate().GoToUrl(InsightsPageUrl);

            ReporterHelper.LogPassingTestStep($"Opening Octopus.com InsightsPage");
        }
        internal bool IsInsightsPageOpened()
        {
           
            var testStepResult = Driver.FindElement(InsightsLinkLocator).Displayed;
            LoggerHelpers.LogInfoAboutPageOrWindowOpening("InsightsPage");

            return testStepResult;
        }
        internal bool IsPageTitleCorrect()
        {
            var testStepResult = Driver.Title.Equals(InsightsPageTitle);
            Console.WriteLine(Driver.Title);
            ReporterHelper.LogTestStep(
                testStepResult,
                "Insight Page title is correct",
                $"Expected page title was {InsightsPageTitle} but actual page title is: {Driver.Title}"
                );
            return testStepResult;
        }

        internal bool SearchByText()
        {
           

            ScrolltotheElement();
         
            Driver.FindElement(SearchKeywordLocator).Click();
            Driver.FindElement(SearchKeywordLocator).Clear();
            Driver.FindElement(SearchKeywordLocator).SendKeys(ExpectedResultText);
            Driver.FindElement(SubmitButton).Submit();

            ScrolltotheElement();
            //Verify the result page displaying search result text 
           
           string ActualResultText = Driver.FindElement(OctopusGroupLocator).Text;

            var testStepResult = ActualResultText.Equals(ExpectedResultText);

            ReporterHelper.LogTestStep(
                testStepResult,
                "Search Page result is correct",
                $"Expected page result was {ExpectedResultText} but actual page result is: {ActualResultText}"
                );
            return testStepResult;

        }

        internal bool FilterByBusinessValues()
        {
            

            ScrolltotheElement();
            Driver.FindElement(FilterByBusinessLocator).Click();
            SelectElement selectElement = new SelectElement(Driver.FindElement(FilterByBusinessLocator));
            selectElement.SelectByText(ExpectedResultValue);
            ScrolltotheElement();

            //Verify the result page displaying as per selected value from the drop down
            string ActualResultValue = Driver.FindElement(OctopusEnergyLocator).Text;
            var testStepResult = ActualResultValue.Equals(ExpectedResultValue);

            ReporterHelper.LogTestStep(
                testStepResult,
                "Page result is correct as per  selected  value from the drop down",
                $"Expected page result was {ExpectedResultValue} but actual page result is: {ActualResultValue}"
                );
            return testStepResult;



        }

        internal T ClickLink<T>(LinkText link)
        {
            switch (link)
            {
                case LinkText.Home:
                    Click(Home);
                    LoggerHelpers.LogInfoAboutPageOrWindowOpening("HomePage");
                    return (T)Convert.ChangeType(new HomePage(Driver), typeof(T));
                case LinkText.About:
                    Click(AboutLinkLocator);
                    LoggerHelpers.LogInfoAboutPageOrWindowOpening("AboutPage");
                    return (T)Convert.ChangeType(new AboutPage(Driver), typeof(T));
                case LinkText.Business:
                    Click(BusinessLinkLocator);
                    LoggerHelpers.LogInfoAboutPageOrWindowOpening("BusinessPage");
                    return (T)Convert.ChangeType(new BusinessPage(Driver), typeof(T));
                case LinkText.Careers:
                    Click(CareersLinkLocator);
                    LoggerHelpers.LogInfoAboutPageOrWindowOpening("CareerPage");
                    return (T)Convert.ChangeType(new CareersPage(Driver), typeof(T));
                case LinkText.Contact:
                    Click(ContactLinkLocator);
                    LoggerHelpers.LogInfoAboutPageOrWindowOpening("ContactPage");
                    return (T)Convert.ChangeType(new ContactPage(Driver), typeof(T));
                default:
                    throw new Exception("No such link text");
            }
        }

        protected void ScrolltotheElement()
        {

            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;

            js.ExecuteScript("arguments[0].scrollIntoView();", Driver.FindElement(By.XPath("//*[@id='main']/section[2]")));
            
        }



    }
}
