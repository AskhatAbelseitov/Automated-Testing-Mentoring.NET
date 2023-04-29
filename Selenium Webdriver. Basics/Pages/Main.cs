using OpenQA.Selenium;
using Selenium_Webdriver._Basics;
using Selenium_Webdriver._Basics.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Selenium_Webdriver._Basics.Classes;
using log4net;
using log4net.Config;
using NUnit.Framework.Internal;
using OpenQA.Selenium.Support.Extensions;

namespace Selenium_Webdriver._Basics.Pages
{
    
    class MainPage    
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        private IWebDriver driver;

        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        
        public MainPage MainPageOpen()
        {
            try
            {
                driver.Navigate().GoToUrl(Variables.urlEpam);
                driver.Manage().Window.Maximize();
                log.Info("Web site is opened successfully");                
            }
            catch (Exception)
            {
                log.Fatal("Web site isn't opened");
            }             
            return this;
        }

    }
 }

