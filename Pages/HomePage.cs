using Octopus.Helpers;
using Octopus.Resources;
using OpenQA.Selenium;
using System;
using System.Configuration;
using System.Threading;

namespace Octopus.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver) { }

        public string HomePageTitle = Prop.Settings("HomePageTitle").Value;  
        public string HomePageUrl => ConfigurationManager.AppSettings["Website"];    
        public By HomeLinkLocator => By.XPath("//*[@id='post-10']/div/section[1]/div[1]/div/h1");
        public By InsightsLinkLocator => By.XPath("(//*[@id='menu-item-36'])[1]");
        public By InsightsLink => By.XPath("(//a[contains(text(),'Insights')])[2]");      
        public By AboutLinkLocator => By.LinkText("About us");
        public By BusinessLinkLocator => By.LinkText("Businesses");
        public By CareersLinkLocator => By.Id("login2");
        public By ContactLinkLocator => By.LinkText("Contact");

        internal bool IsHomePageOpened()
        {
            Thread.Sleep(200);
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
                "Page title is correct",
                $"Expected page title was {HomePageTitle} but actual page title is: {Driver.Title}"
                );

            return testStepResult;
        }      
    }
}