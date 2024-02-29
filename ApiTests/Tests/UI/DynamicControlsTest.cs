using ApiTests.Tests.UI;
using OpenQA.Selenium;
using Assert = NUnit.Framework.Assert;
using TestProject.Tests.Pages;
using TestProject.Utils;

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
            DynamicControlsTests dynamicControlsTests = new DynamicControlsTests(); 
            driver.FindElement(dynamicControl).Click();
            driver.FindElement(enableBtn).Click();
            //assert input is enabled
            Assert.IsTrue(driver.FindElement(inputField).Enabled);
            //input randomly generated text
            driver.FindElement(inputField).Clear();
            driver.FindElement(inputField).SendKeys(text);

            //assert input text
            Assert.True(driver.FindElement(inputField).Displayed);

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
