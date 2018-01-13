using ArcheryManager.DroidTest.Helpers;
using ArcheryManager.Resources;
using NUnit.Framework;
using System;
using System.Linq;
using TechTalk.SpecFlow;
using Xamarin.UITest.Queries;

namespace ArcheryManager.DroidTest.StepDefinition
{
    [Binding]
    public class RemarksEditionSteps
    {
        [Then(@"il y a le bouton d'historique de remarque de volée")]
        public void AlorsIlYALeBoutonDHistoriqueDeRemarqueDeVolee()
        {
            string history = TranslationHelper.GetTextResource("History");
            TestSetting.App.WaitForElement(e => e.Marked("generalRemarkEditor").Child().Child().Child().Child().Text(history));
        }

        [Then(@"il y a le bouton d'historique de remarque générales")]
        public void AlorsIlYALeBoutonDHistoriqueDeRemarqueGenerales()
        {
            string history = TranslationHelper.GetTextResource("History");
            TestSetting.App.WaitForElement(e => e.Marked("generalRemarkEditor").Child().Child().Child().Child().Text(history));
        }

        [Then(@"il y a l'éditeur de remarques de la volée")]
        public void AlorsIlYALEditeurDeRemarquesDeLaVolee()
        {
            TestSetting.App.WaitForElement("flightRemarkEditor");
        }

        [Then(@"il y a l'éditeur de remarques générales")]
        public void AlorsIlYALEditeurDeRemarquesGenerales()
        {
            TestSetting.App.WaitForElement("generalRemarkEditor");
        }

        [Then(@"le bouton validé des remarques de la volée est utilisable")]
        public void AlorsLeBoutonValideDesRemarquesDeLaVoleeEstUtilisable()
        {
            ButtonValidCheck("flightRemarkEditor", enabledWanted: true);
        }

        [Then(@"le bouton validé des remarques de la volée n'est pas utilisable")]
        public void AlorsLeBoutonValideDesRemarquesDeLaVoleeNEstPasUtilisable()
        {
            ButtonValidCheck("flightRemarkEditor", enabledWanted: false);
        }

        [Then(@"le bouton validé des remarques général est utilisable")]
        public void AlorsLeBoutonValideDesRemarquesGeneralEstUtilisable()
        {
            ButtonValidCheck("generalRemarkEditor", enabledWanted: true);
        }

        [Then(@"le bouton validé des remarques général n'est pas utilisable")]
        public void AlorsLeBoutonValideDesRemarquesGeneralNEstPasUtilisable()
        {
            ButtonValidCheck("generalRemarkEditor", enabledWanted: false);
        }

        [Then(@"le text de l'éditeur de remarque de la volée est ""(.*)""")]
        public void AlorsLeTextDeLEditeurDeRemarqueDeLaVoleeEst(string text)
        {
            ChecktextOfEditor("flightRemarkEditor", text);
        }

        [Then(@"le text de l'éditeur de remarque de la volée est emptyMessage")]
        public void AlorsLeTextDeLEditeurDeRemarqueDeLaVoleeEstEmptyMessage()
        {
            TestSetting.App.WaitForElement("flightRemarkEditor");
            var emptyT = TranslationHelper.GetTextResource("EnterRemarksHere");
            ChecktextOfEditor("flightRemarkEditor", emptyT);
        }

        [Then(@"le text de l'éditeur de remarque générales est ""(.*)""")]
        public void AlorsLeTextDeLEditeurDeRemarqueGeneralesEst(string text)
        {
            ChecktextOfEditor("generalRemarkEditor", text);
        }

        [Then(@"le text de l'éditeur de remarque générales est emptyMessage")]
        public void AlorsLeTextDeLEditeurDeRemarqueGeneralesEstEmptyMessage()
        {
            var emptyT = TranslationHelper.GetTextResource("EnterRemarksHere");
            ChecktextOfEditor("generalRemarkEditor", emptyT);
        }

        [When(@"je click sur le bouton de validation des remarques de la volée")]
        public void QuandJeClickSurLeBoutonDeValidationDesRemarquesDeLaVolee()
        {
            TestSetting.App.Tap(GetValidButtonQuery("flightRemarkEditor"));
        }

        [When(@"je click sur le bouton de validation des remarques générales")]
        public void QuandJeClickSurLeBoutonDeValidationDesRemarquesGenerales()
        {
            TestSetting.App.Tap(GetValidButtonQuery("generalRemarkEditor"));
        }

        [When(@"je rentre ""(.*)"" dans l'éditeur de remarque de la volée")]
        public void QuandJeRentreDansLEditeurDeRemarqueDeLaVolee(string text)
        {
            TestSetting.App.EnterText(e => e.Marked("flightRemarkEditor").Child(0).Child(1), text);
        }

        [When(@"je rentre ""(.*)"" dans l'éditeur de remarque générales")]
        public void QuandJeRentreDansLEditeurDeRemarqueGenerales(string text)
        {
            TestSetting.App.EnterText(e => e.Marked("generalRemarkEditor").Child(0).Child(1), text);
            TestSetting.App.DismissKeyboard();
        }

        private static void ButtonValidCheck(string parentName, bool enabledWanted)
        {
            var query = GetValidButtonQuery(parentName);

            TestSetting.App.WaitForElement(query);
            var button = TestSetting.App.Query(query).First();
            bool enabled = button.Enabled;
            Assert.AreEqual(enabledWanted, enabled);
        }

        private static void ChecktextOfEditor(string parentName, string wantedText)
        {
            var text = TestSetting.App.Query(e => e.Marked(parentName).Child(0).Child().Child()).Last().Text;
            Assert.AreEqual(wantedText, text);
        }

        private static Func<AppQuery, AppQuery> GetValidButtonQuery(string parentName)
        {
            string valid = TranslationHelper.GetTextResource("Valid");
            Func<AppQuery, AppQuery> query = e => e.Marked(parentName).Child().Child().Child().Child().Text(valid);
            return query;
        }
    }
}
