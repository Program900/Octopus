using NLog;
using NUnit.Framework;
using Octopus.Data;
using Octopus.Enums;
using Octopus.Helpers;
using Octopus.Pages;
using Octopus.Resources;
using OpenQA.Selenium;
using System;


namespace Octopus.Tests
{
    
    public class BaseTest
    {

        [OneTimeSetUp]
        public void SetupBeforeAllTests()
        {
            ReporterHelper.StartReporter();
        }

        [SetUp]
        public void SetupBeforeEverySingleTest()
        {

             Logger.Debug("*** TEST STARTED ***");
            ReporterHelper.AddTestCaseMetadataToHtmlReports(TestContext.CurrentContext);

            Driver = new WebDriverFactory().Create(BrowserType.Chrome);
            Driver.Manage().Window.Maximize();
            


            ScreenshotTaker = new ScreenshotTaker(Driver);

            HomePage = new HomePage(Driver);
            HomePage.GoTo();
        }

        [TearDown]
        public void CleanUpAfterEverySingleTest()
        {
            Logger.Debug(GetType().FullName + " started a method tear down");
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = "<pre>" + TestContext.CurrentContext.Result.StackTrace + "</pre>";
            var errorMessage = TestContext.CurrentContext.Result.Message;

            try
            {
                TakeScreenshotForTestFailure();
            }
            catch (Exception e)
            {
                Logger.Error(e.Source);
                Logger.Error(e.StackTrace);
                Logger.Error(e.InnerException);
                Logger.Error(e.Message);
            }
            finally
            {
                StopBrowser();
                Logger.Debug(TestContext.CurrentContext.Test.Name);
                Logger.Debug("*** TEST STOPPED ***");

            }

        }

        private void TakeScreenshotForTestFailure()
        {
            if (ScreenshotTaker != null)
            {
                ScreenshotTaker.CreateScreenshotIfTestFailed();
                ReporterHelper.ReportTestOutcome(ScreenshotTaker.ScreenshotFilePath);
            }
            else
            {
                ReporterHelper.ReportTestOutcome("");
            }
        }

        private void StopBrowser()
        {
            if (Driver == null)
                return;

            Driver.Quit();
            Driver = null;
            Logger.Trace("Browser stopped successfully.");
        }

        public UserData GetUserData(string userType)
        {
            var userData = Prop.GetUserType(userType);
            return userData;
        }


        public IWebDriver Driver { get; private set; }
        public HomePage HomePage { get; private set; }

        public InsightsPage InsightsPage { get; set; }

        public AboutPage AboutPage { get; private set; }

        public BusinessPage BusinessPage { get; set; }

        public ContactPage ContactPage { get; set; }

        public CareersPage CareersPage { get; private set; }

  
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        public TestContext TestContext { get; set; }
        private ScreenshotTaker ScreenshotTaker { get; set; }
    }
}