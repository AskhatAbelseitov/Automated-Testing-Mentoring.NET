using log4net;
using Microsoft.VisualBasic;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;
using Selenium_Webdriver._Basics.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Selenium_Webdriver._Basics

{
    class Search
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private IWebDriver driver;
        private readonly By _magnifierIcon = By.XPath("//button[@class='header-search__button header__icon']");
        private readonly By _fieldQueryParameter = By.XPath("//div[@class='search-results__input-holder']//input");
        private readonly By _variantParemeter = By.XPath("//li[@class='frequent-searches__item']");
        private readonly By _buttonFindInitial = By.XPath("//button[@class='header-search__submit']");
        private readonly By _searchResult = By.XPath("//p[@class='search-results__description']//strong");



        public Search(IWebDriver driver)
        {
            this.driver = driver;
        }

        public Search Searching(string varSort)
        {
            try
            {
                Waits.WaitElement(driver, _magnifierIcon);
                driver.FindElement(_magnifierIcon).Click();
                log.Info("'Magnifier' icon is clicked successfully");

            }
            catch (Exception)
            {
                log.Error("'Magnifier' icon isn't found");
            }

            try
            {
                Waits.WaitElement(driver, _fieldQueryParameter);
                driver.FindElement(_fieldQueryParameter).Click();

                Waits.WaitSomeInterval();
                var sortBy = driver.FindElements(_variantParemeter).First(x => x.Text == varSort);
                sortBy.Click();

                Waits.WaitSomeInterval();
                driver.FindElement(_fieldQueryParameter).SendKeys($"/{Variables.areaAutomationInput}/{Variables.areaCloudInput}");

                Waits.WaitElement(driver, _buttonFindInitial);
                driver.FindElement(_buttonFindInitial).Click();

                driver.FindElement(Careers._acceptCookiesButton).Click();

                Actions act = new Actions(driver);
                act.SendKeys(Keys.Shift + Keys.End).Build().Perform();
                Waits.WaitSomeInterval();
                act.SendKeys(Keys.Shift + Keys.End).Build().Perform();

                log.Info("Searching parameters are entered");

            }
            catch (Exception)
            {
                log.Error("Searching parameters aren't entered");
            }
            return this;
        }
                
        public List<string> ResultChecking => driver.FindElements(_searchResult).
        Select(x => x.Text).ToList();

    }
}
