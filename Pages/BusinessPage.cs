using Octopus.Helpers;
using Octopus.Resources;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Octopus.Pages
{
    public class BusinessPage : BasePage
    {
        public BusinessPage(IWebDriver driver) : base(driver) { }

        public By OurBusinesses => By.XPath("//*[@id='post-12']/div/section[1]/div/h1");
        public string BusinessPageTitle = Prop.Settings("BusinessPageTitle").Value;

       



        internal bool IsBusinessPageOpened()
        {
            Thread.Sleep(200);
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
                "Page title is correct",
                $"Expected page title was {BusinessPageTitle} but actual page title is: {Driver.Title}"
                );

            return testStepResult;
        }
    }
}
