using Octopus.Helpers;
using Octopus.Resources;
using OpenQA.Selenium;
using System;
using System.Configuration;


namespace Octopus.Pages
{
    public class ContactPage: BasePage
    {
        public ContactPage(IWebDriver driver) : base(driver) { }

        private By ContactUs => By.XPath("//*[@id='post-94']/div/section[1]/div/h2");
      
        private string ContactUsPageTitle =  ConfigurationManager.AppSettings["ContactUsPageTitle"]; 

        internal bool IsContactPageOpened()
        {
           
            var testStepResult = Driver.FindElement(ContactUs).Displayed;
            LoggerHelpers.LogInfoAboutPageOrWindowOpening("ContactPage");
            return testStepResult;
        }
        internal bool IsContactPageTitleCorrect()
        {
            var testStepResult = Driver.Title.Contains(ContactUsPageTitle);
            Console.WriteLine(Driver.Title);
            ReporterHelper.LogTestStep(
                testStepResult,
                "Contact Page title is correct",
                $"Expected page title was {ContactUsPageTitle} but actual page title is: {Driver.Title}"
                );
            return testStepResult;
        }

       
    }
}
