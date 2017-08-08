using System;
using TechTalk.SpecFlow;

namespace ArcheryManager.DroidTest
{
    [Binding]
    public class TabbedCounterSteps
    {
        [When(@"je click sur l'onglet de compté")]
        public void QuandJeClickSurLOngletDeCompte()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
