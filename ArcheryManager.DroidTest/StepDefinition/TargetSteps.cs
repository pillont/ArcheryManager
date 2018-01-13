using ArcheryManager.DroidTest.Helpers;
using ArcheryManager.Resources;
using NUnit.Framework;
using System;
using System.Linq;
using TechTalk.SpecFlow;
using static ArcheryManager.CustomControls.TargetImage;

namespace ArcheryManager.DroidTest.StepDefinition
{
    [Binding]
    public class StartFeatureSteps
    {
        [Then(@"il n'y a pas de cible (.*)")]
        public void AlorsIlNYAPasDeCible(string target)
        {
            var enumeration = (TargetStyle)Enum.Parse(typeof(TargetStyle), target, true);
            TargetHelper.ShouldHaveTarget(enumeration);
        }

        [Then(@"il y a dans un onglet une cible (.*)")]
        public void AlorsIlYADansUnOngletUneCibleEnglishTarget(string target)
        {
            var enumeration = (TargetStyle)Enum.Parse(typeof(TargetStyle), target, true);
            TargetHelper.ShouldHaveTarget(enumeration);
        }

        [Then(@"il y a une cible (.*)")]
        public void AlorsIlYAUneCibleAnglaise(string target)
        {
            var enumeration = (TargetStyle)Enum.Parse(typeof(TargetStyle), target, true);
            TargetHelper.ShouldHaveTarget(enumeration);
        }

        [Then(@"la fleche (.*) de la cible est en (.*), (.*)")]
        public void AlorsLaFlecheDeLaCibleEstEn(int index, int x, int y)
        {
            var rect = TestSetting.App.Query(e => e.Marked("arrowInTargetGrid").Child(index)).First().Rect;
            Assert.AreEqual(x, rect.X, 7);
            Assert.AreEqual(y, rect.Y, 7);
        }

        [Then(@"la flèche numéro (.*) est en (.*), (.*)")]
        public void AlorsLaFlecheNumeroEstEn(int p0, int p1, int p2)
        {
            TestSetting.App.WaitForElement("arrowInTargetGrid");
            var rect = TestSetting.App.Query(e => e.Marked("arrowInTargetGrid").Child(p0)).First().Rect;
            Assert.AreEqual(p1, rect.CenterX, 5);
            Assert.AreEqual(p2, rect.CenterY, 5);
        }

        [Then(@"la moyenne est centrée en (.*), (.*)")]
        public void AlorsLaMoyenneEstCentreeEn(double x, double y)
        {
            TestSetting.App.WaitForElement(e => e.Marked("averageCanvas").Child(0));
            var average = TestSetting.App.Query(e => e.Marked("averageCanvas").Child(0)).Single();
            Assert.AreEqual(x, average.Rect.CenterX, 7);
            Assert.AreEqual(y, average.Rect.CenterY, 7);
        }

        [Then(@"la moyenne est de taille (.*), (.*)")]
        public void AlorsLaMoyenneEstDeTaille(double width, double height)
        {
            var average = TestSetting.App.Query(e => e.Marked("averageCanvas").Child(0)).Single();
            Assert.AreEqual(width, average.Rect.Width, 7);
            Assert.AreEqual(height, average.Rect.Height, 7);
        }

        [Then(@"le bouton nouvelle volée est activé")]
        public void AlorsLeBoutonNouvelleVoleeEstActive()
        {
            TestSetting.App.WaitForElement(TranslationHelper.GetTextResource("NewFlight"));
        }

        [Then(@"le bouton nouvelle volée est désactivé")]
        public void AlorsLeBoutonNouvelleVoleeEstDesactive()
        {
            Assert.AreEqual(0, TestSetting.App.Query(TranslationHelper.GetTextResource("NewFlight")).Count());
        }

        [Then(@"le message d'erreur du nombre de flèche est affiché")]
        public void AlorsLeMessageDErreurDuNombreDeFlecheEstAffiche()
        {
            TestSetting.App.WaitForElement(e => e.Text(TranslationHelper.GetTextResource("CantAddMoreThanMaxArrow")));
        }

        [Then(@"le nombre de flèches actuelles sur la cible est de (.*)")]
        public void AlorsLeNombreDeFlechesActuellesSurLaCibleEstDe(int p0)
        {
            TestSetting.App.WaitForElement("arrowInTargetGrid");
            Assert.AreEqual(p0, TestSetting.App.Query(e => e.Marked("arrowInTargetGrid").Child()).Count());
        }

        [Then(@"le nombre de flèches dans la liste est de (.*)")]
        public void AlorsLeNombreDeFlechesDansLaListeEstDe(int p0)
        {
            TestSetting.App.WaitForElement("scoreList");
            Assert.AreEqual(p0, TestSetting.App.Query(e => e.Marked("scoreList").Child()).Count());
        }

        [Then(@"le nombre de flèches précèdente sur la cible est de (.*)")]
        public void AlorsLeNombreDeFlechesPrecedenteSurLaCibleEstDe(int p0)
        {
            Assert.AreEqual(p0, TestSetting.App.Query(e => e.Marked("lastArrowInTargetGrid").Child()).Count());
        }

        [Then(@"le score de la volée est (.*)")]
        public void AlorsLeScoreDeLaVoleeEst(string text)
        {
            TestSetting.App.WaitForElement("FlightScore");
            Assert.AreEqual(text, TestSetting.App.Query("FlightScore").First().Text);
        }

        [Then(@"le score total est (.*)")]
        public void AlorsLeScoreTotalEst(string text)
        {
            TestSetting.App.WaitForElement("TotalScore");
            Assert.AreEqual(text, TestSetting.App.Query("TotalScore").First().Text);
        }

        [When(@"je click sur le bouton de restart")]
        public void QuandJeClickSurLeBoutonDeRestart()
        {
            TestSetting.App.WaitForElement(TranslationHelper.GetTextResource("MoreOptions"));
            TestSetting.App.Tap(TranslationHelper.GetTextResource("MoreOptions"));
            TestSetting.App.Tap(TranslationHelper.GetTextResource("Restart"));
            TestSetting.App.Tap(e => e.Text(TranslationHelper.GetTextResource("Yes")));
        }

        [When(@"je click sur le bouton de validation d'un compté")]
        public void QuandJeClickSurLeBoutonDeValidationDUnCompte()
        {
            TestSetting.App.Tap(TranslationHelper.GetTextResource("Finish"));
        }

        [When(@"Je click sur le bouton nouvelle volée")]
        public void QuandJeClickSurLeBoutonNouvelleVolee()
        {
            TestSetting.App.Tap(TranslationHelper.GetTextResource("NewFlight"));
            TestSetting.App.Tap(e => e.Text(TranslationHelper.GetTextResource("Yes")));
        }

        [When(@"je supprime la dernière flèche")]
        public void QuandJeSupprimeLaDerniereFleche()
        {
            GeneralCounterStep.RemoveLast();
        }

        [Then(@"la fleche (.*) de la liste est un (.*)")]
        public void ThenLaFlecheDeLaListeEstUn(int index, string value)
        {
            var child = ArrowListHelper.ArrowInList(index);
            Assert.AreEqual(value, child.Text);
            return;
        }

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
            string moreO = TranslationHelper.GetTextResource("MoreOptions");
            string setting = TranslationHelper.GetTextResource("Settings");

            TestSetting.App.WaitForElement(moreO);
            TestSetting.App.Tap(moreO);

            TestSetting.App.WaitForElement(setting);
            TestSetting.App.Tap(setting);
        }
    }
}
