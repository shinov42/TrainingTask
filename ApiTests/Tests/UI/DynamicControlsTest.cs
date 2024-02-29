using ApiTests.Tests.UI;
using OpenQA.Selenium;
using TestProject.Tests.Pages;
using TestProject.Utils;

namespace TestProject.Tests.UI
{
    internal class DynamicControlsTests : BaseTest
    {
        private static readonly By enableBtn = By.XPath(string.Format(XpathPatterns.preciseTextXpath, "Enable"));

        [Test]
        public void DynamicControlsTest()
        {
            MainPage mainPage = new MainPage();
            mainPage.ClickOnDynamicControl();
            Browser.GetDriver().FindElement(enableBtn).Click();
            //assert input is enabled
            //input randomly generated text
            //assert input text
        }
    }
    
}
