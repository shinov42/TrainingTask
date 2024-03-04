using ApiTests.Tests.UI;
using OpenQA.Selenium;
using TestProject.Tests.Pages;
using TestProject.Utils;
using static System.Net.Mime.MediaTypeNames;

namespace TestProject.Tests.UI
{
    internal class IFrameTests : BaseTest
    {
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
