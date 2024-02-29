using ApiTests.Tests.UI;
using OpenQA.Selenium;
using TestProject.Tests.Pages;
using TestProject.Utils;
using Assert = NUnit.Framework.Assert;

namespace TestProject.Tests.UI
{
    internal class DynamicControlsTests : BaseTest
    {
        private static readonly By dynamicControl = By.XPath(string.Format("//a[@href=\"/dynamic_controls\"]", "Dynamic Controls"));
        private static readonly By enableBtn = By.XPath(string.Format("//button[@onclick=\"swapInput()\"]", "Enable"));
        private static readonly By inputField = By.Id(string.Format("id=\"input-example\""));
        string text = "automation class";

        [Test]
        public void DynamicControlsTest()
        {
            MainPage mainPage = new MainPage();
            mainPage.ClickOnDynamicControl();
            Browser.GetDriver().FindElement(enableBtn).Click();

            Browser.GetDriver().FindElement(dynamicControl).Click();
            Browser.GetDriver().FindElement(enableBtn).Click();
            //assert input is enabled
            Assert.True(Browser.GetDriver().FindElement(inputField).Enabled);
            //input randomly generated text
            Browser.GetDriver().FindElement(inputField).Clear();
            Browser.GetDriver().FindElement(inputField).SendKeys(text);

            //assert input text
            Assert.True(Browser.GetDriver().FindElement(inputField).Displayed);

        }
        /* public void AssertInoutIsEnabled()
         {

             Assert.IsTrue(driver.FindElement(inputField).Enabled);

         }
         public void enterText(string text)
         {

             driver.FindElement(inputField).Clear();
             driver.FindElement(inputField).SendKeys(text);

             Assert.That(text, Is.EqualTo("automationClass"));

         }
        */
    }

}
