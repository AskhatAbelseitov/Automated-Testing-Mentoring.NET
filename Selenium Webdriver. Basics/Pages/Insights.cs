using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;
using Selenium_Webdriver._Basics.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Selenium_Webdriver._Basics.Pages
{
    class Insights
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private IWebDriver driver;
        private readonly By _clickOnInsightsTab = By.CssSelector("a.top-navigation__item-link[href='/insights']");
        private readonly By _rightArrowButton = By.XPath("//div[@class='slider__navigation bg-bright-blue-gradient']/button[@class='slider__right-arrow']");
        //private readonly By _articleNameFirstPart = By.XPath("(//div[@class='text-ui-23']/p[@class='scaling-of-text-wrapper']//span[@class='museo-sans-light'])[1]");
        //private readonly By _articleNameSecondPart = By.XPath("(//div[@class='text-ui-23']/p[@class='scaling-of-text-wrapper']//span[@class='museo-sans-500'])[1]");
        private readonly By _buttonReadMore = By.XPath("(//div/a[@href='https://www.epam.com/insights/blogs/breaking-down-two-techniques-to-stay-ahead-of-cybersecurity-threats'])[2]");
        private readonly By _nameOfCheckingArticle = By.XPath("(//div//p//span[@class='museo-sans-light'])[1]");

      
        public Insights(IWebDriver driver)
        {
            this.driver = driver;
        }

        public Insights InsightsTabOpen()
        {
            try
            {
                Waits.WaitElement(driver, _clickOnInsightsTab);
                driver.FindElement(_clickOnInsightsTab).Click();
                log.Info("'Insights' tab is opened");
               
            }
            catch (Exception)
            {
                log.Error("'Insights' tab isn't opened");
            }
            return this;
        }

        public Insights CorouselSwipe()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0, 500)");

            try
            {
                Waits.WaitElement(driver, _rightArrowButton);
                driver.FindElement(_rightArrowButton).Click();
                driver.FindElement(_rightArrowButton).Click();

                //var articleNameRememberFirstPart = driver.FindElement(_articleNameFirstPart).Text;
                //var articleNameRememberSecondPart = driver.FindElement(_articleNameSecondPart).Text;   

                Waits.WaitElement(driver, _buttonReadMore);
                driver.FindElement(_buttonReadMore).Click();

                Assert.Multiple(() =>
                {
                    Assert.That(driver.FindElement(_nameOfCheckingArticle).Text, Does.Contain(Variables.articleNameFirstPart));
                    Assert.That(driver.FindElement(_nameOfCheckingArticle).Text, Does.Contain(Variables.articleNameSecondPart));
                });

                log.Info("Requiered topic is checked");
            }
            catch (Exception)
            {
                log.Error("Error due to the matching of headers");
            }
            return this;
        } 
               
    }
}

