using OpenQA.Selenium;
using TestProject.Utils;

namespace TestProject.Tests.Pages
{
    internal class FramesPage
    {
        private static readonly By iframeBtn = By.XPath(string.Format(XpathPatterns.preciseTextXpath, "iFrame"));

        public void ClickOnIframeButton()
        {
            Browser.GetDriver().FindElement(iframeBtn).Click();
        }
    }
}
