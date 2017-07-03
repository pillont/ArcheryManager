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
                        TestSetting.App.Query("ABC").Count() != 0
                            ? "ABC"
                                : "ABCD");
        }

        [When(@"je lance le timer")]
        public void QuandJeClickSurLeTimer()
        {
            TestSetting.App.Tap("StartButton"/*TODO : CustomTimer*/);
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
            Assert.AreEqual(p0, TestSetting.App.Query("TimerLabel").First().Text);
        }

        [Then(@"le text de vague est vide")]
        public void AlorsLeTextDeVagueEstVide()
        {
            Assert.AreEqual(0, TestSetting.App.Query("WaveText").Count());
        }

        [Then(@"le texte de vague contient (.*)")]
        public void AlorsLeTexteDeVagueContientCD(string p0)
        {
            Assert.AreEqual(p0, TestSetting.App.Query("WaveText").First().Text);
        }
    }
}
