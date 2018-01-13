﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.1.0.0
//      SpecFlow Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace ArcheryManager.DroidTest.Features.Targets
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("TargetSelectorFeature")]
    public partial class TargetSelectorFeatureFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "TargetSelectorFeature.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("fr-FR"), "TargetSelectorFeature", "\ttest du selecteur de cible", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Test de sélection de cible")]
        [NUnit.Framework.TestCaseAttribute("EnglishTarget", new string[0])]
        [NUnit.Framework.TestCaseAttribute("FieldTarget", new string[0])]
        [NUnit.Framework.TestCaseAttribute("IndoorRecurveTarget", new string[0])]
        [NUnit.Framework.TestCaseAttribute("IndoorCompoundTarget", new string[0])]
        public virtual void TestDeSelectionDeCible(string type, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Test de sélection de cible", exampleTags);
#line 6
this.ScenarioSetup(scenarioInfo);
#line 7
 testRunner.When("J\'ouvre une page de sélection de cible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quand ");
#line 8
 testRunner.And(string.Format("je click sur le texte {0}", type), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 9
 testRunner.And("je valide la sélection de cible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 11
 testRunner.Then(string.Format("il y a une cible {0}", type), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Alors ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Test de nombre par défault de flèche")]
        public virtual void TestDeNombreParDefaultDeFleche()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Test de nombre par défault de flèche", ((string[])(null)));
#line 21
this.ScenarioSetup(scenarioInfo);
#line 22
 testRunner.When("J\'ouvre une page de sélection de cible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quand ");
#line 23
 testRunner.And("je click sur le slider de nombre fixe de flèche", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 25
 testRunner.Then("le nombre de flèches est de 6", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Alors ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Test de nombre de flèche par défault")]
        public virtual void TestDeNombreDeFlecheParDefault()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Test de nombre de flèche par défault", ((string[])(null)));
#line 27
this.ScenarioSetup(scenarioInfo);
#line 28
 testRunner.When("J\'ouvre une page de sélection de cible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quand ");
#line 29
 testRunner.And("je valide la sélection de cible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 30
 testRunner.And("je tire une flèche en 0, 0", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 32
 testRunner.Then("le nombre de flèches actuelles sur la cible est de 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Alors ");
#line 33
 testRunner.And("le bouton nouvelle volée est activé", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Test de nombre de flèche défini bouton nouvelle volée désactivé")]
        public virtual void TestDeNombreDeFlecheDefiniBoutonNouvelleVoleeDesactive()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Test de nombre de flèche défini bouton nouvelle volée désactivé", ((string[])(null)));
#line 36
this.ScenarioSetup(scenarioInfo);
#line 37
 testRunner.When("J\'ouvre une page de sélection de cible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quand ");
#line 38
 testRunner.And("je click sur le slider de nombre fixe de flèche", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 39
 testRunner.And("je rentre 5 en nombre de flèche", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 40
 testRunner.And("je valide la sélection de cible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 41
 testRunner.And("je tire une flèche en 0, 0", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 43
 testRunner.Then("le nombre de flèches actuelles sur la cible est de 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Alors ");
#line 44
 testRunner.And("le bouton nouvelle volée est désactivé", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Test de sélection du nombre de flèche")]
        public virtual void TestDeSelectionDuNombreDeFleche()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Test de sélection du nombre de flèche", ((string[])(null)));
#line 47
this.ScenarioSetup(scenarioInfo);
#line 48
 testRunner.When("J\'ouvre une page de sélection de cible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quand ");
#line 49
 testRunner.And("je click sur le slider de nombre fixe de flèche", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 50
 testRunner.And("je rentre 5 en nombre de flèche", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 51
 testRunner.And("je valide la sélection de cible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 52
 testRunner.And("je tire une flèche en 0, 0", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 53
 testRunner.And("je tire une flèche en -4, -30", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 54
 testRunner.And("je tire une flèche en -2, 10", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 55
 testRunner.And("je tire une flèche en 25, 40", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 56
 testRunner.And("je tire une flèche en -10, 20", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 57
 testRunner.And("je tire une flèche en 5, -15", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 59
 testRunner.Then("le nombre de flèches actuelles sur la cible est de 5", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Alors ");
#line 60
 testRunner.And("le bouton nouvelle volée est activé", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Test de sélection de bouton de cible")]
        [NUnit.Framework.TestCaseAttribute("EnglishTarget", new string[0])]
        [NUnit.Framework.TestCaseAttribute("FieldTarget", new string[0])]
        [NUnit.Framework.TestCaseAttribute("IndoorRecurveTarget", new string[0])]
        [NUnit.Framework.TestCaseAttribute("IndoorCompoundTarget", new string[0])]
        public virtual void TestDeSelectionDeBoutonDeCible(string type, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Test de sélection de bouton de cible", exampleTags);
#line 63
this.ScenarioSetup(scenarioInfo);
#line 64
 testRunner.When("J\'ouvre une page de sélection de cible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quand ");
#line 65
 testRunner.And(string.Format("je click sur le texte {0}", type), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 66
 testRunner.And("je click sur l\'option cible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 67
 testRunner.And("je valide la sélection de cible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 69
 testRunner.Then(string.Format("il y a des boutons de {0}", type), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Alors ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Test de retour après un selector")]
        public virtual void TestDeRetourApresUnSelector()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Test de retour après un selector", ((string[])(null)));
#line 79
this.ScenarioSetup(scenarioInfo);
#line 80
 testRunner.When("J\'ouvre une page de menu general", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quand ");
#line 81
 testRunner.And("je click sur le bouton de tir compté", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 82
 testRunner.And("je valide la sélection de cible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 83
 testRunner.And("j\'attend 5 secondes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 84
 testRunner.And("je reviens à la page d\'avant", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 85
 testRunner.And("je click sur le texte Yes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 87
 testRunner.Then("il y a le titre de backdoor", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Alors ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
