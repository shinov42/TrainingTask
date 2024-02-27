using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Utils;

namespace TestProject.Tests.Pages
{
    internal class MainPage
    {
        private static readonly By dynamicControl = By.XPath(string.Format(XpathPatterns.preciseTextXpath, "Dynamic Controls"));

        public void ClickOnDynamicControl()
        {
            Browser.GetDriver().FindElement(dynamicControl).Click();
        }
    }
}
