namespace ArcheryManager.DroidTest.Helpers
{
    public class TranslationHelper
    {
        public static string GetTextResource(string key)
        {
            return TestSetting.App.Invoke("GetTranslation", key) as string;
        }
    }
}
