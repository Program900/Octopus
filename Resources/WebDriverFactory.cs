using Octopus.Enums;
using OpenQA.Selenium;
using System;
using System.IO;
using System.Reflection;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace Octopus.Resources
{
    public class WebDriverFactory
    {
        public IWebDriver Create(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    return GetChromeDriver();
                case BrowserType.Firefox:
                    return GetFirefoxDriver();
                case BrowserType.Edge:
                    return GetEdgeDriver();
                default:
                    throw new ArgumentOutOfRangeException("No such browser exist");
            }
        }
        private IWebDriver GetChromeDriver()
        {
            

            return new ChromeDriver();
        }

        private IWebDriver GetFirefoxDriver()
        {
            var outputDirectory = GetAssemblysOutputDirectory();
            var directoryWithFirefoxDriver = CreateFilePath(outputDirectory);

            if (string.IsNullOrEmpty(directoryWithFirefoxDriver))
            {
                directoryWithFirefoxDriver = CreateFilePath(outputDirectory);
            }

            return new FirefoxDriver(directoryWithFirefoxDriver);
        }

        private IWebDriver GetEdgeDriver()
        {
            var outputDirectory = GetAssemblysOutputDirectory();
            var directoryWithEdgeDriver = CreateFilePath(outputDirectory);

            if (string.IsNullOrEmpty(directoryWithEdgeDriver))
            {
                directoryWithEdgeDriver = CreateFilePath(outputDirectory);
            }

            return new EdgeDriver(directoryWithEdgeDriver);
        }
        private static string CreateFilePath(string outputDirectory)
            => Path.GetFullPath(Path.Combine(outputDirectory ?? throw new InvalidOperationException(), @"..\..\..\Octopus\Resources"));

        


        private static string GetAssemblysOutputDirectory() => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    }
}
