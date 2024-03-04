using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingTask.Tests.Pages;
using TrainingTask.Utils;

namespace TrainingTask.Tests.UI.StepDedinitions
{
    [Binding]
    public  class DynamicControlsStepDefinitions
    {
        MainPage mainPage = new MainPage();
        DynamicControlsPage dynamicControlsPage = new DynamicControlsPage();

        [Given(@"I launch the app url")]
        public void GivenILaunchTheAppUrl()
        {
            Browser.GetDriver().Navigate().GoToUrl(ConfigReader.GetConfigValue("webUIUrl"));
        }

        [When(@"I click Dynamic Controls link on the Main page")]
        public void WhenIClickDynamicControlsLinkOnTheMainPage()
        {
            mainPage.ClickOnDynamicControl();
        }

        [When(@"I Click Enable button")]
        public void WhenIClickEnableButton()
        {
            dynamicControlsPage.ClickOnEnable();
        }
        [Then(@"Verify that the Enable/disable input field is enabled")]
        public void ThenVerifyThatTheEnableDisableInputFieldIsEnabled()
        {
            //assert input is enabled
            dynamicControlsPage.assertInputIsEnabled();
        }
        [When(@"I send random text to Enable/disable input field")]
        public void WhenISendRandomTextToEnableDisableInputField()
        {
            //input randomly generated text
            dynamicControlsPage.enterText();
        }

        [Then(@"Random text is displayed")]
        public void ThenRandomTextIsDisplayed()
        {
            //assert input text
            dynamicControlsPage.verifyInputText();
        }


    }
}
