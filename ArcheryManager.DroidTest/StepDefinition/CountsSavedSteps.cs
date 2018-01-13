using ArcheryManager.DroidTest.Helpers;
using NUnit.Framework;
using System.Linq;
using TechTalk.SpecFlow;

namespace ArcheryManager.DroidTest.StepDefinition
{
    [Binding]
    public class CountsSavedSteps
    {
        [Then(@"il y a (.*) tir sauvegardé")]
        public void AlorsIlYATirSauvegarde(int p0)
        {
            TestSetting.App.WaitForElement("shootList");
            int value = TestSetting.App.Query(e => e.Marked("shootList").Child()).Count() - 2;
            if (value < 0)
                value = 0;
            Assert.AreEqual(p0, value);
        }

        [Then(@"il y a une page de tir sauvegarder")]
        public void AlorsIlYAUnePageDeTirSauvegarder()
        {
            TestSetting.App.WaitForElement("shootList");
        }

        [Then(@"la date du tir compté (.*) est aujourd'hui")]
        public void AlorsLaDateDuTirCompteEstAujourdHui(int p0)
        {
            TestSetting.App.WaitForElement("shootList");
            string actual = TestSetting.App.Query(e => e.Marked("shootList").Child(1).Child(0).Child(0).Child(0)).First().Text;
            var now = DeviceHelper.GetDeviceTime();

            string expected = now.ToString("dd MMMM yyyy");

            Assert.AreEqual(expected, actual);
        }

        [Then(@"le score du tir sauvegardé (.*) est (.*)")]
        public void AlorsLeScoreDuTirSauvegardeEst(int countIndex, string score)
        {
            TestSetting.App.Query("shootList");
            string actual = TestSetting.App.Query(e => e.Marked("shootList").Child(countIndex + 2).Child(0).Child().Child(1).Child(0)).First().Text;
            Assert.AreEqual(score, actual);
        }

        [Then(@"le status du tir sauvegardé (.*) est (.*)")]
        public void AlorsLeStatusDuTirSauvegardeEstFinish(int countIndex, string status)
        {
            TestSetting.App.Query("shootList");
            string actual = TestSetting.App.Query(e => e.Marked("shootList").Child(countIndex + 2).Child(0).Child().Child(2).Child(0)).First().Text;
            Assert.AreEqual(TranslationHelper.GetTextResource(status), actual);
        }

        [Then(@"le tir sauvegardé (.*) a pour type (.*)")]
        public void AlorsLeTirSauvegardeAPourType(int p0, string type)
        {
            TestSetting.App.WaitForElement("shootList");
            string actual = TestSetting.App.Query(e => e.Marked("shootList").Child(p0 + 2).Child(0).Child(0).Child(0).Child(0)).First().Text;
            string expected = TranslationHelper.GetTextResource(type);

            Assert.AreEqual(expected, actual);
        }

        [When(@"je click sur le switch des tirs finis")]
        public void QuandJeClickSurLeSwitchDesTirsFinis()
        {
            TestSetting.App.Tap("finishSwitch");
        }

        [When(@"je click sur le switch des tirs non finis")]
        public void QuandJeClickSurLeSwitchDesTirsNonFinis()
        {
            TestSetting.App.Tap("notFinishSwitch");
        }

        [When(@"j'ouvre le tir sauvegardé (.*)")]
        public void QuandJOuvreLeTirSauvegarde(int p0)
        {
            TestSetting.App.WaitForElement("shootList");
            TestSetting.App.Tap(e => e.Marked("shootList").Child(p0 + 2));
            TestSetting.App.Tap(TranslationHelper.GetTextResource("Open"));
        }

        [When(@"le tir sauvegardé (.*) a pour score (.*)")]
        public void QuandLeTirSauvegardeAPourScore(int countIndex, string score)
        {
            TestSetting.App.WaitForElement("shootList");
            string actual = TestSetting.App.Query(e => e.Marked("shootList").Child(countIndex + 2).Child(0).Child().Child(1).Child(0)).First().Text;

            Assert.AreEqual(score, actual);
        }
    }
}
