using System;
using TechTalk.SpecFlow;

namespace ArcheryManager.DroidTest.StepDefinition
{
    [Binding]
    public class DeviceInteractionSteps
    {
        [When(@"je reviens à la page d'avant")]
        public void WhenJeReviensALaPageDAvant()
        {
            TestSetting.App.Back();
        }

        [When(@"je tourne le téléphone")]
        public void QuandJeTourneLeTelephone()
        {
            TestSetting.App.SetOrientationLandscape();
        }
    }
}
