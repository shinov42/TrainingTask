using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Utils
{
    internal class Browser
    {
        private static WebDriver driver = null;
        private static WebDriverWait wait = null;
        private static readonly long maxWait = ConfigReader.GetConfigTestDataValue("maxWait");

        public static WebDriver GetDriver()
        {
            if (driver is null)
            {
                var chromeOptions = new ChromeOptions();
                chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");
                driver = new ChromeDriver(chromeOptions);
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(maxWait));
                driver.Manage().Window.Maximize();
            }
            return driver;
        }
    }
}
