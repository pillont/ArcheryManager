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

        [Then(@"il y a (.*) boutons")]
        public void ThenIlYABoutons(int p0)
        {
            var allButton = app.Query(e => e.Button());
            Assert.AreEqual(p0, allButton.Count());
        }

        [When(@"que j'attend un texte equal à (.*)")]
        public void QuandQueJAttendUnTexteEqualA(string p0)
        {
            TestSetting.App.WaitForElement(e => e.Text(p0));
        }
    }
}
