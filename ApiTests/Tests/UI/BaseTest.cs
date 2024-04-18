using OpenQA.Selenium.Support.UI;
using TestProject.Utils;

namespace ApiTests.Tests.UI
{
    internal class BaseTest
    {
        protected static readonly string partialTextXpath = "//*[contains(text(),'{0}')]";
        private static readonly string randomValue = Guid.NewGuid().ToString();

        public static string GetRandomValue()
        {
            return randomValue;
        }

        [SetUp]
        public void Setup()
        {
            Browser.GetDriver().Navigate().GoToUrl(ConfigReader.GetConfigValue("webUIUrl"));
        }

        [TearDown]
        public void TearDown()
        {
            Browser.GetDriver().Quit();
        }
    }
}