using ApiTests.Tests.UI;
using TestProject.Tests.Pages;


namespace TestProject.Tests.UI
{
    internal class IFrameTests : BaseTest
    {
        readonly MainPage mainPage = new MainPage();
        readonly FramesPage framesPage = new FramesPage();
        readonly IframePage iframePage = new IframePage();

        [Test]
        public void IFrameTest()
        {
            mainPage.ClickOnFramesButton();
            framesPage.ClickOnIframeButton();
            iframePage.SwitchToIframe();
            iframePage.SendRandomTextToTextField();
            Assert.That(iframePage.GetPrintedTextBeforeClear(), Is.True, "Printed text is not expected");
            iframePage.SwitchFromIframe();
            iframePage.ClickOnEditButtonInIframe();
            iframePage.ClickOnUndoButton();
            iframePage.SwitchToIframe();
            Assert.That(iframePage.GetPrintedTextAfterClearTextField(), Is.EqualTo(iframePage.GetInitText()), 
                $"Printed text is not initial value '{iframePage.GetInitText()}'");
        }
    }
}
