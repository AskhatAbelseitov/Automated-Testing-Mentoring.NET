using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Docker.DotNet.Models;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Windows.Markup;
using OpenQA.Selenium.Support.Extensions;

namespace Selenium_Webdriver._Basics.Classes
{
    class ScreenshotMaker
    {
        public static string NewScreenshotName
        {
            get { return "_" + DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss-fff") + "." + Screenshot; }
        }

        public static ScreenshotImageFormat Screenshot
        {
            get { return ScreenshotImageFormat.Png; }
        }        
    }
}

