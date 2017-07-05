﻿using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace ArcheryManager.DroidTest.StepDefinition
{
    [Binding]
    public class DeviceInteractionSteps
    {
        [When(@"je reviens à la page d'avant")]
        public void WhenJeReviensALaPageDAvant()
        {
            TestSetting.App.Back();
        }

        [When(@"je tourne le téléphone")]
        public void QuandJeTourneLeTelephone()
        {
            TestSetting.App.SetOrientationLandscape();
        }

        [When(@"j'attend (.*) secondes")]
        public void QuandJAttendSecondes(int p0)
        {
            Thread.Sleep(p0 * 1000);
        }
    }
}