using System;
using TechTalk.SpecFlow;

namespace ArcheryManager.DroidTest.StepDefinition
{
    [Binding]
    public class ConnectedShootSteps
    {
        [Then(@"il y a le champs de connection")]
        public void AlorsIlYALeChampsDeConnection()
        {
            TestSetting.App.WaitForElement("ConnectButton");
        }

        [Then(@"il y a le champs d'email")]
        public void AlorsIlYALeChampsDEmail()
        {
            TestSetting.App.WaitForElement("EmailEntry");
        }
    }
}
