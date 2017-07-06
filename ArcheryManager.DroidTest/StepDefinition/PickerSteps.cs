<<<<<<< HEAD
﻿using System.Linq;
=======
﻿using System;
>>>>>>> test on the time selector
using TechTalk.SpecFlow;

namespace ArcheryManager.DroidTest.StepDefinition
{
    [Binding]
    public class TimeChangeFeaturesSteps
    {
        [When(@"je selectionne (.*) dans le picker")]
        public void QuandJeSelectionneDansLePicker(int p0)
        {
<<<<<<< HEAD
            TestSetting.App.ScrollDownTo(e => e.Text(p0.ToString()));
            TestSetting.App.Tap(e => e.Text(p0.ToString()));
        }

        [Then(@"un picker s'ouvre")]
        public void AlorsUnPickerSOuvre()
        {
            TestSetting.App.WaitForElement(e => e.Id("select_dialog_listview"));
=======
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"un picker s'ouvre avec (.*) de selectionné")]
        public void AlorsUnPickerSOuvreAvecDeSelectionne(int p0)
        {
            ScenarioContext.Current.Pending();
>>>>>>> test on the time selector
        }
    }
}
