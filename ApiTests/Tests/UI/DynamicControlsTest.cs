using ApiTests.Tests.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TestProject.Tests.Pages;
using TestProject.Utils;

namespace TestProject.Tests.UI
{
    internal class DynamicControlsTests : BaseTest
    {
        readonly MainPage mainPage = new MainPage();
        private static readonly By enableBtn = By.XPath(string.Format(XpathPatterns.preciseTextXpath, "Enable"));
        private static readonly By disableBtn = By.XPath(string.Format(XpathPatterns.preciseTextXpath, "Disable"));
        private static readonly By inputField = By.XPath(string.Format(XpathPatterns.typeText));
        private static readonly string randomValue = Guid.NewGuid().ToString();

        [Test]
        public void DynamicControlsTest()
        {
            mainPage.ClickOnDynamicControl();
            WebDriverWait wait = new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(100));
            wait.Until(ExpectedConditions.ElementToBeClickable(enableBtn));
            Browser.GetDriver().FindElement(enableBtn).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(disableBtn));
            //assert input is enabled
            Assert.That(Browser.GetDriver().FindElement(disableBtn).Enabled, Is.True);
            //input randomly generated text
            Browser.GetDriver().FindElement(inputField).SendKeys(randomValue);
            string printedText = Browser.GetDriver().FindElement(inputField).GetAttribute("value");
            //assert input text
            Assert.That(randomValue, Is.EqualTo(printedText), $"Printed text '{printedText}' is not" +
                $" what was inputted '{randomValue}'");
        }
    }
}
