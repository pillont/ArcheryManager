using ArcheryManager.DroidTest.Helpers;
using ArcheryManager.Resources;
using NUnit.Framework;
using System.Linq;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;

namespace ArcheryManager.DroidTest.StepDefinition
{
    [Binding]
    public class ListRemarksSteps
    {
        [Then(@"la remarque (.*) a comme taille (.*)")]
        public void AlorsLaRemarqueACommeTaille(int index, int wanted)
        {
            var height = TestSetting.App.Query(e => e.Marked("remarksList").Child(index + 1).Child().Child().Child().Child()).Last().Rect.Height;
            Assert.AreEqual(wanted, height);
        }

        [Then(@"la remarque (.*) est ""(.*)""")]
        public void AlorsLaRemarqueEst(int index, string text)
        {
            TestSetting.App.WaitForElement("remarksList");
            string str = TestSetting.App.Query(e => e.Marked("remarksList").Child(index + 1).Child().Child().Child().Child()).Last().Text;
            Assert.AreEqual(text, str);
        }

        [Then(@"la volée de la remarque (.*) a comme taille (.*)")]
        public void AlorsLaVoleeDeLaRemarqueACommeTaille(int index, int wanted)
        {
            if (index == 2)
                TestSetting.App.Repl();
            var width = TestSetting.App.Query(e => e.Marked("remarksList").Child(index + 1).Child().Child().Child().Child()).First().Rect.Width;
            Assert.AreEqual(wanted, width);
        }

        [Then(@"la volée de la remarque (.*) est (.*)")]
        public void AlorsLaVoleeDeLaRemarqueEst(int index, int number)
        {
            string str = TestSetting.App.Query(e => e.Marked("remarksList").Child(index + 1).Child().Child().Child().Child()).First().Text;
            string format = TranslationHelper.GetTextResource("FlightNumber");
            Assert.IsTrue(Regex.IsMatch(str, format));
            string val = str.Split(' ').Last();
            Assert.AreEqual(number.ToString(), val);
        }

        [Then(@"la volée de la remarque (.*) n'est pas visible")]
        public void AlorsLaVoleeDeLaRemarqueNEstPasVisible(int index)
        {
            var count = TestSetting.App.Query(e => e.Marked("remarksList").Child(index + 1).Child().Child().Child().Child()).Count();
            Assert.AreEqual(1, count);
        }

        [When(@"je click sur le bouton d'historique de remarque de la volée")]
        public void QuandJeClickSurLeBoutonDHistoriqueDeRemarqueDeLaVolee()
        {
            string history = TranslationHelper.GetTextResource("History");
            TestSetting.App.Tap(e => e.Marked("flightRemarkEditor").Child().Child().Child().Child().Text(history));
            TestSetting.App.WaitForElement("remarksList");
        }

        [When(@"je click sur le bouton d'historique de remarque générales")]
        public void QuandJeClickSurLeBoutonDHistoriqueDeRemarqueGenerales()
        {
            string history = TranslationHelper.GetTextResource("History");
            TestSetting.App.Tap(e => e.Marked("generalRemarkEditor").Child().Child().Child().Child().Text(history));
        }
    }
}
