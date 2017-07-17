# language: fr-FR
Fonctionnalité: TargetSelectorFeature
	test du selecteur de cible

Plan du scénario: Test de sélection de cible
	Quand J'ouvre une page de sélection de cible
	Et je click sur le texte <type>
	Et je valide la sélection de cible

	Alors il y a une cible <type>

	Exemples: 
	| type |
	| EnglishTarget    |  
	| FieldTarget    |  
	| IndoorRecurveTarget    |  
	| IndoorCompoundTarget    |  


Scénario: Test de nombre par défault de flèche
	Quand J'ouvre une page de sélection de cible
	Et je click sur le slider de nombre fixe de flèche

	Alors le nombre de flèches est de 6

Scénario: Test de nombre de flèche par défault
	Quand J'ouvre une page de sélection de cible
	Et je valide la sélection de cible
	Et je tire une flèche en 0, 0

	Alors le nombre de flèches actuelles sur la cible est de 1
	Et le bouton nouvelle volée est activé


Scénario: Test de nombre de flèche défini bouton nouvelle volée désactivé
	Quand J'ouvre une page de sélection de cible
	Et je click sur le slider de nombre fixe de flèche
	Et je rentre 5 en nombre de flèche
	Et je valide la sélection de cible
	Et je tire une flèche en 0, 0

	Alors le nombre de flèches actuelles sur la cible est de 1
	Et le bouton nouvelle volée est désactivé


Scénario: Test de sélection du nombre de flèche
	Quand J'ouvre une page de sélection de cible
	Et je click sur le slider de nombre fixe de flèche
	Et je rentre 5 en nombre de flèche
	Et je valide la sélection de cible
	Et je tire une flèche en 0, 0
	Et je tire une flèche en -4, -30
	Et je tire une flèche en -2, 10
	Et je tire une flèche en 25, 40
	Et je tire une flèche en -10, 20
	Et je tire une flèche en 5, -15

	Alors le nombre de flèches actuelles sur la cible est de 5
	Et le bouton nouvelle volée est activé


Plan du scénario: Test de sélection de bouton de cible 
	Quand J'ouvre une page de sélection de cible
	Et je click sur le texte <type>
	Et je click sur l'option cible
	Et je valide la sélection de cible

	Alors il y a des boutons de <type>

	Exemples: 
	| type |
	| EnglishTarget    |  
	| FieldTarget    |  
	| IndoorRecurveTarget    |  
	| IndoorCompoundTarget    |  
