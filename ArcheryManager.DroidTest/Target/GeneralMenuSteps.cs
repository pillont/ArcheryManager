using System;
using TechTalk.SpecFlow;

namespace ArcheryManager.DroidTest.Target
{
    [Binding]
    public class GeneralMenuSteps
    {
        [When(@"je click sur le bouton de timer")]
        public void QuandJeClickSurLeBoutonDeTimer()
        {
            TestSetting.App.Tap("CounterButton");
        }

        [When(@"je click sur le bouton de tir compté")]
        public void QuandJeClickSurLeBoutonDeTirCompte()
        {
            TestSetting.App.Tap("TimerButton");
        }
    }
}
