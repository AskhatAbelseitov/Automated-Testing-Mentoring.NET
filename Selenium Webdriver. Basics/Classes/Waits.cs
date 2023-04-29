using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.WaitHelpers;
using Selenium_Webdriver._Basics.Pages;

namespace Selenium_Webdriver._Basics.Classes
{
    public static class Waits
    {
        public static void WaitSomeInterval(int seconds = 15)
        {
            Task.Delay(TimeSpan.FromSeconds(seconds)).Wait();
        }

        public static void WaitElement(IWebDriver driver, By locator, int seconds = 30)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(seconds)).Until(ExpectedConditions.ElementIsVisible(locator));
            new WebDriverWait(driver, TimeSpan.FromSeconds(seconds)).Until(ExpectedConditions.ElementToBeClickable(locator));            
        }        
    }
}