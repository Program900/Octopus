
using Octopus.Enums;
using Octopus.Helpers;
using Octopus.Resources;
using OpenQA.Selenium;
using System;
using System.Configuration;
using System.Threading;

namespace Octopus.Pages
{
    public class InsightsPage : BasePage
{
        public InsightsPage(IWebDriver driver) : base(driver) { }
        public string InsightsPageeUrl { get; private set; }   
        public string InsightsPageTitle = Prop.Settings("InsightsPageTitle").Value;
        public string InsightsPageUrl = ConfigurationManager.AppSettings["Website"];
        public By InsightsLinkLocator => By.XPath("//*[@id='main']/section[1]/div[1]/div/h1");
        public By ContactLinkLocator => By.LinkText("Contact");
        public By AboutUsLinkLocator => By.LinkText("About us");
        public By Home => By.CssSelector("div.primaryNav--desktop > a.header-logo > svg");
        public By HomeLinkLocator => By.XPath("//article[@id='post-10']/div/section/div/div/h1");
        public By InsightsLink => By.XPath("(//a[contains(text(),'Insights')])[2]");
        public By AboutLinkLocator => By.LinkText("About us");
        public By BusinessLinkLocator => By.LinkText("Businesses");
        public By CareersLinkLocator => By.Id("login2");
        internal void GoTo()
        {
            Driver.Navigate().GoToUrl(InsightsPageUrl);

            ReporterHelper.LogPassingTestStep($"Opening Octopus.com InsightsPage");
        }
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
        public T ClickLink<T>(LinkText link)
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
    }
}
