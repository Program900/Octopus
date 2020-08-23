using Octopus.Helpers;
using Octopus.Resources;
using OpenQA.Selenium;
using System;
using System.Configuration;


namespace Octopus.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver) { }

        private string HomePageTitle = ConfigurationManager.AppSettings["HomePageTitle"];
          
         private By HomeLinkLocator => By.XPath("//*[@id='post-10']/div/section[1]/div[1]/div/h1");
      

        internal bool IsHomePageOpened()
        {
          
            var testStepResult = Driver.FindElement(HomeLinkLocator).Displayed;
            LoggerHelpers.LogInfoAboutPageOrWindowOpening("Homepage");

            return testStepResult;
        }
        internal bool IsPageTitleCorrect()
        {
            var testStepResult = Driver.Title.Contains(HomePageTitle);
            Console.WriteLine(Driver.Title);
            ReporterHelper.LogTestStep(
                testStepResult,
                "Home Page title is correct",
                $"Expected page title was {HomePageTitle} but actual page title is: {Driver.Title}"
                );

            return testStepResult;
        }      
    }
}