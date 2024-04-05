using ApiTests.Tests.UI;
using OpenQA.Selenium;
using TestProject.Utils;


namespace TestProject.Tests.UI
{
    internal class IFrameTests : BaseTest
    {
        private static readonly By framesBtn = By.XPath(string.Format(XpathPatterns.preciseTextXpath, "Frames"));
        private static readonly By iframeBtn = By.XPath(string.Format(XpathPatterns.preciseTextXpath, "iFrame"));
        private static readonly By textField = By.XPath("//*[@data-id='mce_0']");
        private static readonly By editBtn = By.XPath(string.Format(XpathPatterns.preciseTextXpath, "Edit"));
        private static readonly By undoBtn = By.XPath(string.Format(XpathPatterns.preciseTextXpath, "Undo"));
        private static readonly string randomValue = Guid.NewGuid().ToString();
        private static readonly string initText = "Your content goes here.";

        [Test]
        public void IFrameTest()
        {
            Browser.GetDriver().FindElement(framesBtn).Click();
            Browser.GetDriver().FindElement(iframeBtn).Click();
            //input text to the textfield
            Browser.GetDriver().SwitchTo().Frame("mce_0_ifr");
            Browser.GetDriver().FindElement(textField).Click();
            Browser.GetDriver().FindElement(textField).SendKeys(randomValue);
            Assert.That(Browser.GetDriver().FindElement(By.XPath(string.Format(XpathPatterns.preciseTextXpath, 
                initText + randomValue))).Displayed, $"Text '{initText}{randomValue}' is not displayed");
            Browser.GetDriver().SwitchTo().DefaultContent();
            Browser.GetDriver().FindElement(editBtn).Click();
            Browser.GetDriver().FindElement(undoBtn).Click();
            Browser.GetDriver().SwitchTo().Frame("mce_0_ifr");
            string printedTextAfterClear = Browser.GetDriver().FindElement(textField).Text;
            //assert input text
            Assert.That(printedTextAfterClear, Is.EqualTo(initText), $"Printed text is not initial value'{initText}'");
        }
    }
}
