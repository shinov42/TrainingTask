using TestProject.Utils;

namespace ApiTests.Tests.UI
{
    internal class BaseTest
    {
        protected static readonly string partialTextXpath = "//*[contains(text(),'{0}')]";

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
