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
    public class TargetSelectorSteps
    {
        [Then(@"il y a des boutons de (.*)")]
        public void AlorsIlYADesBoutonsDe(string target)
        {
            var enumeration = (TargetStyle)Enum.Parse(typeof(TargetStyle), target, true);
            TargetHelper.ShouldHaveButton(enumeration);
        }

        [Then(@"la page de tir compté s'affiche")]
        public void AlorsLaPageDeTirCompteSAffiche()
        {
            TestSetting.App.WaitForElement("imageGrid");
        }

        [Then(@"le nombre de flèches est de (.*)")]
        public void AlorsLeNombreDeFlechesEstDe(int p0)
        {
            Assert.AreEqual(p0.ToString(), TestSetting.App.Query("numberArrowEntry").First().Text);
        }

        [When(@"je click sur le slider de nombre fixe de flèche")]
        public void QuandJeClickSurLeSliderDeNombreFixeDeFleche()
        {
            TestSetting.App.Tap("maxArrowsSwitch");
        }

        [When(@"je click sur l'option cible")]
        public void QuandJeClickSurLOptionCible()
        {
            TestSetting.App.Tap("wantTargetSwitch");
        }

        [When(@"je rentre (.*) en nombre de flèche")]
        public void QuandJeRentreEnNombreDeFleche(int p0)
        {
            TestSetting.App.ClearText("numberArrowEntry");
            TestSetting.App.EnterText("numberArrowEntry", p0.ToString());
        }

        [When(@"je valide la sélection de cible")]
        public void QuandJeValideLaSelectionDeCible()
        {
            TestSetting.App.Tap(TranslationHelper.GetTextResource("Valid"));
        }
    }
}
