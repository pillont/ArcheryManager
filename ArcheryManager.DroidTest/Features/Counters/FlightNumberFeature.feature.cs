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
    [NUnit.Framework.DescriptionAttribute("FlightNumberFeature")]
    public partial class FlightNumberFeatureFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "FlightNumberFeature.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("fr-FR"), "FlightNumberFeature", null, ProgrammingLanguage.CSharp, ((string[])(null)));
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
        [NUnit.Framework.DescriptionAttribute("test du numéro de volée par défault")]
        public virtual void TestDuNumeroDeVoleeParDefault()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("test du numéro de volée par défault", ((string[])(null)));
#line 4
this.ScenarioSetup(scenarioInfo);
#line 5
 testRunner.When("J\'ouvre une page de cible fita", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quand ");
#line 6
 testRunner.Then("le numero de la volée est 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Alors ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("test du changement de numéro de volée")]
        public virtual void TestDuChangementDeNumeroDeVolee()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("test du changement de numéro de volée", ((string[])(null)));
#line 9
this.ScenarioSetup(scenarioInfo);
#line 10
 testRunner.When("J\'ouvre une page de cible fita", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quand ");
#line 11
 testRunner.And("je tire une flèche en 0, 0", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 12
 testRunner.And("Je click sur le bouton nouvelle volée", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 13
 testRunner.Then("le numero de la volée est 2", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Alors ");
#line 15
 testRunner.When("je tire une flèche en 0, 0", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quand ");
#line 16
 testRunner.And("Je click sur le bouton nouvelle volée", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 17
 testRunner.Then("le numero de la volée est 3", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Alors ");
#line 21
 testRunner.When("je click sur le bouton de restart", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quand ");
#line 22
 testRunner.Then("le numero de la volée est 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Alors ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
