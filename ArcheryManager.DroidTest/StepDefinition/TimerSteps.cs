using NUnit.Framework;
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
        }

        [Then(@"l'option de vague est en (.*)")]
        public void AlorsLOptionDeVagueEstEnABCD(string p0)
        {
        }

        [Then(@"le text de vague est vide")]
        public void AlorsLeTextDeVagueEstVide()
        {
        }

        [When(@"que je click sur le timer")]
        public void QuandQueJeClickSurLeTimer()
        {
        }

        [Then(@"le texte de vague contient (.*)")]
        public void AlorsLeTexteDeVagueEst(string p0)
        {
        }

        [Then(@"le timer est à (.*) sec")]
        public void AlorsLeTimerEstASec(int p0)
        {
        }
    }
}
