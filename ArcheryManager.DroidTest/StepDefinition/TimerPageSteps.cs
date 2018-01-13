using ArcheryManager.DroidTest.Helpers;
using ArcheryManager.Resources;
using ArcheryManager.Utils;
using NUnit.Framework;
using System.Linq;
using TechTalk.SpecFlow;

namespace ArcheryManager.DroidTest.StepDefinition
{
    [Binding]
    public class TimerMultiWaveFeaturesSteps
    {
        [Then(@"la page timer s'affiche")]
        public void AlorsLaPageTimerSAffiche()
        {
            TestSetting.App.WaitForElement("CustomTimer");
        }

        [Then(@"le text de vague est vide")]
        public void AlorsLeTextDeVagueEstVide()
        {
            var res = TestSetting.App.Query("WaveText");
            Assert.IsTrue(res.Count() == 0 || (res.Count() == 1 && string.IsNullOrEmpty(res.First().Text)));
        }

        [Then(@"le texte de vague contient (.*)")]
        public void AlorsLeTexteDeVagueContientCD(string p0)
        {
            TestSetting.App.WaitForElement("WaveText");
            Assert.AreEqual(p0, TestSetting.App.Query("WaveText").First().Text);
        }

        [Then(@"le timer est à (.*) sec")]
        public void AlorsLeTimerEstASec(int p0)
        {
            var res = TestSetting.App.Query("TimerLabel");
            if (res.Count() == 0)
            {
                TestSetting.App.WaitForElement("TimerLabel");
                res = TestSetting.App.Query(e => e.Marked("TimerLabel"));
            }
            Assert.AreEqual(p0.ToString(), res.First().Text);
        }

        [Then(@"l'option de vague est en (.*)")]
        public void AlorsLOptionDeVagueEstEn(string mode)
        {
            string pure = string.Format(TranslationHelper.GetTextResource("ModeFormat"), TranslationHelper.GetTextResource(mode));
            TestSetting.App.WaitForElement("labelMode");
            Assert.AreEqual(pure, TestSetting.App.Query("labelMode").First().Text);
        }

        [When(@"je passe à l'option de vague suivante")]
        public void JePasseALOptionDeVagueSuivante()
        {
            TestSetting.App.Tap("Mode");

            var text = TestSetting.App.Query("labelMode").First().Text;
            string mode = text.Split(' ').Last();

            int current = TimerPageSetting.TimerModes.IndexOf(mode);
            string wanted = TimerPageSetting.TimerModes[(current + 1) % TimerPageSetting.TimerModes.Count];
            TestSetting.App.Tap(e => e.Text(wanted));
        }

        [When(@"j'arrete le timer")]
        public void QuandJarreteLeTimer()
        {
            TestSetting.App.Tap("CustomTimer");
        }

        [When(@"Je click sur le bouton de réglage de temps")]
        public void QuandJeClickSurLeBoutonDeReglageDeTemps()
        {
            TestSetting.App.Tap(TranslationHelper.GetTextResource("Time"));
        }

        [When(@"je lance le timer")]
        public void QuandJeClickSurLeTimer()
        {
            TestSetting.App.Tap("CustomTimer");
        }

        [When(@"je click sur l'option de moyenne")]
        public void QuandJeClickSurLOptionDeMoyenne()
        {
            TestSetting.App.WaitForElement("VisibilityAverageSwitch");
            TestSetting.App.Tap("VisibilityAverageSwitch");
        }

        [When(@"je click sur l'option toutes flèches")]
        public void QuandJeClickSurLOptionToutesFleches()
        {
            TestSetting.App.WaitForElement("ShowAllArrowsSwitch");
            TestSetting.App.Tap("ShowAllArrowsSwitch");
        }
    }
}
