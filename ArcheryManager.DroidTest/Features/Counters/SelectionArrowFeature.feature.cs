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
    [NUnit.Framework.DescriptionAttribute("SelectionArrowFeature")]
    public partial class SelectionArrowFeatureFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "SelectionArrowFeature.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("fr-FR"), "SelectionArrowFeature", "\ttest de la sélection et du blocage d\'ajout de flèche", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        [NUnit.Framework.DescriptionAttribute("test blocage d\'ajout de flèche durant une sélection dans une cible")]
        public virtual void TestBlocageDAjoutDeFlecheDurantUneSelectionDansUneCible()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("test blocage d\'ajout de flèche durant une sélection dans une cible", ((string[])(null)));
#line 6
this.ScenarioSetup(scenarioInfo);
#line 7
 testRunner.When("J\'ouvre une page de cible fita", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quand ");
#line 8
 testRunner.And("je tire une flèche en -10, 20", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 9
 testRunner.And("je tire une flèche en -50, 100", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 10
 testRunner.And("je tire une flèche en 200, 50", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 11
 testRunner.And("je sélectionne la flèche 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 12
 testRunner.And("je tire une flèche en -50, 100", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 14
 testRunner.Then("le nombre de flèches dans la liste est de 3", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Alors ");
#line 15
 testRunner.And("le message d\'erreur d\'ajout pendant sélection est affiché", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("test blocage d\'ajout de flèche durant une sélection dans une zapette")]
        public virtual void TestBlocageDAjoutDeFlecheDurantUneSelectionDansUneZapette()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("test blocage d\'ajout de flèche durant une sélection dans une zapette", ((string[])(null)));
#line 17
this.ScenarioSetup(scenarioInfo);
#line 18
 testRunner.When("J\'ouvre une page zappette", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quand ");
#line 19
 testRunner.And("je click sur le boutton 3", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 20
 testRunner.And("je click sur le boutton 5", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 21
 testRunner.And("je click sur le boutton 8", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 22
 testRunner.And("je sélectionne la flèche 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 23
 testRunner.And("je click sur le boutton 9", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 25
 testRunner.Then("le nombre de flèches dans la liste est de 3", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Alors ");
#line 26
 testRunner.And("le message d\'erreur d\'ajout pendant sélection est affiché", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("test déblocage d\'ajout de flèche après une sélection dans une zapette")]
        public virtual void TestDeblocageDAjoutDeFlecheApresUneSelectionDansUneZapette()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("test déblocage d\'ajout de flèche après une sélection dans une zapette", ((string[])(null)));
#line 28
this.ScenarioSetup(scenarioInfo);
#line 29
 testRunner.When("J\'ouvre une page zappette", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quand ");
#line 30
 testRunner.And("je click sur le boutton 3", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 31
 testRunner.And("je click sur le boutton 5", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 32
 testRunner.And("je click sur le boutton 8", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 33
 testRunner.And("je sélectionne la flèche 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 34
 testRunner.And("je sélectionne la flèche 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 35
 testRunner.And("je click sur le boutton 9", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 37
 testRunner.Then("le nombre de flèches dans la liste est de 4", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Alors ");
#line 38
 testRunner.And("le message d\'erreur d\'ajout pendant sélection n\'est pas affiché", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("test déblocage d\'ajout de flèche après une sélection dans une cible")]
        public virtual void TestDeblocageDAjoutDeFlecheApresUneSelectionDansUneCible()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("test déblocage d\'ajout de flèche après une sélection dans une cible", ((string[])(null)));
#line 41
this.ScenarioSetup(scenarioInfo);
#line 42
 testRunner.When("J\'ouvre une page de cible fita", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quand ");
#line 43
 testRunner.And("je tire une flèche en -10, 20", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 44
 testRunner.And("je tire une flèche en -50, 100", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 45
 testRunner.And("je tire une flèche en 200, 50", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 46
 testRunner.And("je sélectionne la flèche 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 47
 testRunner.And("je sélectionne la flèche 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 48
 testRunner.And("je tire une flèche en 50, 100", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 51
 testRunner.Then("le nombre de flèches dans la liste est de 4", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Alors ");
#line 52
 testRunner.And("le message d\'erreur d\'ajout pendant sélection n\'est pas affiché", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("test de retour des boutons apres une sélection sur une cible")]
        public virtual void TestDeRetourDesBoutonsApresUneSelectionSurUneCible()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("test de retour des boutons apres une sélection sur une cible", ((string[])(null)));
#line 56
this.ScenarioSetup(scenarioInfo);
#line 57
 testRunner.When("J\'ouvre une page de cible fita", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quand ");
#line 58
 testRunner.And("je tire une flèche en 0, 100", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 59
 testRunner.And("je sélectionne la flèche 0", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 60
 testRunner.And("je sélectionne la flèche 0", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 62
 testRunner.Then("il y a 3 boutons dans la barre de menu", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Alors ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("test de retour des boutons apres une sélection sur une zapette")]
        public virtual void TestDeRetourDesBoutonsApresUneSelectionSurUneZapette()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("test de retour des boutons apres une sélection sur une zapette", ((string[])(null)));
#line 65
this.ScenarioSetup(scenarioInfo);
#line 66
 testRunner.When("J\'ouvre une page zappette", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quand ");
#line 67
 testRunner.And("je click sur le boutton 4", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 68
 testRunner.And("je sélectionne la flèche 0", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 69
 testRunner.And("je sélectionne la flèche 0", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 71
 testRunner.Then("il y a 3 boutons dans la barre de menu", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Alors ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("test de changement des boutons lors d\'un changement de page apres une sélection s" +
            "ur une zapette")]
        public virtual void TestDeChangementDesBoutonsLorsDUnChangementDePageApresUneSelectionSurUneZapette()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("test de changement des boutons lors d\'un changement de page apres une sélection s" +
                    "ur une zapette", ((string[])(null)));
#line 74
this.ScenarioSetup(scenarioInfo);
#line 75
 testRunner.When("J\'ouvre une page zappette", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quand ");
#line 76
 testRunner.And("je click sur le boutton 4", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 77
 testRunner.And("je sélectionne la flèche 0", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 78
    testRunner.And("je click sur l\'onglet de remarque", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 80
 testRunner.Then("il y a 0 boutons dans la barre de menu", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Alors ");
#line 82
 testRunner.When("je reviens à la page d\'avant", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quand ");
#line 83
 testRunner.And("je click sur le texte Yes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 84
 testRunner.And("J\'ouvre une page tabbed de cible fita", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 85
 testRunner.And("je tire une flèche en 10, 10", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 86
 testRunner.And("je sélectionne la flèche 0", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 87
    testRunner.And("je click sur l\'onglet de remarque", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 89
 testRunner.Then("il y a 0 boutons dans la barre de menu", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Alors ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("test de boutons de sélection apres un retour")]
        public virtual void TestDeBoutonsDeSelectionApresUnRetour()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("test de boutons de sélection apres un retour", ((string[])(null)));
#line 91
this.ScenarioSetup(scenarioInfo);
#line 92
 testRunner.When("J\'ouvre une page tabbed de cible fita", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quand ");
#line 93
 testRunner.And("je tire une flèche en 0, 0", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 94
 testRunner.And("je sélectionne la flèche 0", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 95
 testRunner.And("je click sur le tab timer", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 96
 testRunner.Then("il y a 3 boutons dans la barre de menu", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Alors ");
#line 98
 testRunner.When("je click sur l\'onglet de compté", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quand ");
#line 99
 testRunner.Then("il y a 2 boutons dans la barre de navigation", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Alors ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
