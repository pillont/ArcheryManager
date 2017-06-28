using NUnit.Framework;
using System.Linq;
using TechTalk.SpecFlow;

namespace ArcheryManager.DroidTest.StepDefinition
{
    [Binding]
    public class StartFeatureSteps
    {
        [When(@"je tire une flèche en (.*), (.*)")]
        public void WhenJeTireUneFlecheEn(int p0, int p1)
        {
            TestSetting.App.WaitForElement("arrowInTargetGrid");
            TestSetting.App.DragCoordinates(500, 800, 500 + p0, 800 + p1);
            TestSetting.App.WaitForElement("arrowInTargetGrid");
        }

        [When(@"j'ouvre le menu de paramètre")]
        public void WhenJOuvreLeMenuDeParametre()
        {
            TestSetting.App.Tap("More options");
            TestSetting.App.Tap("Settings");
        }

        [When(@"je click sur l option flèche ordonnée")]
        public void WhenJeClickSurLOptionFlecheOrdonnee()
        {
            TestSetting.App.Tap("ArrowsOrderSwitch");
        }

        [Then(@"la fleche (.*) de la liste est un (.*)")]
        public void ThenLaFlecheDeLaListeEstUn(int p0, string value)
        {
            Assert.AreEqual(value, TestSetting.App.Query(e => e.Marked("scoreList").Child(p0).Child(1).Child()).First().Text);
        }
    }
}
