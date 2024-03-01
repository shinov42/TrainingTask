using ApiTests.Tests.UI;
using OpenQA.Selenium;
using TestProject.Tests.Pages;
using TestProject.Utils;
using Assert = NUnit.Framework.Assert;

namespace TestProject.Tests.UI
{
    internal class DynamicControlsTests : BaseTest
    {
        

        [Test]
        public void DynamicControlsTest()
        {
            MainPage mainPage = new MainPage();
            mainPage.ClickOnDynamicControl();
            DynamicControlsPage dynamicControlsPage = new DynamicControlsPage();
           
            dynamicControlsPage.ClickOnEnable();

            //assert input is enabled
            dynamicControlsPage.assertInputIsEnabled();

            //input randomly generated text
            dynamicControlsPage.enterText();

            //assert input text
            dynamicControlsPage.verifyInputText();

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
