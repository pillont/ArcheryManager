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
    [NUnit.Framework.DescriptionAttribute("SpecificCounterSettingFeature")]
    public partial class SpecificCounterSettingFeatureFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "SpecificCounterSettingFeature.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("fr-FR"), "SpecificCounterSettingFeature", "\ttest des paramètres spécifique", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        [NUnit.Framework.DescriptionAttribute("test du bouton terminé")]
        public virtual void TestDuBoutonTermine()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("test du bouton terminé", ((string[])(null)));
#line 5
this.ScenarioSetup(scenarioInfo);
#line 6
 testRunner.When("J\'ouvre une page zappette", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quand ");
#line 7
 testRunner.And("j\'ouvre le menu de paramètre", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 8
 testRunner.And("je click sur le check nombre de flèches défini", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 9
 testRunner.And("je remplit le nombre de flèche par 3", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 10
 testRunner.And("je click sur le texte Finish", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 11
 testRunner.And("je click sur le boutton 3", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 12
 testRunner.And("je click sur le boutton 5", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 13
 testRunner.And("je click sur le boutton 8", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 14
 testRunner.And("je click sur le boutton 10", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 16
 testRunner.Then("le nombre de flèches dans la liste est de 3", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Alors ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion