using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingTask.Utils;

namespace TrainingTask.Pages
{
    internal class IFramePage
    {
        IWebDriver driver;
        private static readonly long maxWait = ConfigReader.GetConfigTestDataValue("maxWait");
        private static readonly By dynamicControl = By.XPath(string.Format(XpathPatterns.preciseTextXpath, "Dynamic Controls"));
        private static readonly By iFrame = By.XPath(string.Format("//a[@href='/iframe']", "iFrame btton"));
        private static readonly By undoBtn = By.XPath(string.Format("//div[@class='tox-collection__item-label'])[1]", "textField"));
        private static readonly By editBtn = By.XPath(string.Format("//div[@class='tox-collection__item-label'])[1]", "editBtn"));
        private static readonly By textField = By.XPath(string.Format("id='tinymce'", "textField"));
        private static readonly string randomValue = Guid.NewGuid().ToString();
        private static readonly string initText = "Your content goes here.";

        public IFramePage(IWebDriver driver)
        {

            this.driver = driver;
        }
        public void ClickOnIframe()
        {
           driver.FindElement(iFrame).Click();
           
        }

        public void inputRandomText()
        {
           driver.FindElement(textField).Clear();
           driver.FindElement(textField).SendKeys(initText + randomValue);

        }
        public bool verifyIfRandomTextIsDisplayed()
        {
            Assert.True(driver.FindElement(By.XPath(string.Format("id='tinymce'", initText + randomValue))).Displayed,
                    "Text is not displayed");
            return false;
        }
        public void clickUndoBtn()
        {
            
            driver.FindElement(undoBtn).Click();
           
        }
        public void clickEditBtn()
        {
           driver.FindElement(editBtn).Click();
        }
        public bool verifyUndo()
        {  //assert text is not displayed
            var textFieldText = Browser.GetDriver().FindElement(textField).Text;
            Assert.That(textFieldText, Is.EqualTo(initText));
            return false;
        }
    }
}
