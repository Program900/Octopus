using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octopus.Helpers
{
    public static class LoggerHelpers
    {
        public static void LogInfoAboutAlertShowed(bool testStepResult)
        {
            ReporterHelper.LogTestStep(
                testStepResult,
                "Browser alert containing expected message has been displayed",
                "Browser alert containing expected message has not been displayed"
                );
        }

        public static void LogInfoAboutPageOrWindowOpening(string windowOrPageName)
        {
            ReporterHelper.LogPassingTestStep($"Opening the {windowOrPageName}");
        }

        public static void LogInfoAboutPageOrWindowOpened(bool testStepResult, string windowOrPageName)
        {
            ReporterHelper.LogTestStep(
                testStepResult,
                $"{windowOrPageName} has been opened successfully",
                $"{windowOrPageName} has not been opened"
                );
        }

        internal static void LogInfoAboutValueEnteredIntoFormField(string text)
        {
            throw new NotImplementedException();
        }

        public static void LogInfoAboutWindowSubmitted(string windowName)
        {
            ReporterHelper.LogPassingTestStep($"{windowName} has been submitted");
        }

       
        public static void LogInfoAboutWebElementDisplayed(bool testStepResult, string webElementName)
        {
            ReporterHelper.LogTestStep(
                testStepResult,
                $"{webElementName} has been displayed",
                $"{webElementName} has not been displayed"
                );
        }
    }
}
