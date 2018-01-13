using System;
using TechTalk.SpecFlow;

namespace ArcheryManager.DroidTest.StepDefinition
{
    [Binding]
    public class BackdoorSteps
    {
        [Then(@"il y a le titre de backdoor")]
        public void AlorsIlYALeTitreDeBackdoor()
        {
            TestSetting.App.WaitForElement("backdoorTitle");
        }

        [When(@"J'ouvre une page d'édition de remarque")]
        public void QuandJEditionDeRemarque()
        {
            TestSetting.InitTestApplication();
            TestSetting.App.ScrollDownTo("remarksButton");
            TestSetting.App.Tap("remarksButton");
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
            try
            {
                TestSetting.App.WaitForElement("CounterSelectorButton");
            }
            catch (Exception)
            {
                TestSetting.InitTestApplication();
                TestSetting.App.WaitForElement("CounterSelectorButton");
            }

            TestSetting.App.Tap("CounterSelectorButton");
        }

        [When(@"J'ouvre une page de tir connecté")]
        public void QuandJOuvreUnePageDeTirConnecte()
        {
            TestSetting.InitTestApplication();
            TestSetting.App.ScrollDownTo("StartConnectedShootButton");
            TestSetting.App.Tap("StartConnectedShootButton");
        }

        [When(@"j'ouvre une page de tir sauvegardé")]
        public void QuandJOuvreUnePageDeTirSauvegarde()
        {
            try
            {
                TestSetting.App.ScrollTo("SavesListPageButton");
                TestSetting.App.WaitForElement("SavesListPageButton");
            }
            catch (Exception)
            {
                TestSetting.InitTestApplication();
                TestSetting.App.ScrollTo("SavesListPageButton");
                TestSetting.App.WaitForElement("SavesListPageButton");
            }

            TestSetting.App.ScrollTo("SavesListPageButton");
            TestSetting.App.WaitForElement("SavesListPageButton");
            TestSetting.App.Tap("SavesListPageButton");
        }

        [When(@"J'ouvre une page tabbed de cible fita")]
        public void QuandJOuvreUnePageTabbedDeCibleFita()
        {
            TestSetting.InitTestApplication();
            TestSetting.App.ScrollDownTo("EnglishTargetButton");
            TestSetting.App.Tap("EnglishTargetButton");
            TestSetting.App.WaitForElement("arrowInTargetGrid");
        }

        [When(@"J'ouvre une page tabbed de zappette")]
        public void QuandJOuvreUnePageTabbedDeZappette()
        {
            TestSetting.InitTestApplication();
            TestSetting.App.ScrollDownTo("ButtonCounterButton");
            TestSetting.App.Tap("ButtonCounterButton");
        }

        [When(@"J'ouvre une page zappette")]
        public void QuandJOuvreUnePageZappette()
        {
            TestSetting.InitTestApplication();
            TestSetting.App.Tap("ButtonCounterButton");
        }

        [When(@"J'ouvre une page de backdoor")]
        public void WhenJOuvreUnePageDeBackdoor()
        {
            TestSetting.InitTestApplication();
        }

        [When(@"J'ouvre une page de cible fita")]
        public void WhenJOuvreUnePageDeCibleFita()
        {
            TestSetting.InitTestApplication();
            TestSetting.App.WaitForElement("EnglishTargetButton");
            TestSetting.App.Tap("EnglishTargetButton");
        }

        [When(@"J'ouvre une page timer")]
        public void WhenJOuvreUnePageTimer()
        {
            TestSetting.InitTestApplication();
            TestSetting.App.Tap("TimerButton");
        }
    }
}
