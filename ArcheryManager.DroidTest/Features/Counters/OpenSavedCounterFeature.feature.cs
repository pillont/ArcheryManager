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
    [NUnit.Framework.DescriptionAttribute("OpenSavedCounterFeature")]
    public partial class OpenSavedCounterFeatureFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "OpenSavedCounterFeature.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("fr-FR"), "OpenSavedCounterFeature", null, ProgrammingLanguage.CSharp, ((string[])(null)));
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
        [NUnit.Framework.DescriptionAttribute("test d\'ouverture de liste de tir vide")]
        public virtual void TestDOuvertureDeListeDeTirVide()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("test d\'ouverture de liste de tir vide", ((string[])(null)));
#line 4
this.ScenarioSetup(scenarioInfo);
#line 5
 testRunner.When("j\'ouvre une page de tir sauvegardé", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quand ");
#line 6
 testRunner.Then("il y a le texte EmptyList", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Alors ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("test d\'ouverture de liste de tir dans le menu general")]
        public virtual void TestDOuvertureDeListeDeTirDansLeMenuGeneral()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("test d\'ouverture de liste de tir dans le menu general", ((string[])(null)));
#line 9
this.ScenarioSetup(scenarioInfo);
#line 10
 testRunner.When("J\'ouvre une page de menu general", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quand ");
#line 11
 testRunner.And("je click sur le texte Saves", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 13
 testRunner.Then("il y a une page de tir sauvegarder", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Alors ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("test de score d\'un tir sauvegardé redémarré")]
        public virtual void TestDeScoreDUnTirSauvegardeRedemarre()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("test de score d\'un tir sauvegardé redémarré", ((string[])(null)));
#line 15
this.ScenarioSetup(scenarioInfo);
#line 16
 testRunner.When("J\'ouvre une page de sélection de cible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quand ");
#line 17
 testRunner.And("je valide la sélection de cible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 18
 testRunner.And("je tire une flèche en 0, 100", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 19
 testRunner.And("je tire une flèche en 0, 100", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 20
 testRunner.And("Je click sur le bouton nouvelle volée", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 21
 testRunner.And("je tire une flèche en 0, 100", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 22
 testRunner.And("je tire une flèche en 0, 100", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 23
 testRunner.And("je click sur le bouton de restart", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 25
 testRunner.And("je reviens à la page d\'avant", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 26
 testRunner.And("je click sur le texte Yes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 27
 testRunner.And("j\'ouvre une page de tir sauvegardé", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 29
 testRunner.Then("le score du tir sauvegardé 0 est 0/0", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Alors ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("test de filtrage des tirs sauvegardés dans la liste")]
        public virtual void TestDeFiltrageDesTirsSauvegardesDansLaListe()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("test de filtrage des tirs sauvegardés dans la liste", ((string[])(null)));
#line 32
this.ScenarioSetup(scenarioInfo);
#line 33
 testRunner.When("J\'ouvre une page de sélection de cible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quand ");
#line 34
 testRunner.And("je valide la sélection de cible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 35
 testRunner.And("j\'attend 5 secondes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 36
 testRunner.And("je reviens à la page d\'avant", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 38
 testRunner.And("je click sur le texte Yes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 40
 testRunner.And("J\'ouvre une page de sélection de cible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 41
 testRunner.And("je valide la sélection de cible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 42
 testRunner.And("je tire une flèche en 0, 50", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 43
 testRunner.And("je click sur le texte Finish", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 44
 testRunner.And("je reviens à la page d\'avant", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 46
 testRunner.And("j\'ouvre une page de tir sauvegardé", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 48
 testRunner.Then("il y a 2 tir sauvegardé", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Alors ");
#line 49
 testRunner.And("le score du tir sauvegardé 0 est 10/10", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 50
 testRunner.And("le score du tir sauvegardé 1 est 0/0", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 52
 testRunner.When("je click sur le switch des tirs finis", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quand ");
#line 53
 testRunner.Then("il y a 1 tir sauvegardé", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Alors ");
#line 54
 testRunner.And("le score du tir sauvegardé 0 est 0/0", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 56
 testRunner.When("je click sur le switch des tirs finis", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quand ");
#line 57
 testRunner.When("je click sur le switch des tirs non finis", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quand ");
#line 58
 testRunner.Then("il y a 1 tir sauvegardé", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Alors ");
#line 59
 testRunner.And("le score du tir sauvegardé 0 est 10/10", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 61
 testRunner.When("je click sur le switch des tirs finis", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quand ");
#line 62
 testRunner.Then("il y a 0 tir sauvegardé", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Alors ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("test de status des tirs sauvegardés dans la liste")]
        public virtual void TestDeStatusDesTirsSauvegardesDansLaListe()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("test de status des tirs sauvegardés dans la liste", ((string[])(null)));
#line 64
this.ScenarioSetup(scenarioInfo);
#line 65
 testRunner.When("J\'ouvre une page de sélection de cible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quand ");
#line 66
 testRunner.And("je valide la sélection de cible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 67
 testRunner.And("j\'attend 5 secondes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 68
 testRunner.And("je reviens à la page d\'avant", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 70
 testRunner.And("je click sur le texte Yes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 72
 testRunner.And("J\'ouvre une page de sélection de cible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 73
 testRunner.And("je valide la sélection de cible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 74
 testRunner.And("je tire une flèche en 0, 100", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 75
 testRunner.And("je click sur le texte Finish", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 76
 testRunner.And("je reviens à la page d\'avant", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 78
 testRunner.And("j\'ouvre une page de tir sauvegardé", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 80
 testRunner.Then("il y a 2 tir sauvegardé", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Alors ");
#line 81
 testRunner.And("le status du tir sauvegardé 0 est Finished", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 82
 testRunner.And("le status du tir sauvegardé 1 est InProgress", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("test de score d\'un tir sauvegardé")]
        public virtual void TestDeScoreDUnTirSauvegarde()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("test de score d\'un tir sauvegardé", ((string[])(null)));
#line 84
this.ScenarioSetup(scenarioInfo);
#line 85
 testRunner.When("J\'ouvre une page de sélection de cible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quand ");
#line 86
 testRunner.And("je valide la sélection de cible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 87
 testRunner.And("je tire une flèche en 0, 100", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 88
 testRunner.And("je tire une flèche en 0, 100", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 89
 testRunner.And("Je click sur le bouton nouvelle volée", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 90
 testRunner.And("je tire une flèche en 0, 100", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 91
 testRunner.And("je tire une flèche en 0, 100", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 92
 testRunner.And("je reviens à la page d\'avant", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 93
 testRunner.And("je click sur le texte Yes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 94
 testRunner.And("j\'ouvre une page de tir sauvegardé", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 96
 testRunner.Then("le score du tir sauvegardé 0 est 36/40", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Alors ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("test de sauvegarde d\'un compté dans une liste")]
        [NUnit.Framework.TestCaseAttribute("EnglishTarget", new string[0])]
        [NUnit.Framework.TestCaseAttribute("FieldTarget", new string[0])]
        [NUnit.Framework.TestCaseAttribute("IndoorRecurveTarget", new string[0])]
        [NUnit.Framework.TestCaseAttribute("IndoorCompoundTarget", new string[0])]
        public virtual void TestDeSauvegardeDUnCompteDansUneListe(string type, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("test de sauvegarde d\'un compté dans une liste", exampleTags);
#line 100
this.ScenarioSetup(scenarioInfo);
#line 101
 testRunner.When("J\'ouvre une page de sélection de cible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quand ");
#line 102
 testRunner.And(string.Format("je click sur le texte {0}", type), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 103
 testRunner.And("je valide la sélection de cible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 104
 testRunner.And("j\'attend 5 secondes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 105
 testRunner.And("je reviens à la page d\'avant", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 106
 testRunner.And("je click sur le texte Yes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 107
 testRunner.And("j\'ouvre une page de tir sauvegardé", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 109
 testRunner.Then("il y a 1 tir sauvegardé", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Alors ");
#line 110
 testRunner.And(string.Format("le tir sauvegardé 0 a pour type {0}", type), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 111
 testRunner.And("la date du tir compté 0 est aujourd\'hui", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("test de sauvegarde d\'un score de compté dans une liste")]
        public virtual void TestDeSauvegardeDUnScoreDeCompteDansUneListe()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("test de sauvegarde d\'un score de compté dans une liste", ((string[])(null)));
#line 120
this.ScenarioSetup(scenarioInfo);
#line 121
 testRunner.When("J\'ouvre une page de sélection de cible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quand ");
#line 122
 testRunner.And("je click sur l\'option cible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 123
 testRunner.And("je valide la sélection de cible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 124
 testRunner.And("je click sur le boutton 10", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 125
 testRunner.And("je click sur le boutton 9", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 126
 testRunner.And("je click sur le boutton 8", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 127
 testRunner.And("je click sur le boutton 7", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 129
 testRunner.And("je reviens à la page d\'avant", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 130
 testRunner.And("je click sur le texte Yes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 131
 testRunner.And("j\'ouvre une page de tir sauvegardé", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 133
 testRunner.And("le tir sauvegardé 0 a pour score 34/40", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("test d\'ouverture d une page de resultat depuis une liste")]
        public virtual void TestDOuvertureDUnePageDeResultatDepuisUneListe()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("test d\'ouverture d une page de resultat depuis une liste", ((string[])(null)));
#line 136
this.ScenarioSetup(scenarioInfo);
#line 137
 testRunner.When("J\'ouvre une page de sélection de cible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quand ");
#line 138
 testRunner.And("je valide la sélection de cible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 139
 testRunner.And("je tire une flèche en 0, 100", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 140
 testRunner.And("je click sur le texte Finish", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 141
 testRunner.And("je reviens à la page d\'avant", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 142
 testRunner.And("j\'ouvre une page de tir sauvegardé", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 143
 testRunner.And("j\'ouvre le tir sauvegardé 0", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 145
 testRunner.Then("une vue de bilan de compté s\'ouvre", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Alors ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("test de sauvegarde de plusieurs comptés dans une liste")]
        public virtual void TestDeSauvegardeDePlusieursComptesDansUneListe()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("test de sauvegarde de plusieurs comptés dans une liste", ((string[])(null)));
#line 148
this.ScenarioSetup(scenarioInfo);
#line 149
 testRunner.When("J\'ouvre une page de sélection de cible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quand ");
#line 151
 testRunner.And("je valide la sélection de cible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 152
 testRunner.And("j\'attend 5 secondes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 153
 testRunner.And("je reviens à la page d\'avant", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 154
 testRunner.And("je click sur le texte Yes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 156
 testRunner.When("J\'ouvre une page de sélection de cible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quand ");
#line 157
 testRunner.And("je click sur le texte FieldTarget", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 158
 testRunner.And("je valide la sélection de cible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 159
 testRunner.And("j\'attend 5 secondes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 160
 testRunner.And("je reviens à la page d\'avant", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 161
 testRunner.And("je click sur le texte Yes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 163
 testRunner.When("J\'ouvre une page de sélection de cible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quand ");
#line 164
 testRunner.And("je click sur le texte IndoorRecurveTarget", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 165
 testRunner.And("je valide la sélection de cible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 166
 testRunner.And("j\'attend 5 secondes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 167
 testRunner.And("je reviens à la page d\'avant", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 168
 testRunner.And("je click sur le texte Yes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 169
 testRunner.And("j\'ouvre une page de tir sauvegardé", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 171
 testRunner.Then("il y a 3 tir sauvegardé", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Alors ");
#line 172
 testRunner.And("le tir sauvegardé 0 a pour type IndoorRecurveTarget", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 173
 testRunner.And("le tir sauvegardé 1 a pour type FieldTarget", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 174
 testRunner.And("le tir sauvegardé 2 a pour type EnglishTarget", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("test de réouverture de remarque")]
        public virtual void TestDeReouvertureDeRemarque()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("test de réouverture de remarque", ((string[])(null)));
#line 177
this.ScenarioSetup(scenarioInfo);
#line 178
 testRunner.When("J\'ouvre une page de sélection de cible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quand ");
#line 179
 testRunner.And("je valide la sélection de cible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 181
 testRunner.And("je click sur l\'onglet de remarque", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 182
 testRunner.And("je rentre \"remark de la volée 1\" dans l\'éditeur de remarque de la volée", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 183
 testRunner.And("je rentre \"remark générale 1\" dans l\'éditeur de remarque générales", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 184
 testRunner.And("je click sur le bouton de validation des remarques de la volée", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 185
 testRunner.And("je click sur le bouton de validation des remarques générales", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 187
 testRunner.And("je click sur l\'onglet de compté", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 188
 testRunner.And("je tire une flèche en 0, 100", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 189
 testRunner.And("Je click sur le bouton nouvelle volée", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 191
 testRunner.And("je click sur l\'onglet de remarque", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 192
 testRunner.And("je rentre \"remark de la volée 2\" dans l\'éditeur de remarque de la volée", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 193
 testRunner.And("je click sur le bouton de validation des remarques de la volée", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 194
 testRunner.And("je rentre \"remark générale 2\" dans l\'éditeur de remarque générales", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 195
 testRunner.And("je click sur le bouton de validation des remarques générales", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 197
 testRunner.And("je reviens à la page d\'avant", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 198
 testRunner.And("je click sur le texte Yes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 199
 testRunner.And("j\'ouvre une page de tir sauvegardé", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 200
 testRunner.And("j\'ouvre le tir sauvegardé 0", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 202
 testRunner.And("je click sur l\'onglet de remarque", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 203
 testRunner.And("je click sur le bouton d\'historique de remarque générales", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 205
 testRunner.Then("la remarque 0 est \"remark générale 1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Alors ");
#line 206
 testRunner.Then("la remarque 1 est \"remark générale 2\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Alors ");
#line 208
 testRunner.When("je reviens à la page d\'avant", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quand ");
#line 209
 testRunner.And("je click sur le bouton d\'historique de remarque de la volée", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 210
 testRunner.Then("la remarque 0 est \"remark de la volée 1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Alors ");
#line 211
 testRunner.Then("la remarque 1 est \"remark de la volée 2\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Alors ");
#line 212
 testRunner.And("la volée de la remarque 0 est 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 213
 testRunner.And("la volée de la remarque 1 est 2", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("test de réouverture d\'une cible")]
        public virtual void TestDeReouvertureDUneCible()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("test de réouverture d\'une cible", ((string[])(null)));
#line 216
this.ScenarioSetup(scenarioInfo);
#line 217
 testRunner.When("J\'ouvre une page de sélection de cible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quand ");
#line 218
 testRunner.And("je click sur le texte FieldTarget", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 219
 testRunner.And("je valide la sélection de cible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 221
 testRunner.And("je tire une flèche en 0, 100", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 222
 testRunner.And("je tire une flèche en 50, 0", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 224
 testRunner.And("Je click sur le bouton nouvelle volée", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 226
 testRunner.And("je tire une flèche en 25, 50", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 227
 testRunner.And("je tire une flèche en 50, 20", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 229
 testRunner.Then("le score de la volée est 12/12", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Alors ");
#line 230
 testRunner.And("le score total est 23/24", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 232
 testRunner.When("je reviens à la page d\'avant", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quand ");
#line 233
 testRunner.And("je click sur le texte Yes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 234
 testRunner.And("j\'ouvre une page de tir sauvegardé", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 235
 testRunner.And("j\'ouvre le tir sauvegardé 0", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 237
 testRunner.Then("il y a une cible FieldTarget", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Alors ");
#line 238
 testRunner.And("le nombre de flèches actuelles sur la cible est de 2", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 239
 testRunner.And("la flèche numéro 0 est en 564, 1088", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 240
 testRunner.And("la flèche numéro 1 est en 589, 1058", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 242
 testRunner.And("le numero de la volée est 2", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 243
 testRunner.And("le nombre de flèches dans la liste est de 2", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 244
 testRunner.And("le score de la volée est 12/12", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 245
 testRunner.And("le score total est 23/24", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("test de réouverture plusieurs cibles")]
        public virtual void TestDeReouverturePlusieursCibles()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("test de réouverture plusieurs cibles", ((string[])(null)));
#line 249
this.ScenarioSetup(scenarioInfo);
#line 250
 testRunner.When("J\'ouvre une page de sélection de cible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quand ");
#line 251
 testRunner.And("je click sur le texte FieldTarget", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 252
 testRunner.And("je valide la sélection de cible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 253
 testRunner.And("j\'attend 5 secondes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 254
 testRunner.And("je reviens à la page d\'avant", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 255
 testRunner.And("je click sur le texte Yes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 257
 testRunner.And("J\'ouvre une page de sélection de cible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 258
 testRunner.And("je click sur le texte FieldTarget", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 259
 testRunner.And("je valide la sélection de cible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 260
 testRunner.And("je tire une flèche en 0, 100", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 261
 testRunner.And("je tire une flèche en 50, 0", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 263
 testRunner.And("je reviens à la page d\'avant", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 264
 testRunner.And("je click sur le texte Yes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 265
 testRunner.And("j\'ouvre une page de tir sauvegardé", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 266
 testRunner.And("j\'ouvre le tir sauvegardé 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 268
 testRunner.Then("le score de la volée est 0/0", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Alors ");
#line 270
 testRunner.When("je reviens à la page d\'avant", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quand ");
#line 271
 testRunner.And("je click sur le texte Yes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 272
 testRunner.And("j\'ouvre une page de tir sauvegardé", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 273
 testRunner.And("j\'ouvre le tir sauvegardé 0", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 275
 testRunner.Then("le score de la volée est 11/12", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Alors ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("test de réouverture d\'une zapette")]
        public virtual void TestDeReouvertureDUneZapette()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("test de réouverture d\'une zapette", ((string[])(null)));
#line 278
this.ScenarioSetup(scenarioInfo);
#line 279
 testRunner.When("J\'ouvre une page de sélection de cible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quand ");
#line 280
 testRunner.And("je click sur le texte FieldTarget", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 281
 testRunner.And("je click sur l\'option cible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 283
 testRunner.And("je valide la sélection de cible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 285
 testRunner.And("je click sur le boutton 3", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 286
 testRunner.And("je click sur le boutton 4", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 288
 testRunner.And("Je click sur le bouton nouvelle volée", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 290
 testRunner.And("je click sur le boutton 6", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 291
 testRunner.And("je click sur le boutton 5", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 293
 testRunner.And("je reviens à la page d\'avant", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 294
 testRunner.And("je click sur le texte Yes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 295
 testRunner.And("j\'ouvre une page de tir sauvegardé", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 296
 testRunner.And("j\'ouvre le tir sauvegardé 0", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 298
 testRunner.Then("il y a des boutons de FieldTarget", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Alors ");
#line 299
 testRunner.And("le numero de la volée est 2", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 300
 testRunner.And("le nombre de flèches dans la liste est de 2", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 301
 testRunner.And("le score de la volée est 11/12", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 302
 testRunner.And("le score total est 18/24", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("test de sauvegarde des settings d\'un compté")]
        public virtual void TestDeSauvegardeDesSettingsDUnCompte()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("test de sauvegarde des settings d\'un compté", ((string[])(null)));
#line 305
this.ScenarioSetup(scenarioInfo);
#line 306
 testRunner.When("J\'ouvre une page de sélection de cible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Quand ");
#line 307
 testRunner.And("je valide la sélection de cible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 308
 testRunner.And("j\'ouvre le menu de paramètre", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 309
 testRunner.And("je click sur l option flèche ordonnée", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 310
 testRunner.And("je click sur l\'option de moyenne", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 311
 testRunner.And("je click sur l\'option toutes flèches", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 312
 testRunner.And("je click sur le slider de nombre fixe de flèche", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 313
 testRunner.And("je rentre 3 en nombre de flèche", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 315
 testRunner.And("je click sur le texte Finish", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 316
 testRunner.And("je reviens à la page d\'avant", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 317
 testRunner.And("je click sur le texte Yes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 318
 testRunner.And("j\'ouvre une page de tir sauvegardé", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 320
 testRunner.And("j\'ouvre le tir sauvegardé 0", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 321
 testRunner.And("j\'ouvre le menu de paramètre", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 323
 testRunner.Then("le nombre de flèche est activé", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Alors ");
#line 324
 testRunner.And("le nombre de flèches est de 3", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 325
 testRunner.And("l\'option flèche ordonnée est activée", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 326
 testRunner.And("l\'option de moyenne est activée", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line 327
 testRunner.And("l\'option toutes flèches est activée", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Et ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion