using ApiTests.Tests.UI;
using OpenQA.Selenium;
using TestProject.Utils;
using static System.Net.Mime.MediaTypeNames;

namespace TestProject.Tests.UI
{
    internal class IFrameTests : BaseTest
    {
        private static readonly By framesBtn = By.XPath(string.Format(XpathPatterns.preciseTextXpath, "Frames"));
        private static readonly By iframeBtn = By.XPath(string.Format(XpathPatterns.preciseTextXpath, "iFrame"));
        //private static readonly By editBtn = By.XPath(insert locator here);
        private static readonly By framesBtn = By.XPath(string.Format("//*[@href=\"/frames\"]", "Frames"));
        private static readonly By iframeBtn = By.XPath(string.Format("//a[@href=\"/iframe\"]", "iFrame"));
        private static readonly By undoBtn = By.XPath(string.Format("//div[@class=\"tox-collection__item-label\"])[1]", "textField"));
        private static readonly By editBtn = By.XPath(string.Format("//button[@class=\"tox-mbtn tox-mbtn--select\"])[2]", "editBtn"));
        private static readonly By textField=By.Id(string.Format("id=\"tinymce\"","textField"));
        //private static readonly By undoBtn = By.XPath(insert locator here);
        private static readonly string randomValue = Guid.NewGuid().ToString();
        private static readonly string initText =  "Your content goes here.";

        [Test]
        public void IFrameTest()
        {
            Browser.GetDriver().FindElement(framesBtn).Click();
            Browser.GetDriver().FindElement(iframeBtn).Click();
            IFrameTests frameTests = new IFrameTests();
            Console.WriteLine(initText);

            driver.FindElement(framesBtn).Click();
            driver.FindElement(iframeBtn).Click();
            //input text to the textfield
            Assert.True(Browser.GetDriver().FindElement(By.XPath(string.Format(XpathPatterns.preciseTextXpath, initText + randomValue))).Displayed,
                    "Text is not displayed");
            driver.FindElement(textField).Clear();
            driver.FindElement(textField).SendKeys("This is my content");

           // Assert.True(driver.FindElement(By.XPath(string.Format(initText, initText + randomValue))).Displayed,
             //      "Text is not displayed");

            //driver.FindElement(editBtn).Click();
            driver.FindElement(editBtn).Click();
            //driver.FindElement(undoBtn).Click();
            driver.FindElement(undoBtn).Click();
            //assert text is not displayed
            var textFieldText=driver.FindElement(textField).Text;

           // Assert.True((textFieldText), "Text is not displayed");
            Assert.That(textFieldText, Is.EqualTo(initText));
          
        }
    }
}
