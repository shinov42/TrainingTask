using ApiTests.Tests.UI;
using OpenQA.Selenium;
using TestProject.Utils;

namespace TestProject.Tests.UI
{
    internal class IFrameTests : BaseTest
    {
        private static readonly By framesBtn = By.XPath(string.Format(XpathPatterns.preciseTextXpath, "Frames"));
        private static readonly By iframeBtn = By.XPath(string.Format(XpathPatterns.preciseTextXpath, "iFrame"));
        //private static readonly By editBtn = By.XPath(insert locator here);
        //private static readonly By undoBtn = By.XPath(insert locator here);
        private static readonly string randomValue = Guid.NewGuid().ToString();
        private static readonly string initText = "Your content goes here.";

        [Test]
        public void IFrameTest()
        {
            Browser.GetDriver().FindElement(framesBtn).Click();
            Browser.GetDriver().FindElement(iframeBtn).Click();
            //input text to the textfield
            Assert.True(Browser.GetDriver().FindElement(By.XPath(string.Format(XpathPatterns.preciseTextXpath, initText + randomValue))).Displayed,
                    "Text is not displayed");

            //driver.FindElement(editBtn).Click();
            //driver.FindElement(undoBtn).Click();

            //assert text is not displayed
        }
    }
}
