using TechTalk.SpecFlow;

namespace ArcheryManager.DroidTest.StepDefinition
{
    [Binding]
    public class GeneralMenuSteps
    {
        [Then(@"je suis dans un menu général")]
        public void AlorsJeSuisDansUnMenuGeneral()
        {
            TestSetting.App.WaitForElement("GeneralMenuTitle");
        }
    }
}
