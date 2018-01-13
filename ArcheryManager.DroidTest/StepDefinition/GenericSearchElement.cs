using ArcheryManager.DroidTest.Helpers;
using ArcheryManager.Resources;
using NUnit.Framework;
using System.Linq;
using TechTalk.SpecFlow;
using Xamarin.UITest.Android;

namespace ArcheryManager.DroidTest.StepDefinition
{
    [Binding]
    public class GenericSearchElement
    {
        private AndroidApp app = TestSetting.App;

        [Then(@"il n'y a pas de barre de navigation")]
        public void AlorsIlNYAPasDeBarreDeNavigation()
        {
            TestSetting.App.WaitForNoElement(e => e.Id("toolbar"));
        }

        [Then(@"il y a (.*) boutons dans la barre de navigation")]
        public void AlorsIlYABoutonsDansLaBarreDeNavigation(int p0)
        {
            var buttons = TestSetting.App.Query(e => e.Id("toolbar").Child(0).Child());
            var actual = buttons.Count();

            Assert.AreEqual(p0, actual);
        }

        [Then(@"il y a le texte (.*)")]
        public void IlYALeText(string p0)
        {
            string text = TranslationHelper.GetTextResource(p0);
            TestSetting.App.WaitForElement(e => e.Text(text));
        }

        [When(@"je click sur le texte (.*)")]
        public void QuandJeClickSurLeTexte(string target)
        {
            var targetName = TranslationHelper.GetTextResource(target);
            TestSetting.App.WaitForElement(targetName);
            TestSetting.App.Tap(e => e.Text(targetName));
        }

        [When(@"j'attend un texte equal à (.*)")]
        public void QuandQueJAttendUnTexteEqualA(string p0)
        {
            TestSetting.App.WaitForElement(e => e.Text(p0));
        }

        [Then(@"il y a (.*) boutons")]
        public void ThenIlYABoutons(int p0)
        {
            var allButton = app.Query(e => e.Button());
            Assert.AreEqual(p0, allButton.Count());
        }
    }
}
