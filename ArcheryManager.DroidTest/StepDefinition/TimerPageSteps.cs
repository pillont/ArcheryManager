using ArcheryManager.Resources;
using NUnit.Framework;
using System.Linq;
using TechTalk.SpecFlow;

namespace ArcheryManager.DroidTest.StepDefinition
{
    [Binding]
    public class TimerMultiWaveFeaturesSteps
    {
        [When(@"je click sur l'option de vague")]
        public void QuandJeClickSurLOptionDeVague()
        {
            TestSetting.App.Tap(
                        TestSetting.App.Query("ABC").Count() != 0//ABC check
                            ? "ABC" // abc click if true
                                : TestSetting.App.Query("ABCD").Count() != 0 ? // ABCD check
                                                                            "ABCD"  //ABCD click if true
                                : TestSetting.App.Query(TranslateExtension.GetTextResource("Duel")).Count() != 0 ? // VS check
                                                                            TranslateExtension.GetTextResource("Duel") :
                                                                                TranslateExtension.GetTextResource("ShootOut")); // else shootoff
        }

        [When(@"je lance le timer")]
        public void QuandJeClickSurLeTimer()
        {
            TestSetting.App.Tap("CustomTimer");
        }

        [When(@"j'arrete le timer")]
        public void QuandJarreteLeTimer()
        {
            TestSetting.App.Tap("CustomTimer");
        }

        [Then(@"l'option de vague est en ABC")]
        public void AlorsLOptionDeVagueEstEnABC()
        {
            Assert.AreEqual(1, TestSetting.App.Query(TranslateExtension.GetTextResource("ABC")).Count());
        }

        [Then(@"l'option de vague est en ABCD")]
        public void AlorsLOptionDeVagueEstEnABCD()
        {
            Assert.AreEqual(1, TestSetting.App.Query(TranslateExtension.GetTextResource("ABCD")).Count());
        }

        [Then(@"l'option de vague est en Shootout")]
        public void AlorsLOptionDeVagueEstEnShootout()
        {
            Assert.AreEqual(1, TestSetting.App.Query(TranslateExtension.GetTextResource("ShootOut")).Count());
        }

        [Then(@"l'option de vague est en VS")]
        public void AlorsLOptionDeVagueEstEnVS()
        {
            TestSetting.App.WaitForElement(TranslateExtension.GetTextResource("Duel"));
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

        [When(@"Je click sur le bouton de réglage de temps")]
        public void QuandJeClickSurLeBoutonDeReglageDeTemps()
        {
            TestSetting.App.Tap(TranslateExtension.GetTextResource("Time"));
        }
    }
}
