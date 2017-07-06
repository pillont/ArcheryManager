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
                                                                            "ABCD" : //ABCD click if true
                                                                                "Shootout"); // else shootoff
        }

        [When(@"je lance le timer")]
        public void QuandJeClickSurLeTimer()
        {
            TestSetting.App.Tap("StartButton"/*TODO : CustomTimer*/);
        }

        [When(@"j'arrete le timer")]
        public void QuandJarreteLeTimer()
        {
            TestSetting.App.Tap("StopButton"/*TODO : CustomTimer*/);
        }

        [Then(@"l'option de vague est en ABC")]
        public void AlorsLOptionDeVagueEstEnABC()
        {
            Assert.AreEqual(1, TestSetting.App.Query("ABC").Count());
        }

        [Then(@"l'option de vague est en ABCD")]
        public void AlorsLOptionDeVagueEstEnABCD()
        {
            Assert.AreEqual(1, TestSetting.App.Query("ABCD").Count());
        }

        [Then(@"l'option de vague est en Shootout")]
        public void AlorsLOptionDeVagueEstEnShootout()
        {
            Assert.AreEqual(1, TestSetting.App.Query("Shootout").Count());
        }

        [Then(@"le timer est à (.*) sec")]
        public void AlorsLeTimerEstASec(int p0)
        {
            Assert.AreEqual(p0.ToString(), TestSetting.App.Query("TimerLabel").First().Text);
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
    }
}
