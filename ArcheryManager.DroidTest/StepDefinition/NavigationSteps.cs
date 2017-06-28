using System;
using TechTalk.SpecFlow;

namespace ArcheryManager.DroidTest.StepDefinition
{
    [Binding]
    public class NavigationSteps
    {
        [When(@"je reviens à la page d'avant")]
        public void WhenJeReviensALaPageDAvant()
        {
            TestSetting.App.Back();
        }
    }
}
