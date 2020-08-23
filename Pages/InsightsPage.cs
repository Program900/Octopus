using log4net;

using Octopus.Enums;
using Octopus.Helpers;
using Octopus.Resources;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Octopus.Pages
{
    public class InsightsPage : BasePage
{
        public string InsightsPageeUrl { get; private set; }
       
        public  string InsightsPageTitle = Prop.Settings("InsightsPageTitle").Value;

        public string  Url = ConfigurationManager.AppSettings["Website"];

        public By InsightsLinkLocator => By.XPath("//*[@id='main']/section[1]/div[1]/div/h1");
        public By ContactLinkLocator => By.LinkText("Contact");
        public By AboutUsLinkLocator => By.LinkText("About us");
        
       

        public InsightsPage(IWebDriver driver) : base(driver) { }

       
        internal bool IsInsightsPageOpened()
        {
            Thread.Sleep(2000);
            var testStepResult = Driver.FindElement(InsightsLinkLocator).Displayed;
            LoggerHelpers.LogInfoAboutPageOrWindowOpening("InsightsPage");

            return testStepResult;
        }

        internal bool IsPageTitleCorrect()
        {
            var testStepResult = Driver.Title == InsightsPageTitle;
            Console.WriteLine(Driver.Title);
            ReporterHelper.LogTestStep(
                testStepResult,
                "Page title is correct",
                $"Expected page title was {InsightsPageTitle} but actual page title is: {Driver.Title}"
                );

            return testStepResult;
        }

        

      
    }
}
