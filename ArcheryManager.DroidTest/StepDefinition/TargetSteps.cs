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

        [Then(@"le nombre de flèche est dasactivé")]
        public void AlorsLeNombreDeFlecheEstDasactive()
        {
            Assert.IsFalse(TestSetting.App.Query("numberOfArrowsEntry").First().Enabled);
        }

        [Then(@"le nombre de flèche est activé")]
        public void AlorsLeNombreDeFlecheEstActive()
        {
            Assert.IsTrue(TestSetting.App.Query("numberOfArrowsEntry").First().Enabled);
        }

        [When(@"je click sur le check nombre de flèches défini")]
        public void QuandJeClickSurLeCheckNombreDeFlechesDefini()
        {
            TestSetting.App.Tap("ArrowsOrderSwitch");
        }

        [Then(@"le nombre de flèche est de (.*)")]
        public void AlorsLeNombreDeFlecheEstDe(int p0)
        {
            Assert.AreEqual(p0, TestSetting.App.Query("numberOfArrowsEntry").First().Text);
        }

        [When(@"je remplit le nombre de flèche par (.*)")]
        public void QuandJeRemplitLeNombreDeFlechePar(int p0)
        {
            TestSetting.App.EnterText("numberOfArrowsEntry", p0.ToString());
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
