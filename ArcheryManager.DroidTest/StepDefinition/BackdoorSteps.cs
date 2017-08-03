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

        [When(@"J'ouvre une page timer")]
        public void WhenJOuvreUnePageTimer()
        {
            TestSetting.InitTestApplication();
            TestSetting.App.Tap("TimerButton");
        }

        [When(@"J'ouvre une page de cible fita")]
        public void WhenJOuvreUnePageDeCibleFita()
        {
            TestSetting.InitTestApplication();
            TestSetting.App.WaitForElement("EnglishTargetButton");
            TestSetting.App.Tap("EnglishTargetButton");
        }

        [When(@"J'ouvre une page zappette")]
        public void QuandJOuvreUnePageZappette()
        {
            TestSetting.InitTestApplication();
            TestSetting.App.Tap("ButtonCounterButton");
        }

        [When(@"J'ouvre une page de menu general")]
        public void QuandJOuvreUnePageDeMenuGeneral()
        {
            TestSetting.InitTestApplication();
            TestSetting.App.Tap("GeneralMenuButton");
        }

        [When(@"J'ouvre une page de sélection de cible")]
        public void QuandJOuvreUnePageDeSelectionDeCible()
        {
            TestSetting.InitTestApplication();
            TestSetting.App.WaitForElement("CounterSelectorButton");
            TestSetting.App.Tap("CounterSelectorButton");
        }

        [Then(@"il y a le titre de backdoor")]
        public void AlorsIlYALeTitreDeBackdoor()
        {
            TestSetting.App.WaitForElement("backdoorTitle");
        }
    }
}
