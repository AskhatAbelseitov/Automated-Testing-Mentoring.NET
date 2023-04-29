using log4net.Config;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using Selenium_Webdriver._Basics.Classes;
using Selenium_Webdriver._Basics.Pages;
using System.Drawing;
using System.Drawing.Imaging;


namespace Selenium_Webdriver._Basics
{
    public class Tests
    {
        private IWebDriver driver;
       
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
        }

        
        [Test]
        public void TestSearchingPositionsViaCareers()
        {
            var pretest = new MainPage(driver);
            pretest.MainPageOpen();
            var test = new Careers(driver);
            test.ProgrammingLanguageFind();
            test.LocationCountryCityFind(Variables.countryLocation, Variables.cityLocation);
            test.FinalFind();
            Assert.That(test.CheckingProgrammingLanguage(), Is.True); 
        }
       

        [Test]
        public void TestSearchingAreaViaMagnifier()
        {
            var pretest = new MainPage(driver);
            pretest.MainPageOpen();
            var test = new Search(driver);
            test.Searching(Variables.areaBlockchain);
            Assert.That(test.ResultChecking, Has.Member(Variables.areaBlockchain));
            Assert.That(test.ResultChecking, Has.Member(Variables.areaCloud));
            Assert.That(test.ResultChecking, Has.Member(Variables.areaAutomation));
        }

      
        [Test]
        public void TestDownloadOverview()
        {
            var pretest = new MainPage(driver);
            pretest.MainPageOpen();
            var test = new About(driver);
            test.AboutTabOpen();
            test.OverviewFileDownload();
        }
        
        

        [Test]
        public void TestInsightsViewing()
        {
            var pretest = new MainPage(driver);
            pretest.MainPageOpen();
            var test = new Insights(driver);
            test.InsightsTabOpen();
            test.CorouselSwipe();
        }


        [TearDown]
        public void ScreenshoMakingn()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed ||
                TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Warning)
            {
                var screenshotPath = Path.Combine(Environment.CurrentDirectory, "Display" + ScreenshotMaker.NewScreenshotName);
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                screenshot.SaveAsFile(screenshotPath, ScreenshotMaker.Screenshot);
            }

            Thread.Sleep(5000);
            driver.Close();

        }
    }
}