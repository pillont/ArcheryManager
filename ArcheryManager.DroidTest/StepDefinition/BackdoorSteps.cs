using System;
using TechTalk.SpecFlow;

namespace ArcheryManager.DroidTest.StepDefinition
{
    [Binding]
    public class BackdoorSteps
    {
        [When(@"J'ouvre une page de backdoor")]
        public void WhenJOuvreUnePageDeBackdoor()
        {
            TestSetting.InitTestApplication();
        }

        [When(@"J'ouvre une page de cible fita")]
        public void WhenJOuvreUnePageDeCibleFita()
        {
            TestSetting.InitTestApplication();
            TestSetting.App.Tap("EnglishTargetButton");
        }
    }
}
