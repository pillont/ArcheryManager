using System;
using TechTalk.SpecFlow;

namespace ArcheryManager.DroidTest.StepDefinition
{
    [Binding]
    public class ListRemarksSteps
    {
        [When(@"je click sur l'onglet de remarque")]
        public void QuandJeClickSurLOngletDeRemarque()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"je click sur le bouton d'historique de remarque générales")]
        public void QuandJeClickSurLeBoutonDHistoriqueDeRemarqueGenerales()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"je click sur le bouton d'historique de remarque de la volée")]
        public void QuandJeClickSurLeBoutonDHistoriqueDeRemarqueDeLaVolee()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"la remarque (.*) est ""(.*)""")]
        public void AlorsLaRemarqueEst(int p0, string p1)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"la volée de la remarque (.*) n'est pas visible")]
        public void AlorsLaVoleeDeLaRemarqueNEstPasVisible(int p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"la volée de la remarque (.*) est (.*)")]
        public void AlorsLaVoleeDeLaRemarqueEst(int p0, int p1)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
