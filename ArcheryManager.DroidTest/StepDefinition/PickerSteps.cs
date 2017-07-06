using System;
using TechTalk.SpecFlow;

namespace ArcheryManager.DroidTest.StepDefinition
{
    [Binding]
    public class TimeChangeFeaturesSteps
    {
        [When(@"je selectionne (.*) dans le picker")]
        public void QuandJeSelectionneDansLePicker(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"un picker s'ouvre avec (.*) de selectionné")]
        public void AlorsUnPickerSOuvreAvecDeSelectionne(int p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
