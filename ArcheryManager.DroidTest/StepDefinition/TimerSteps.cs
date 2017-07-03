using NUnit.Framework;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace ArcheryManager.DroidTest.StepDefinition
{
    [Binding]
    public class TimerSteps
    {
        [When(@"que je click sur l'option de vague")]
        public void QuandQueJeClickSurLOptionDeVague()
        {
            TestSetting.App.Tap(
                                TestSetting.App.Query("ABC").Count() != 0
                                    ? "ABC"
                                        : "AB/CD");
        }

        [Then(@"l'option de vague est en (.*)")]
        public void AlorsLOptionDeVagueEstEnABCD(string p0)
        {
            Assert.AreEqual(1, TestSetting.App.Query(p0).Count());
        }

        [Then(@"le text de vague est vide")]
        public void AlorsLeTextDeVagueEstAB()
        {
            Assert.IsTrue(string.IsNullOrEmpty(TestSetting.App.Query("WaveText").First().Text));
        }

        [When(@"que je click sur le timer")]
        public void QuandQueJeClickSurLeTimer()
        {
            TestSetting.App.Tap("CustomTimer");
        }

        [Then(@"le texte de vague est (.*)")]
        public void AlorsLeTexteDeVagueEstCD(string p0)
        {
            Assert.AreEqual(p0, TestSetting.App.Query("WaveText").First().Text);
        }

        [Then(@"le timer est à (.*) sec")]
        public void AlorsLeTimerEstASec(int p0)
        {
            Assert.AreEqual(p0, TestSetting.App.Query("TimerLabel").First().Text);
        }
    }
}
