using TestProject.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;

namespace ApiTests.Tests.UI
{
    internal class BaseTest
    {
        protected WebDriver driver;

        protected static readonly string preciseTextXpath = "//*[text()='{0}']";
        protected static readonly string partialTextXpath = "//*[contains(text(),'{0}')]";
        protected WebDriverWait wait = null;
        protected static readonly int maxWait = 10;

        [SetUp]
        public void Setup()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");
            driver = new ChromeDriver(chromeOptions);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(maxWait));
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(ConfigReader.GetConfigValue("https://the-internet.herokuapp.com/"));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
