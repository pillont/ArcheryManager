using TechTalk.SpecFlow;

namespace ArcheryManager.DroidTest.StepDefinition
{
    [Binding]
    public class TimeChangeFeaturesSteps
    {
        [Then(@"un picker s'ouvre")]
        public void AlorsUnPickerSOuvre()
        {
            TestSetting.App.WaitForElement(e => e.Id("select_dialog_listview"));
        }

        [When(@"je selectionne (.*) dans le picker")]
        public void QuandJeSelectionneDansLePicker(int p0)
        {
            TestSetting.App.ScrollDownTo(e => e.Text(p0.ToString()));
            TestSetting.App.Tap(e => e.Text(p0.ToString()));
        }
    }
}
