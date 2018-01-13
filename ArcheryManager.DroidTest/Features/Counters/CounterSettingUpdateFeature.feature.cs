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
namespace ArcheryManager.DroidTest.Features.Counters
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("CounterSettingUpdateFeature")]
    public partial class CounterSettingUpdateFeatureFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CounterSettingUpdateFeature.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("fr-FR"), "CounterSettingUpdateFeature", null, ProgrammingLanguage.CSharp, ((string[])(null)));
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
        [NUnit.Framework.DescriptionAttribute("test passage de zappette à cible")]
        public virtual void TestPassageDeZappetteACible()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("test passage de zappette à cible", ((string[])(null)));
#line 5
this.ScenarioSetup(scenarioInfo);
#line 6
  testRunner.When("J\'ouvre une page de sélection de cible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quand ");
#line 7
  testRunner.And("je click sur l\'option cible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 8
  testRunner.And("je valide la sélection de cible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 9
  testRunner.And("j\'ouvre le menu de paramètre", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 10
  testRunner.Then("il n\'y a pas le switch de moyenne", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Alors ");
#line 12
  testRunner.When("je reviens à la page d\'avant", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quand ");
#line 13
  testRunner.When("je reviens à la page d\'avant", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quand ");
#line 14
  testRunner.And("je click sur le texte Yes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 15
  testRunner.And("J\'ouvre une page de sélection de cible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 17
  testRunner.And("je valide la sélection de cible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 18
  testRunner.And("j\'ouvre le menu de paramètre", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 19
  testRunner.Then("il y a le switch de moyenne", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Alors ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("test nombre de flèche endessous de l\'actuel")]
        public virtual void TestNombreDeFlecheEndessousDeLActuel()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("test nombre de flèche endessous de l\'actuel", ((string[])(null)));
#line 23
this.ScenarioSetup(scenarioInfo);
#line 24
  testRunner.When("J\'ouvre une page de cible fita", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quand ");
#line 25
  testRunner.And("je tire une flèche en 30, 40", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 26
  testRunner.And("je tire une flèche en 80, 20", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 27
  testRunner.And("je tire une flèche en 30, 80", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 28
  testRunner.And("je tire une flèche en 30, 80", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 29
  testRunner.And("je tire une flèche en 30, 50", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 30
  testRunner.And("j\'ouvre le menu de paramètre", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 31
  testRunner.And("je click sur le check nombre de flèches défini", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 32
  testRunner.And("je rentre 4 en nombre de flèche", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 33
  testRunner.And("je click sur le texte NumberOfArrows", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 34
  testRunner.Then("il y a un message d\'erreur", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Alors ");
#line 35
  testRunner.And("je click sur ok", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 36
  testRunner.Then("le nombre de flèches est de 5", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Alors ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("test nombre de flèche endessous de l\'actuel et du minimum")]
        public virtual void TestNombreDeFlecheEndessousDeLActuelEtDuMinimum()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("test nombre de flèche endessous de l\'actuel et du minimum", ((string[])(null)));
#line 40
this.ScenarioSetup(scenarioInfo);
#line 41
  testRunner.When("J\'ouvre une page de cible fita", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quand ");
#line 42
  testRunner.And("je tire une flèche en 30, 40", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 43
  testRunner.And("je tire une flèche en 80, 20", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 44
  testRunner.And("je tire une flèche en 30, 80", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 45
  testRunner.And("je tire une flèche en 30, 80", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 46
  testRunner.And("j\'ouvre le menu de paramètre", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 47
  testRunner.And("je click sur le check nombre de flèches défini", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 48
  testRunner.And("je rentre 1 en nombre de flèche", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 49
  testRunner.And("je click sur le texte NumberOfArrows", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 50
  testRunner.Then("il y a un message d\'erreur", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Alors ");
#line 51
  testRunner.And("je click sur ok", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 52
  testRunner.Then("le nombre de flèches est de 4", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Alors ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
