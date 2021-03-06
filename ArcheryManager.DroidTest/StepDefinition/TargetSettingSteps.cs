﻿using ArcheryManager.DroidTest.Helpers;
using ArcheryManager.Resources;
using NUnit.Framework;
using System.Linq;
using TechTalk.SpecFlow;

namespace ArcheryManager.DroidTest.StepDefinition
{
    [Binding]
    public class TargetSettingSteps
    {
        [Then(@"il n'y a pas le switch de moyenne")]
        public void AlorsIlNYAPasLeSwitchDeMoyenne()
        {
            TestSetting.App.WaitForNoElement("VisibilityAverageSwitch");
        }

        [Then(@"il y a le switch de moyenne")]
        public void AlorsIlYALeSwitchDeMoyenne()
        {
            TestSetting.App.WaitForElement("VisibilityAverageSwitch");
        }

        [Then(@"il y a un message d'erreur")]
        public void AlorsIlYAUnMessageDErreur()
        {
            string error = TranslationHelper.GetTextResource("Error");
            TestSetting.App.WaitForElement(e => e.Text(error));
        }

        [Then(@"je click sur ok")]
        public void AlorsJeClickSurOk()
        {
            string ok = TranslationHelper.GetTextResource("OK");
            TestSetting.App.Tap(e => e.Text(ok));
        }

        [Then(@"le nombre de flèche est activé")]
        public void AlorsLeNombreDeFlecheEstActive()
        {
            TestSetting.App.WaitForElement("numberArrowEntry");
            Assert.IsTrue(TestSetting.App.Query("numberArrowEntry").First().Enabled);
        }

        [Then(@"le nombre de flèche est de (.*)")]
        public void AlorsLeNombreDeFlecheEstDe(int p0)
        {
            TestSetting.App.WaitForElement("numberArrowEntry");
            Assert.AreEqual(p0.ToString(), TestSetting.App.Query("numberArrowEntry").First().Text);
        }

        [Then(@"le nombre de flèche est désactivé")]
        public void AlorsLeNombreDeFlecheEstDesactive()
        {
            TestSetting.App.WaitForNoElement("numberArrowEntry");
        }

        [Then(@"l'option de moyenne est activée")]
        public void AlorsLOptionDeMoyenneEstActivee()
        {
            bool actual = TestSetting.App.Query(e => e.Marked("VisibilityAverageSwitch").Invoke("isChecked").Value<bool>()).First();
            Assert.IsTrue(actual);
        }

        [Then(@"l'option flèche ordonnée est activée")]
        public void AlorsLOptionFlecheOrdonneeEstActivee()
        {
            bool actual = TestSetting.App.Query(e => e.Marked("ArrowsOrderSwitch").Invoke("isChecked").Value<bool>()).First();
            Assert.IsTrue(actual);
        }

        [Then(@"l'option toutes flèches est activée")]
        public void AlorsLOptionToutesFlechesEstActivee()
        {
            bool actual = TestSetting.App.Query(e => e.Marked("ShowAllArrowsSwitch").Invoke("isChecked").Value<bool>()).First();
            Assert.IsTrue(actual);
        }

        [When(@"je click sur le check nombre de flèches défini")]
        public void QuandJeClickSurLeCheckNombreDeFlechesDefini()
        {
            TestSetting.App.WaitForElement("maxArrowsSwitch");
            TestSetting.App.Tap("maxArrowsSwitch");
        }

        [When(@"je remplit le nombre de flèche par (.*)")]
        public void QuandJeRemplitLeNombreDeFlechePar(int p0)
        {
            TestSetting.App.WaitForElement("numberArrowEntry");
            TestSetting.App.ClearText("numberArrowEntry");
            TestSetting.App.EnterText("numberArrowEntry", p0.ToString());
            TestSetting.App.Tap("NumberOfArrowsLabel");
        }

        [When(@"je click sur l option flèche ordonnée")]
        public void WhenJeClickSurLOptionFlecheOrdonnee()
        {
            TestSetting.App.WaitForElement("ArrowsOrderSwitch");
            TestSetting.App.Tap("ArrowsOrderSwitch");
        }
    }
}
