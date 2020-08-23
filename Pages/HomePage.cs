
using Octopus.Enums;
using Octopus.Helpers;
using Octopus.Resources;
using Octopus.Tests;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Octopus.Pages
{
    public class HomePage : BasePage
    {
        //public const string HomePageTitle = "Octopus Group: Investments, Real Estate, Ventures, Energy, Wealth";
        public string HomePageTitle = Prop.Settings("HomePageTitle").Value;

        public By ProductLocator(string productName) => By.XPath($"//a[text()='{productName}']");

        public string HomePageUrl => ConfigurationManager.AppSettings["Website"];


        
        public By HomeLinkLocator => By.XPath("//*[@id='post-10']/div/section[1]/div[1]/div/h1");
        public By InsightsLinkLocator => By.XPath("(//*[@id='menu-item-36'])[1]");

        public By InsightsLink => By.XPath("(//a[contains(text(),'Insights')])[2]");


        
        public By AboutLinkLocator => By.LinkText("About us");
        public By BusinessLinkLocator => By.LinkText("Businesses");
        public By CareersLinkLocator => By.Id("login2");
        public By ContactLinkLocator => By.LinkText("Contact");


      
        public HomePage(IWebDriver driver) : base(driver) { }

        internal void GoTo()
        {
            
            Driver.Navigate().GoToUrl(HomePageUrl);
            
            ReporterHelper.LogPassingTestStep($"Opening Octopus.com homepage");
        }

        internal bool IsPageOpened()
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

        public T ClickLink<T>(LinkText link)
        {
            switch (link)
            {
                case LinkText.Insights:
                    Click(InsightsLinkLocator);
                   
                    Thread.Sleep(2000);
                    MoveTotheElement(InsightsLink);
                    Click(InsightsLink);
                    LoggerHelpers.LogInfoAboutPageOrWindowOpening("InsightsPage");
                    return (T)Convert.ChangeType(new InsightsPage(Driver), typeof(T));

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