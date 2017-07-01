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

        [Then(@"la fleche (.*) de la liste est un (.*)")]
        public void ThenLaFlecheDeLaListeEstUn(int p0, string value)
        {
            Assert.AreEqual(value, TestSetting.App.Query(e => e.Marked("scoreList").Child(p0).Child(1).Child()).First().Text);
        }

        [When(@"je supprime la dernière flèche")]
        public void QuandJeSupprimeLaDerniereFleche()
        {
            TestSetting.App.Tap("Remove last");
        }

        [When(@"Je click sur le bouton nouvelle volée")]
        public void QuandJeClickSurLeBoutonNouvelleVolee()
        {
            TestSetting.App.Tap("New Flight");
        }

        [Then(@"le bouton nouvelle volée est désactivé")]
        public void AlorsLeBoutonNouvelleVoleeEstDesactive()
        {
            Assert.IsFalse(TestSetting.App.Query("New Flight").First().Enabled);
        }

        [Then(@"le bouton nouvelle volée est activé")]
        public void AlorsLeBoutonNouvelleVoleeEstActive()
        {
            Assert.IsTrue(TestSetting.App.Query("New Flight").First().Enabled);
        }

        [Then(@"le nombre de flèches dans la liste est de (.*)")]
        public void AlorsLeNombreDeFlechesDansLaListeEstDe(int p0)
        {
            Assert.AreEqual(p0, TestSetting.App.Query(e => e.Marked("arrowInTargetGrid").Child()).Count());
        }

        [Then(@"le nombre de flèches actuelles sur la cible est de (.*)")]
        public void AlorsLeNombreDeFlechesActuellesSurLaCibleEstDe(int p0)
        {
            Assert.AreEqual(p0, TestSetting.App.Query(e => e.Marked("arrowInTargetGrid").Child()).Count());
        }
    }
}
