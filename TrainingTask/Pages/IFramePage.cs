using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingTask.Utils;

namespace TrainingTask.Tests.Pages
{
    internal class IFramePage
    {
        private static readonly By dynamicControl = By.XPath(string.Format(XpathPatterns.preciseTextXpath, "Dynamic Controls"));
        private static readonly By iFrame = By.XPath(string.Format(XpathPatterns.iframeBtn1, "iFrame btton"));
        private static readonly By undoBtn = By.XPath(string.Format(XpathPatterns.undoBtn1, "textField"));
        private static readonly By editBtn = By.XPath(string.Format(XpathPatterns.editBtn1, "editBtn"));
        private static readonly By textField = By.XPath(string.Format(XpathPatterns.textField1, "textField"));
        private static readonly string randomValue = Guid.NewGuid().ToString();
        private static readonly string initText = "Your content goes here.";

        public void ClickOnIframe()
        {
            Browser.GetDriver().FindElement(iFrame).Click();
            Thread.Sleep(5000);
        }

        public void inputRandomText()
        {
            Browser.GetDriver().FindElement(textField).Clear();
            Browser.GetDriver().FindElement(textField).SendKeys(initText + randomValue);

        }
        public void verifyIfRandomTextIsDisplayed()
        {
            Assert.True(Browser.GetDriver().FindElement(By.XPath(string.Format(XpathPatterns.textField1, initText + randomValue))).Displayed,
                    "Text is not displayed");
        }
        public void clickUndoBtn()
        {
            
            Browser.GetDriver().FindElement(undoBtn).Click();
           
        }
        public void clickEditBtn()
        {
            Browser.GetDriver().FindElement(editBtn).Click();
        }
        public void verifyUndo()
        {  //assert text is not displayed
            var textFieldText = Browser.GetDriver().FindElement(textField).Text;
            Assert.That(textFieldText, Is.EqualTo(initText));
        }

        public void clickNewDocument()
        {
            Browser.GetDriver().FindElement(By.XPath(string.Format(XpathPatterns.fileBtn))).Click();
            Browser.GetDriver().FindElement(By.XPath(string.Format(XpathPatterns.newPage))).Click();
        }
    }
}
