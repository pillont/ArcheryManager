using ArcheryManager.DroidTest.Helpers;
using ArcheryManager.Resources;
using NUnit.Framework;
using System.Linq;
using TechTalk.SpecFlow;

namespace ArcheryManager.DroidTest.StepDefinition
{
    [Binding]
    public class GeneralCounterStep
    {
        public static void RemoveLast()
        {
            TestSetting.App.WaitForElement("scoreList");
            int childCount = TestSetting.App.Query(e => e.Marked("scoreList").Child()).Count();

            int i = ArrowListHelper.IndexInList(childCount - 1);
            TestSetting.App.Tap(e => e.Marked("scoreList").Child(i));
            TestSetting.App.Tap(e => e.Marked(TranslationHelper.GetTextResource("RemoveSelect")));
        }

        [Then(@"le message d'erreur d'ajout pendant sélection est affiché")]
        public void AlorsLeMessageDAjoutPendantSelectionEstAffiche()
        {
            var text = TranslationHelper.GetTextResource("NoAddingDuringSelection");
            TestSetting.App.WaitForElement(e => e.Text(text));
        }

        [Then(@"le message d'(.*)'ajout pendant sélection n'est pas affiché")]
        public void AlorsLeMessageDAjoutPendantSelectionNEstPasAffiche(string p0)
        {
            TestSetting.App.WaitForNoElement(e => e.Text(TranslationHelper.GetTextResource("NoAddingDuringSelection")));
        }

        [Then(@"le numero de la volée est (.*)")]
        public void AlorsLeNumeroDeLaVoleeEst(int wanted)
        {
            TestSetting.App.WaitForElement("FlightNumber");
            var text = TestSetting.App.Query("FlightNumber").First().Text;
            Assert.AreEqual(wanted.ToString(), text);
        }

        [When(@"je sélectionne la flèche (.*)")]
        public void QuandJeSelectionneLaFleche(int p0)
        {
            var arrow = ArrowListHelper.ArrowInList(p0);
            int i = ArrowListHelper.IndexInList(p0);
            TestSetting.App.Tap(e => e.Marked("scoreList").Child(i));
        }
    }
}
