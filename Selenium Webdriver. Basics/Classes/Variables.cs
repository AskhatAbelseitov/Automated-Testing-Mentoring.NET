using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_Webdriver._Basics
{
    class Variables
    {
        public static string urlEpam = "https://www.epam.com/";
        public static string downloadFolder = @"C:\Users\Askhat_Abelseitov\Downloads\";
        public static string downloadFileName = "EPAM_Corporate_Overview_2023.pdf";
        public static string downloadFolderAndFile = @"C:\Users\Askhat_Abelseitov\Downloads\EPAM_Corporate_Overview_2023.pdf";
        public static string articleNameFirstPart = "Two Techniques to Stay Ahead of Cybersecurity";
        public static string articleNameSecondPart = "Threats";

        public static string areaCloudInput { get; } = "CLOUD";
        public static string areaAutomationInput { get; } = "AUTOMATION";
        public static string areaBlockchain { get; } = "Blockchain";
        public static string areaCloud = "Cloud";
        public static string areaAutomation = "Automation";

        public static string countryLocation { get; } = "Argentina";
        public static string cityLocation { get; } = "All Cities in Argentina";

        public static string langNET1 = "C#";
        public static string langNET2 = ".NET";
        public static string langNET3 = "Unity";
        public static string langNET4 = "Xamarin";
    }
}