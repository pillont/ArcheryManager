using ArcheryManager.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace ArcheryManager.DroidTest.StepDefinition
{
    [Binding]
    public class GeneralCounterStep
    {
        [When(@"je sélectionne la flèche (.*)")]
        public void QuandJeSelectionneLaFleche(int p0)
        {
            TestSetting.App.Tap(e => e.Marked("scoreList").Child(p0).Child(1).Child());
        }

        [Then(@"le message d'erreur d'ajout pendant sélection est affiché")]
        public void AlorsLeMessageDAjoutPendantSelectionEstAffiche()
        {
            var text = TranslateExtension.GetTextResource("NoAddingDuringSelection");
            TestSetting.App.WaitForElement(e => e.Text(text));
        }

        [Then(@"le message d'(.*)'ajout pendant sélection n'est pas affiché")]
        public void AlorsLeMessageDAjoutPendantSelectionNEstPasAffiche(string p0)
        {
            TestSetting.App.WaitForNoElement(e => e.Text(TranslateExtension.GetTextResource("NoAddingDuringSelection")));
        }
    }
}
