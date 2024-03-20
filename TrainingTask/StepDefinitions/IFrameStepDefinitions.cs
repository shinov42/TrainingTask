using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingTask.Pages;
using TrainingTask.Utils;

namespace TrainingTask.StepDefinitions
{
    [Binding]

    public class IFrameStepDefinitions
    {   IWebDriver driver;
        IObjectContainer objectContainer;
        MainPage mainPage;
        IFramePage iframePage;

        public IFrameStepDefinitions(IWebDriver driver, IObjectContainer objectContainer)
        {
            this.driver = driver;
            this.objectContainer = objectContainer;
            mainPage=objectContainer.Resolve<MainPage>();
            iframePage=objectContainer.Resolve<IFramePage>();

        }

        [When(@"I click Frames link on the Main page")]
        public void WhenIClickFramesLinkOnTheMainPage()
        {
            mainPage.ClickOnFrames();
        }

        [When(@"I click iFrame link on the Frames page")]
        public void WhenIClickIFrameLinkOnTheFramesPage()
        {
            iframePage.ClickOnIframe();
        }

        [When(@"I Input random generated text to the text editor")]
        public void WhenIInputRandomGeneratedTextToTheTextEditor()
        {
            //input text to the textfield
            iframePage.inputRandomText();
            iframePage.verifyIfRandomTextIsDisplayed();
        }

        [When(@"I click on the edit button")]
        public void WhenIClickOnTheEditButton()
        {
            iframePage.clickEditBtn();
        }

        [When(@"I click on the Undo Button")]
        public void WhenIClickOnTheUndoButton()
        {
            iframePage.clickEditBtn();
        }

        [Then(@"Your content goes here text is displayed in the editor")]
        public void ThenYourContentGoesHereTextIsDisplayedInTheEditor()
        {
            iframePage.verifyUndo();
        }

    }
}
