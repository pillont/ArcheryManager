using ArcheryManager.Settings.ArrowSettings;
using TechTalk.SpecFlow;

namespace ArcheryManager.DroidTest.StepDefinition
{
    [Binding]
    public class TargetSettingFeatureSteps
    {
        [When(@"je click sur le boutton (.*)")]
        public void QuandJeClickSurLeBoutton(string p0)
        {
            if (!EnglishArrowSetting.Instance.IsScoreExisted(p0))
            {
                throw new System.Exception();
            }
            TestSetting.App.WaitForElement("buttonGrid");
            TestSetting.App.Tap(e => e.Marked("buttonGrid").Child().Child().Child().Text(p0));
        }
    }
}
