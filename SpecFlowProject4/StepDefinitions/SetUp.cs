using TestProject.Utils;

namespace SpecFlowProject4.StepDefinitions
{
    [Binding]
    internal class SetUp: Browser
    {
        protected ScenarioContext scenarioContext;

        [BeforeScenario]
        public void Setup()
        {
            var tags = scenarioContext.ScenarioInfo.Tags;
            if (tags.Contains("ui"))
            { 
                GetDriver().Navigate().GoToUrl(ConfigReader.GetConfigValue("webUIUrl"));
            }
        }
        public SetUp(ScenarioContext _scenarioContext)
        {
            scenarioContext = _scenarioContext;
        }

        [AfterScenario]
        public void AfterScenario(ScenarioContext scenarioContext)
        {
            var tags = scenarioContext.ScenarioInfo.Tags;
            if (tags.Contains("ui"))
            {
                GetDriver().Quit();
            }
        }
    }
}
