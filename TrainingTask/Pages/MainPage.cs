using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingTask.Utils;

namespace TrainingTask.Tests.Pages
{
    internal class MainPage
    {
        private static readonly By dynamicControl0 = By.XPath(string.Format(XpathPatterns.preciseTextXpath, "Dynamic Controls"));
        private static readonly By dynamicControl = By.XPath(string.Format(XpathPatterns.dynamicControl, "Dynamic Controls"));
        private static readonly By frames = By.XPath(string.Format(XpathPatterns.framesBtn1, "frames button"));
        public void ClickOnDynamicControl()
        {
            Browser.GetDriver().FindElement(dynamicControl).Click();
        }
        public void ClickOnFrames()
        {
            Browser.GetDriver().FindElement(frames).Click();
        }

    }
}
