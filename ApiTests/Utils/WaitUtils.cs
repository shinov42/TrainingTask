using OpenQA.Selenium.Support.UI;

namespace TestProject.Utils
{
    internal class WaitUtils
    {
        public static WebDriverWait wait = new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(100));
    }
}
