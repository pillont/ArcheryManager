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

        [When(@"J'ouvre une page tabbed de cible fita")]
        public void QuandJOuvreUnePageTabbedDeCibleFita()
        {
            TestSetting.InitTestApplication();
            TestSetting.App.ScrollDownTo("tabbedTargetButton");
            TestSetting.App.Tap("tabbedTargetButton");
            TestSetting.App.WaitForElement("arrowInTargetGrid");
        }

        [When(@"J'ouvre une page tabbed de zappette")]
        public void QuandJOuvreUnePageTabbedDeZappette()
        {
            TestSetting.InitTestApplication();
            TestSetting.App.ScrollDownTo("tabbedZapetteButton");
            TestSetting.App.Tap("tabbedZapetteButton");
        }

        [When(@"J'ouvre une page d'édition de remarque")]
        public void QuandJEditionDeRemarque()
        {
            TestSetting.InitTestApplication();
            TestSetting.App.ScrollDownTo("remarksButton");
            TestSetting.App.Tap("remarksButton");
        }
    }
}
