using Octopus.Helpers;
using Octopus.Resources;
using OpenQA.Selenium;
using System;
using System.Configuration;


namespace Octopus.Pages
{
    public class BusinessPage : BasePage
    {
        public BusinessPage(IWebDriver driver) : base(driver) { }

        private By OurBusinesses => By.XPath("//*[@id='post-12']/div/section[1]/div/h1");
        private string BusinessPageTitle =  ConfigurationManager.AppSettings["BusinessPageTitle"]; 
        internal bool IsBusinessPageOpened()
        {
           
            var testStepResult = Driver.FindElement(OurBusinesses).Displayed;
            LoggerHelpers.LogInfoAboutPageOrWindowOpening("BusinessPage");

            return testStepResult;
        }
        internal bool IsBusinessPageTitleCorrect()
        {
            var testStepResult = Driver.Title.Contains(BusinessPageTitle);
            Console.WriteLine(Driver.Title);
            ReporterHelper.LogTestStep(
                testStepResult,
                "Business Page title is correct",
                $"Expected page title was {BusinessPageTitle} but actual page title is: {Driver.Title}"
                );
            return testStepResult;
        }
    }
}
