using OpenQA.Selenium;
using TestProject.Utils;

namespace ApiTests.Tests.UI
{
    public class BaseTest
    {
        public void ClickOnElement(string elementName)
        {
            By elementLocator = By.XPath(string.Format(XpathPatterns.preciseTextXpath, elementName));
            Browser.GetDriver().FindElement(elementLocator).Click();
        }

        protected static readonly string partialTextXpath = "//*[contains(text(),'{0}')]";

        [SetUp]
        public static void Setup()
        {
            try
            {
                Browser.GetDriver().Navigate().GoToUrl(ConfigReader.GetConfigValue("webUIUrl"));
            }
            catch (Exception e)
            {
                Console.WriteLine("Error encountered during page navigation: " + e.Message);
            }
        }

        [TearDown]
        public void TearDown() => Browser.GetDriver().Quit();
    }
}
