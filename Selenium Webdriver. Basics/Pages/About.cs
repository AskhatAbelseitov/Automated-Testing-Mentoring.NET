using OpenQA.Selenium;
using Selenium_Webdriver._Basics.Classes;
using System;
using System.Drawing;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework.Constraints;
using log4net;

namespace Selenium_Webdriver._Basics.Pages
{
    class About
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private IWebDriver driver;
        private readonly By _clickOnAboutTab = By.CssSelector("a.top-navigation__item-link[href='/about']");
        private readonly By _downloadButton = By.XPath("//a[@href='https://www.epam.com/content/dam/epam/free_library/EPAM_Corporate_Overview_2023.pdf']");


        public About(IWebDriver driver)
        {
            this.driver = driver;
        }             

        public About AboutTabOpen()
        {
            try
            {
                Waits.WaitElement(driver, _clickOnAboutTab);
                driver.FindElement(_clickOnAboutTab).Click();
                log.Info("'About' tab is opened successfully");
            }
            catch (Exception)
            {
                log.Error("'About' tab isn't opened");               
            }
            return this;
        }

        public About OverviewFileDownload()
        {
            bool fileExists = false;

            ChromeOptions options = new ChromeOptions();
            options.AddUserProfilePreference("download.default_directory", Variables.downloadFolder);

            Waits.WaitSomeInterval();
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0, 2500)");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            try
            {
                Waits.WaitElement(driver, _downloadButton);
                driver.FindElement(_downloadButton).Click();
                log.Info("File is successfully downloaded");
            }
            catch (Exception)
                       
            {
                log.Error("'Download' button isn't clicked");
            }
            
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                        
            wait.Until<bool>(x => fileExists = File.Exists(Variables.downloadFolderAndFile));

            FileInfo fileInfo = new FileInfo(Variables.downloadFolderAndFile);

            Assert.Multiple(() =>
            {
                Assert.That(File.Exists(Variables.downloadFolderAndFile), Is.True);
                Assert.That(Variables.downloadFileName, Is.EqualTo(fileInfo.Name));
            });

            try
            {
                Waits.WaitSomeInterval();
                File.Delete(Variables.downloadFolderAndFile);
                log.Info("Downloaded file is successfully deleted");
            }
            catch (Exception)
            {
                log.Warn("Downloaded file isn't deleted");
            }           
            return this;
        }
    }
}

