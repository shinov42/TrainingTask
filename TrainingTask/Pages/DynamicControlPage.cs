using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TrainingTask.Utils;

namespace TrainingTask.Pages
{
    internal class DynamicControlsPage
    {
        IWebDriver driver;
        private static readonly long maxWait = ConfigReader.GetConfigTestDataValue("maxWait");
        private static WebDriverWait wait = null;
        public DynamicControlsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private static readonly By dynamicControl0 = By.XPath(string.Format(XpathPatterns.preciseTextXpath, "Dynamic Controls"));
        private static readonly By dynamicControl = By.XPath(string.Format(XpathPatterns.dynamicControl, "Dynamic Controls"));
        private static readonly By enableBtn = By.XPath(string.Format("(//*[@type='button'])[2]", "enable button"));
        private static readonly By inputField = By.XPath(string.Format("//input[@type='text']", "input"));
        private static readonly string randomValue = Guid.NewGuid().ToString();
        string text = "automation class";
        
        public void ClickOnEnable()
        {
            driver.FindElement(enableBtn).Click();
            //Thread.Sleep(5000);

        }
        //input randomly generated text
        public void enterText()
        {
           driver.FindElement(inputField).Clear();
          driver.FindElement(inputField).SendKeys(text+randomValue);
        }
        //assert input is enabled
        public bool assertInputIsEnabled()
        {
            //Thread.Sleep(5000);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(maxWait));
            var enable_diabledBtnMsg = driver.FindElement(enableBtn).Text;
            Assert.That(enable_diabledBtnMsg, Is.EqualTo("Disable"));
            return false;
        }
        //assert input text
        public bool verifyInputText()
        {
            Assert.True(driver.FindElement(By.XPath(string.Format(XpathPatterns.inputField1, text + randomValue))).Displayed,
                    "Text is not displayed");
            return false;
        }
        
       

    }
}
