using ApiTests.Tests.UI;
using TestProject.Tests.Pages;
using TestProject.Utils;
using NUnit.Framework;
using SpecFlowProject4.StepDefinitions;

namespace DynamicControlsStepDefinitions
{
    [Binding]
    internal class DynamicControlsStepDefinitions : SetUp
    {
        readonly DynamicControlsPage dynamicControlsPage = new();
        readonly BaseTest baseTest = new();
        public DynamicControlsStepDefinitions(ScenarioContext _scenarioContext) : base(_scenarioContext)
        {
        }

        [Given(@"I Click '(.*)' button")]
        public void GivenIClickButton(string Enable)
        {
            baseTest.ClickOnElement(Enable);
            dynamicControlsPage.WaitForDisableBtn();
        }

        [Then(@"Enable/disable input is enabled")]
        public void ThenEnableDisableInputIsEnabled()
        {
            Assert.That(dynamicControlsPage.CheckIfButtonIsEnabled, Is.True);
        }

        [When(@"I Send random text '(.*)' to Enable/disable input")]
        public void WhenISendRandomTextToEnableDisableInput(string _randomText)
        {
            var randomText = RandomUtils.GetRandomValue();
            dynamicControlsPage.EnterTextInInputField(randomText);
            scenarioContext[_randomText] = randomText;
        }

        [Then(@"Random text '(.*)' is displayed")]
        public void ThenRandomTextIsDisplayed(string _randomText)
        {
            var randomText = scenarioContext[_randomText];
            var printedTextFromAttribute = dynamicControlsPage.GetAttributeOfInputField();
            Assert.That(randomText, Is.EqualTo(printedTextFromAttribute),
                $"Printed text '{printedTextFromAttribute}' is not what was inputted '{randomText}'");
        }
    }
}
