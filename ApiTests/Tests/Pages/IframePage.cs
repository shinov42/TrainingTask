using ApiTests.Tests.UI;
using OpenQA.Selenium;
using TestProject.Utils;

namespace TestProject.Tests.Pages
{
    public class IframePage : BaseTest
    {
        private static readonly By textField = By.XPath("//*[@data-id='mce_0']");
        private static readonly By editBtn = By.XPath(string.Format(XpathPatterns.preciseTextXpath, "Edit"));
        private static readonly By undoBtn = By.XPath(string.Format(XpathPatterns.preciseTextXpath, "Undo"));
        private static readonly string frameName = "mce_0_ifr";
        public void SwitchToIframe() => Browser.GetDriver().SwitchTo().Frame(frameName);
        public void ClickOnEditButtonInIframe() => Browser.GetDriver().FindElement(editBtn).Click();
        public void SwitchFromIframe() => Browser.GetDriver().SwitchTo().DefaultContent();
        public void ClickOnUndoButton() => Browser.GetDriver().FindElement(undoBtn).Click();

        public void SendRandomTextToTextField()
        {
            var randomText = RandomUtils.GetRandomValue();
            Browser.GetDriver().FindElement(textField).SendKeys(randomText);
        }

        public string GetPrintedTextAfterClearTextField()
        {
            string printedTextAfterClear = Browser.GetDriver().FindElement(textField).Text;
            return printedTextAfterClear;
        }

        public bool GetPrintedTextBeforeClear()
        {
            var randomText = RandomUtils.GetRandomValue();
            var printedTextSum = Browser.GetDriver().FindElement(By.XPath(string.Format(XpathPatterns.preciseTextXpath,
                ConfigReader.GetTestDataValue("initText") + randomText)));
            bool isDisplayed = printedTextSum.Displayed;
            return isDisplayed;
        }
    }
}
