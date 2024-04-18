using OpenQA.Selenium;
using TestProject.Utils;

namespace TestProject.Tests.Pages
{
    internal class MainPage
    {
        private static readonly By dynamicControl = By.XPath(string.Format(XpathPatterns.preciseTextXpath, 
            "Dynamic Controls"));
        private static readonly By framesBtn = By.XPath(string.Format(XpathPatterns.preciseTextXpath, "Frames"));        

        public void ClickOnDynamicControl()
        {
            Browser.GetDriver().FindElement(dynamicControl).Click();
        }

        public void ClickOnFramesButton()
        {
            Browser.GetDriver().FindElement(framesBtn).Click();
        }
    }
}
