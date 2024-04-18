using ApiTests.Tests.UI;
using OpenQA.Selenium;
using TestProject.Utils;

namespace TestProject.Tests.Pages
{
    internal class IframePage : BaseTest
    {
        private static readonly By textField = By.XPath("//*[@data-id='mce_0']");
        private static readonly By editBtn = By.XPath(string.Format(XpathPatterns.preciseTextXpath, "Edit"));
        private static readonly By undoBtn = By.XPath(string.Format(XpathPatterns.preciseTextXpath, "Undo"));
        private static readonly string initText = "Your content goes here.";
        private static readonly string frameName = "mce_0_ifr";

        public void SwitchToIframe()
        {
            Browser.GetDriver().SwitchTo().Frame(frameName);
        }

        public void ClickOnEditButtonInIframe()
        {
            Browser.GetDriver().FindElement(editBtn).Click();
        }

        public void SendRandomTextToTextField()
        {
            Browser.GetDriver().FindElement(textField).SendKeys(GetRandomValue());
        }

        public void SwitchFromIframe()
        {
            Browser.GetDriver().SwitchTo().DefaultContent();
        }

        public void ClickOnUndoButton()
        {
            Browser.GetDriver().FindElement(undoBtn).Click();
        }

        public string GetPrintedTextAfterClearTextField()
        {
            string printedTextAfterClear = Browser.GetDriver().FindElement(textField).Text;
            return printedTextAfterClear;
        }

        public bool GetPrintedTextBeforeClear()
        {
            var printedTextSum = Browser.GetDriver().FindElement(By.XPath(string.Format(XpathPatterns.preciseTextXpath, GetInitText() + GetRandomValue())));
            bool isDisplayed = printedTextSum.Displayed;
            return isDisplayed;
        }

        public string GetInitText()
        {
            return initText;
        }
    }
}
