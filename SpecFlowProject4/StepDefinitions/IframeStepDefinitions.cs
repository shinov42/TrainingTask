using ApiTests.Tests.UI;
using NUnit.Framework;
using TestProject.Tests.Pages;
using TestProject.Utils;

namespace SpecFlowProject4.StepDefinitions
{
    [Binding]
    internal class IframeStepDefinitions : SetUp
    {
        readonly BaseTest baseTest = new();
        readonly IframePage iframePage = new();
        public IframeStepDefinitions(ScenarioContext _scenarioContext) : base(_scenarioContext)
        {
        }

        [When(@"I Click '(.*)' link on the page")]
        [Given(@"I Click '(.*)' link on the page")]
        public void WhenIClickLinkOnTheMainPage(string elementName)
        {
            baseTest.ClickOnElement(elementName);
        }

        [When(@"I Input random generated text to the text editor and save as '(.*)'")]
        public void WhenIInputRandomGeneratedTextToTheTextEditor(string _randomText)
        {
            iframePage.SwitchToIframe();
            iframePage.SendRandomTextToTextField();
            scenarioContext["randomText"] = _randomText;
        }

        [Then(@"Random text is displayed in Iframe")]
        public void ThenRandomTextIsDisplayedInIframe()
        {
            Assert.That(iframePage.GetPrintedTextBeforeClear(), Is.True, "Printed text is not expected");
        }

        [When(@"I Undo changes with Edit menu")]
        public void WhenIUndoChangesWithEditMenu()
        {
            iframePage.SwitchFromIframe();
            iframePage.ClickOnEditButtonInIframe();
            iframePage.ClickOnUndoButton();
            iframePage.SwitchToIframe();
        }

        [Then(@"Expected text '([^']*)' is displayed in the editor")]
        public void ThenExpectedTextIsDisplayedInTheEditor(string initText)
        {
            Assert.That(iframePage.GetPrintedTextAfterClearTextField(), Is.EqualTo(ConfigReader.GetTestDataValue(initText)),
                $"Printed text is not initial value '{ConfigReader.GetTestDataValue(initText)}'");
        }
    }
}
