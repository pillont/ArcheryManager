using TechTalk.SpecFlow;

namespace ArcheryManager.DroidTest.StepDefinition
{
    [Binding]
    public class ResultPageSteps
    {
        [Then(@"une vue de bilan de compté s'ouvre")]
        public void AlorsUneVueDeBilanDeCompteSOuvre()
        {
            TestSetting.App.WaitForElement("resultPage");
        }
    }
}
