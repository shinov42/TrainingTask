using ApiTests.Tests.UI;
using OpenQA.Selenium;
using TestProject.Tests.Pages;
using TestProject.Utils;
using static System.Net.Mime.MediaTypeNames;

namespace TestProject.Tests.UI
{
    internal class IFrameTests : BaseTest
    {
        //private static readonly By framesBtn = By.XPath(string.Format(XpathPatterns.preciseTextXpath, "Frames"));
        // private static readonly By iframeBtn = By.XPath(string.Format(XpathPatterns.preciseTextXpath, "iFrame"));
        //private static readonly By editBtn = By.XPath(insert locator here);
        private static readonly By framesBtn = By.XPath(string.Format("//*[@href=\"/frames\"]", "Frames"));
        private static readonly By iframeBtn = By.XPath(string.Format("//a[@href=\"/iframe\"]", "iFrame"));
        private static readonly By undoBtn = By.XPath(string.Format("//div[@class=\"tox-collection__item-label\"])[1]", "textField"));
        private static readonly By editBtn = By.XPath(string.Format("//button[@class=\"tox-mbtn tox-mbtn--select\"])[2]", "editBtn"));
        private static readonly By textField = By.Id(string.Format("id=\"tinymce\"", "textField"));
        //private static readonly By undoBtn = By.XPath(insert locator here);
        private static readonly string randomValue = Guid.NewGuid().ToString();
        private static readonly string initText = "Your content goes here.";

        [Test]
        public void IFrameTest()
        {
            MainPage mainPage = new MainPage();
            IFramePage iframePage= new IFramePage();
            mainPage.ClickOnFrames();
            iframePage.ClickOnIframe();
            //input text to the textfield
            iframePage.inputRandomText();
            iframePage.verifyIfRandomTextIsDisplayed();
            //driver.FindElement(editBtn).Click();
            iframePage.clickEditBtn();
            //driver.FindElement(undoBtn).Click();
            iframePage.clickEditBtn();
            //assert text is not displayed
            iframePage.verifyUndo();

        }
    }
}
