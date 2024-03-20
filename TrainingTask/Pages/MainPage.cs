using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingTask.Utils;

namespace TrainingTask.Pages
{
    internal class MainPage
    {
       IWebDriver driver;
        private static readonly By dynamicControl0 = By.XPath(string.Format("\"//a[@href='/dynamic_controls']\"", "Dynamic Controls"));
        private static readonly By dynamicControl = By.XPath(string.Format("//a[@href='/dynamic_controls']", "Dynamic Controls"));
        private static readonly By frames = By.XPath(string.Format("//*[@href='/frames']", "frames button"));
        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void ClickOnDynamicControl()
        {
           driver.FindElement(dynamicControl).Click();
        }
        public void ClickOnFrames()
        {
           driver.FindElement(frames).Click();
        }

    }
}
