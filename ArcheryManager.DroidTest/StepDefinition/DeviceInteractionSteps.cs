using NUnit.Framework;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;

namespace ArcheryManager.DroidTest.StepDefinition
{
    [Binding]
    public class DeviceInteractionSteps
    {
        [Then(@"il y a (.*) boutons dans la barre de menu")]
        public void AlorsIlYABoutonsDansLaBarreDeMenu(int wanted)
        {
            int current = TestSetting.App.Query(e => e.Id("toolbar").Child(0).Child()).Count();
            Assert.AreEqual(wanted, current);
        }

        [When(@"j'attend (.*) secondes")]
        public void QuandJAttendSecondes(int p0)
        {
            Thread.Sleep(p0 * 1000);
        }

        [When(@"je scrool en bas")]
        public void QuandJeScroolEnBas()
        {
            TestSetting.App.ScrollToVerticalEnd();
        }

        [When(@"je scrool en haut")]
        public void QuandJeScroolEnHaut()
        {
            TestSetting.App.ScrollToVerticalStart();
        }

        [When(@"je tourne le téléphone")]
        public void QuandJeTourneLeTelephone()
        {
            TestSetting.App.SetOrientationLandscape();
        }

        [When(@"je reviens à la page d'avant")]
        public void WhenJeReviensALaPageDAvant()
        {
            TestSetting.App.Back();
        }
    }
}
