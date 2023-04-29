using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Selenium_Webdriver._Basics.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_Webdriver._Basics

{
    class Careers
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private IWebDriver driver;
        private readonly By _buttonCareers = By.CssSelector("a.top-navigation__item-link[href='/careers']");
        private readonly By _fieldKeywordInput = By.Id("new_form_job_search-keyword");
        private readonly By _locationsFieldArrowClick = By.ClassName("select2-selection__arrow");
        private readonly By _variantLocationCountrySearch = By.XPath("//li[@class='select2-results__option']//strong");
        private readonly By _variantLocationCitySearch = By.XPath("//ul//li[@class='select2-results__option']");
        private readonly By _checkboxRemote = By.XPath("//p[@class='job-search__filter-items job-search__filter-items--remote']/preceding-sibling::*");
        private readonly By _findButton = By.XPath("//button[@class='small-button-text small-button-preset white-background-preset job-search-button-23']");
        public static readonly By _acceptCookiesButton = By.Id("onetrust-accept-btn-handler");
        private readonly By _searchingVariant = By.XPath("//li[@class='search-result__item']");
        private readonly By _latestVariant = By.XPath("//li[@class='search-result__item'][last()]//div[@class='search-result__item-controls']//a[@class='button-text primary-button-preset white-background-preset search-result__item-apply-23']");
        private readonly By _nameOfCheckinglatestVariant = By.XPath("//h1[@class='vacancy-details-23__job-title']");

        public Careers(IWebDriver driver)
        {
            this.driver = driver;
        }

        public Careers ProgrammingLanguageFind()
        {
            try
            {
                Waits.WaitElement(driver, _buttonCareers);
                driver.FindElement(_buttonCareers).Click();
                log.Info("'Careers' tab is opened successfully");
            }
            catch (Exception)
            {
                log.Error("'Careers' tab isn't opened");
            }
            try
            {
                Waits.WaitElement(driver, _fieldKeywordInput);
                driver.FindElement(_fieldKeywordInput).SendKeys(Variables.langNET1 + "");
                log.Info("Programming language is entered");
            }
            catch (Exception)
            {
                log.Error("Programming language isn't entered");
            }
            return this;
        }

        public Careers LocationCountryCityFind(string location, string city)
        {
            driver.FindElement(_locationsFieldArrowClick).Click();

            try
            {
                Waits.WaitSomeInterval();
                var sortBy = driver.FindElements(_variantLocationCountrySearch).First(x => x.Text == location);
                sortBy.Click();

                Waits.WaitElement(driver, _variantLocationCitySearch);
                sortBy = driver.FindElements(_variantLocationCitySearch).First(x => x.Text == city);
                sortBy.Click();

                log.Info("Location is successfully accepted");
            }
            catch (Exception)
            {
                log.Error("Location isn't accepted");
            }
            return this;
        }


        public Careers FinalFind()
        {
            try
            {
                driver.FindElement(_checkboxRemote).Click();
                log.Info("Checkbox is selected");
            }
            catch (Exception)
            {
                log.Debug("Checkbox isn't selected");
            }
            try
            {
                driver.FindElement(_findButton).Click();
                log.Info("'Find' button is clicked");
            }
            catch (Exception)
            {
                log.Error("'Find' button isn't clicked");
            }

            driver.FindElement(_acceptCookiesButton).Click();

            Waits.WaitSomeInterval();
            int recordsCount = driver.FindElements(_searchingVariant).Count;

            try
            {
                if (recordsCount == 0)
                {
                    Waits.WaitElement(driver, _buttonCareers);
                    driver.FindElement(_buttonCareers).Click();
                    driver.Quit();
                }
                else if (recordsCount < 20)
                {
                    Waits.WaitSomeInterval();
                    driver.FindElement(_latestVariant).Click();
                }
                else
                {
                    Waits.WaitSomeInterval();
                    driver.FindElement(By.TagName("body")).SendKeys(Keys.Control + Keys.End);
                    Waits.WaitSomeInterval();
                    driver.FindElement(_latestVariant).Click();
                }
                log.Info("Latest variant is found and chosen");
            }
            catch (Exception)
            {
                log.Error("Latest varian isn't found");
            }
            return new Careers(driver);
        }

        public bool CheckingProgrammingLanguage()
        {          
            Waits.WaitElement(driver, _nameOfCheckinglatestVariant);
            var checkFunction = driver.FindElement(_nameOfCheckinglatestVariant);

            if (checkFunction.Text.Contains(Variables.langNET1) || checkFunction.Text.Contains(Variables.langNET2)
                || checkFunction.Text.Contains(Variables.langNET3) || checkFunction.Text.Contains(Variables.langNET4))
            {
                return true;
            }
            else
            {
                return false;
            }            
                    
        }
    }
}
