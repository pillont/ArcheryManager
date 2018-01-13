using ArcheryManager.DroidTest.Helpers;
using ArcheryManager.Resources;
using TechTalk.SpecFlow;

namespace ArcheryManager.DroidTest
{
    [Binding]
    public class TabbedCounterSteps
    {
        [When(@"je click sur le tab timer")]
        public void QuandJeClickSurLeTabTimer()
        {
            TestSetting.App.Tap(e => e.Text(TranslationHelper.GetTextResource("Timer")));
        }

        [When(@"je click sur l'onglet de compté")]
        public void QuandJeClickSurLOngletDeCompte()
        {
            TestSetting.App.Tap(e => e.Text(TranslationHelper.GetTextResource("Shoot")));
        }

        [When(@"je click sur l'onglet de remarque")]
        public void QuandJeClickSurLOngletDeRemarque()
        {
            TestSetting.App.Tap(e => e.Text(TranslationHelper.GetTextResource("Remarks")));
        }
    }
}
