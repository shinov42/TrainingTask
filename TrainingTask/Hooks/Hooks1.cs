using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using TrainingTask.Utils;

namespace TrainingTask.Hooks
{
    [Binding]
    public sealed class Hooks1
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        private static WebDriver driver = null;
        private static WebDriverWait wait = null;
        private static readonly long maxWait = ConfigReader.GetConfigTestDataValue("maxWait");
        private readonly IObjectContainer container;
        private readonly ScenarioContext scenarioContext;
        
        public Hooks1(IObjectContainer container, ScenarioContext scenarioContext)
        {
            this.container = container;
            this.scenarioContext = scenarioContext;
        }

        [BeforeScenario("@PlayerLogin")]
        public void BeforeScenarioWithTag()
        {
            Console.WriteLine("testing with hooks");
        }

        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");
            driver = new ChromeDriver(chromeOptions);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(maxWait));
            driver.Manage().Window.Maximize();
            driver.Url = ConfigReader.GetConfigValue("webUIUrl");
            container.RegisterInstanceAs<IWebDriver>(driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            var driver=container.Resolve<IWebDriver>();
            if (driver != null)
            {
                driver.Quit();
            }
            else
            {
                PetStoreApiUtils.DeletePetById(ConfigReader.GetTestDataValue("petId"));
            }
        }
    }
}