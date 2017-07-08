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
                        TestSetting.App.Query(TranslateExtension.GetTextResource("ABC")).Count() != 0//ABC check
                            ? TranslateExtension.GetTextResource("ABC") // abc click if true
                                : TestSetting.App.Query(TranslateExtension.GetTextResource("ABCD")).Count() != 0 ? // ABCD check
                                                                            TranslateExtension.GetTextResource("ABCD") : //ABCD click if true
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
            Assert.AreEqual(1, TestSetting.App.Query(TranslateExtension.GetTextResource("Shootout")).Count());
        }

        [Then(@"l'option de vague est en VS")]
        public void AlorsLOptionDeVagueEstEnVS()
        {
            Assert.AreEqual(1, TestSetting.App.Query("VS").Count());
        }

        [Then(@"le timer est à (.*) sec")]
        public void AlorsLeTimerEstASec(int p0)
        {
            var query = TestSetting.App.Query("TimerLabel");
            if (query.Count() == 0)
            {
                TestSetting.App.WaitForElement("TimerLabel");
                query = TestSetting.App.Query("TimerLabel");
            }
            Assert.AreEqual(p0.ToString(), query.First().Text);
        }

        [Then(@"le text de vague est vide")]
        public void AlorsLeTextDeVagueEstVide()
        {
            var res = TestSetting.App.Query("WaveText");
            Assert.IsTrue(res.Count() == 0 || res.Count() == 1 && string.IsNullOrEmpty(res.First().Text));
        }

        [Then(@"le texte de vague contient (.*)")]
        public void AlorsLeTexteDeVagueContientCD(string p0)
        {
            Assert.AreEqual(p0, TestSetting.App.Query("WaveText").First().Text);
        }

        [When(@"Je click sur le bouton de réglage de temps")]
        public void QuandJeClickSurLeBoutonDeReglageDeTemps()
        {
            TestSetting.App.Tap(TranslateExtension.GetTextResource("Time"));
        }
    }
}
