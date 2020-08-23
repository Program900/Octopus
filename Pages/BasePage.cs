using Octopus.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using EC = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Octopus.Pages
{
    public class BasePage
    {
        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));       
        }
        protected IWebDriver Driver { get; set; }
        protected WebDriverWait Wait { get; set; }
        protected void Click(By locator) => Driver.FindElement(locator).Click();
        protected void SetText(By locator, string text)
        {
            LocateElement(locator).SendKeys(text);

            LoggerHelpers.LogInfoAboutValueEnteredIntoFormField(text);
        }
        protected string GetTextOfElement(By locator) => LocateElement(locator).Text;
        protected IWebElement LocateElement(By locator) => Driver.FindElement(locator);
        protected bool IsElementDisplayedImmediately(By locator) => LocateElement(locator).Displayed;
        protected bool IsElementDisplayedAfterWaiting(By locator)
        {
            Wait.Until(EC.ElementIsVisible(locator));

            return LocateElement(locator).Displayed;
        }
        protected bool IsElementappearedAfterWaiting(By locator)
        {
            try
            {
                Wait.Until(EC.InvisibilityOfElementLocated(locator));
                return true;
            }
            catch (Exception)
            {
                throw new Exception("Element is still visible");
            }
        }
        protected void  MoveTotheElement(By locator)
        {
            Actions actions = new Actions(Driver);
            IWebElement mainMenu = Driver.FindElement(locator);
            actions.MoveToElement(mainMenu);
        }
        
        protected void ClickOnElementAfterWaiting(By locator) => Wait.Until(EC.ElementIsVisible(locator)).Click();
        protected void WaitForBrowserAlert() => Wait.Until(EC.AlertIsPresent());
    }

     
}