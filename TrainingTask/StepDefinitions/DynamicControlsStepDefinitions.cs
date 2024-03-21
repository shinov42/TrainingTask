
using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TrainingTask.Pages;
using TrainingTask.Utils;

namespace TrainingTask.StepDefinitions
{
    [Binding]
    public class DynamicControlsStepDefinitions
    {
        IWebDriver driver;
        MainPage mainPage;
        DynamicControlsPage dynamicControlsPage;
        IObjectContainer objectcontainer;
        ScenarioContext scenarioContext;
        public DynamicControlsStepDefinitions(IWebDriver driver, ScenarioContext scenarioContext, IObjectContainer objectcontainer)
        {
            this.driver = driver;
            this.scenarioContext = scenarioContext;
            this.objectcontainer = objectcontainer;
            mainPage=objectcontainer.Resolve<MainPage>();
            dynamicControlsPage=objectcontainer.Resolve<DynamicControlsPage>();
        }
        [Given(@"I launch the app url")]
        public void GivenILaunchTheAppUrl()
        {
            Thread.Sleep(5000);
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
