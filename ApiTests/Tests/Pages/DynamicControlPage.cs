using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Utils;

namespace TestProject.Tests.Pages
{
    internal class DynamicControlsPage
    {
        private static readonly By dynamicControl0 = By.XPath(string.Format(XpathPatterns.preciseTextXpath, "Dynamic Controls"));
        private static readonly By dynamicControl = By.XPath(string.Format(XpathPatterns.dynamicControl, "Dynamic Controls"));
        private static readonly By enableBtn = By.XPath(string.Format(XpathPatterns.enableBtn, "enable button"));
        private static readonly By inputField = By.XPath(string.Format(XpathPatterns.inputField, "input"));
        private static readonly string randomValue = Guid.NewGuid().ToString();
        string text = "automation class";
        public void ClickOnEnable()
        {
            Browser.GetDriver().FindElement(enableBtn).Click();
        }
        //input randomly generated text
        public void enterText()
        {
            Browser.GetDriver().FindElement(inputField).Clear();
            Browser.GetDriver().FindElement(inputField).SendKeys(text+randomValue);
        }
        //assert input is enabled
        public void assertInputIsEnabled()
        {
            Assert.True(Browser.GetDriver().FindElement(inputField).Enabled);
        }
        //assert input text
        public void verifyInputText()
        {
            Assert.True(Browser.GetDriver().FindElement(By.XPath(string.Format(XpathPatterns.preciseTextXpath, text + randomValue))).Displayed,
                    "Text is not displayed");
        }
        


    }
}
