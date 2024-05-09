using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using TestProject.Utils;

namespace TestProject.Tests.Pages
{
    public class DynamicControlsPage
    {
        private static readonly By enableBtn = By.XPath(string.Format(XpathPatterns.preciseTextXpath, "Enable"));
        private static readonly By disableBtn = By.XPath(string.Format(XpathPatterns.preciseTextXpath, "Disable"));
        private static readonly By inputField = By.XPath(string.Format(XpathPatterns.typeText));

        public void ClickOnEnableBtn()
        {
            Browser.GetDriver().FindElement(enableBtn).Click();
        }

        public void WaitForEnableBtn()
        {
            WaitUtils.wait.Until(ExpectedConditions.ElementToBeClickable(enableBtn));
        }

        public void WaitForDisableBtn()
        {
            WaitUtils.wait.Until(ExpectedConditions.ElementIsVisible(disableBtn));
        }

        public bool CheckIfButtonIsEnabled()
        {
            return Browser.GetDriver().FindElement(disableBtn).Enabled;
        }

        public void EnterTextInInputField(string randomValue)
        {
            Browser.GetDriver().FindElement(inputField).SendKeys(randomValue);
        }

        public string GetAttributeOfInputField()
        {
            return Browser.GetDriver().FindElement(inputField).GetAttribute("value");
        }
    }
}
