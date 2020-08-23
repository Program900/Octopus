using Octopus.Enums;
using OpenQA.Selenium;
using System;
using System.IO;
using System.Reflection;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

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
                case BrowserType.InternetExplorer:
                    return GetIEDriver();
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
            return new FirefoxDriver();
        }
        private IWebDriver GetEdgeDriver()
        {
            return new EdgeDriver();
        }
        private IWebDriver GetIEDriver()
        {
            return new InternetExplorerDriver();
        }
    }
}
