# language: fr-FR
Fonctionnalité: OpenSavedCounterFeature

Scénario: test d'ouverture de liste de tir vide
	Quand j'ouvre une page de tir sauvegardé
	Alors il y a le texte EmptyList


Scénario: test d'ouverture de liste de tir dans le menu general
	Quand J'ouvre une page de menu general
	Et je click sur le texte Saves

	Alors il y a une page de tir sauvegarder

Scénario: test de score d'un tir sauvegardé redémarré
	Quand J'ouvre une page de sélection de cible
	Et je valide la sélection de cible
	Et je tire une flèche en 0, 100
	Et je tire une flèche en 0, 100
	Et Je click sur le bouton nouvelle volée
	Et je tire une flèche en 0, 100
	Et je tire une flèche en 0, 100
	Et je click sur le bouton de restart

	Et je reviens à la page d'avant
	Et je click sur le texte Yes
	Et j'ouvre une page de tir sauvegardé

	Alors le score du tir sauvegardé 0 est 0/0
	 

Scénario: test de filtrage des tirs sauvegardés dans la liste
	Quand J'ouvre une page de sélection de cible
	Et je valide la sélection de cible
	Et j'attend 5 secondes
	Et je reviens à la page d'avant

	Et je click sur le texte Yes

	Et J'ouvre une page de sélection de cible
	Et je valide la sélection de cible
	Et je tire une flèche en 0, 50
	Et je click sur le texte Finish
	Et je reviens à la page d'avant

	Et j'ouvre une page de tir sauvegardé
	
	Alors il y a 2 tir sauvegardé
	Et le score du tir sauvegardé 0 est 10/10
	Et le score du tir sauvegardé 1 est 0/0
	
	Quand je click sur le switch des tirs finis
	Alors il y a 1 tir sauvegardé
	Et le score du tir sauvegardé 0 est 0/0

	Quand je click sur le switch des tirs finis
	Quand je click sur le switch des tirs non finis
	Alors il y a 1 tir sauvegardé
	Et le score du tir sauvegardé 0 est 10/10

	Quand je click sur le switch des tirs finis
	Alors il y a 0 tir sauvegardé
 
Scénario: test de status des tirs sauvegardés dans la liste
	Quand J'ouvre une page de sélection de cible
	Et je valide la sélection de cible
	Et j'attend 5 secondes
	Et je reviens à la page d'avant

	Et je click sur le texte Yes

	Et J'ouvre une page de sélection de cible
	Et je valide la sélection de cible
	Et je tire une flèche en 0, 100
	Et je click sur le texte Finish
	Et je reviens à la page d'avant

	Et j'ouvre une page de tir sauvegardé
	
	Alors il y a 2 tir sauvegardé
	Et le status du tir sauvegardé 0 est Finished
	Et le status du tir sauvegardé 1 est InProgress
	 	 
Scénario: test de score d'un tir sauvegardé
	Quand J'ouvre une page de sélection de cible
	Et je valide la sélection de cible
	Et je tire une flèche en 0, 100
	Et je tire une flèche en 0, 100
	Et Je click sur le bouton nouvelle volée
	Et je tire une flèche en 0, 100
	Et je tire une flèche en 0, 100
	Et je reviens à la page d'avant
	Et je click sur le texte Yes
	Et j'ouvre une page de tir sauvegardé

	Alors le score du tir sauvegardé 0 est 36/40
	 

 #TODO
Plan du scénario: test de sauvegarde d'un compté dans une liste
	Quand J'ouvre une page de sélection de cible
	Et je click sur le texte <type>
	Et je valide la sélection de cible
	Et j'attend 5 secondes
	Et je reviens à la page d'avant
	Et je click sur le texte Yes
	Et j'ouvre une page de tir sauvegardé

	Alors il y a 1 tir sauvegardé
	Et le tir sauvegardé 0 a pour type <type>
	Et la date du tir compté 0 est aujourd'hui

	Exemples: 
	| type |
	| EnglishTarget    |
	| FieldTarget    |
	| IndoorRecurveTarget    | 
	| IndoorCompoundTarget    |
	
Scénario: test de sauvegarde d'un score de compté dans une liste
	Quand J'ouvre une page de sélection de cible
	Et je click sur l'option cible
	Et je valide la sélection de cible
	Et je click sur le boutton 10
	Et je click sur le boutton 9
	Et je click sur le boutton 8
	Et je click sur le boutton 7

	Et je reviens à la page d'avant
	Et je click sur le texte Yes
	Et j'ouvre une page de tir sauvegardé

	Et le tir sauvegardé 0 a pour score 34/40

	
Scénario: test d'ouverture d une page de resultat depuis une liste
	Quand J'ouvre une page de sélection de cible
	Et je valide la sélection de cible
	Et je tire une flèche en 0, 100
	Et je click sur le texte Finish
	Et je reviens à la page d'avant
	Et j'ouvre une page de tir sauvegardé
	Et j'ouvre le tir sauvegardé 0
	
	Alors une vue de bilan de compté s'ouvre


Scénario: test de sauvegarde de plusieurs comptés dans une liste
	Quand J'ouvre une page de sélection de cible

	Et je valide la sélection de cible
	Et j'attend 5 secondes
	Et je reviens à la page d'avant
	Et je click sur le texte Yes

	Quand J'ouvre une page de sélection de cible
	Et je click sur le texte FieldTarget
	Et je valide la sélection de cible
	Et j'attend 5 secondes
	Et je reviens à la page d'avant
	Et je click sur le texte Yes

	Quand J'ouvre une page de sélection de cible
	Et je click sur le texte IndoorRecurveTarget
	Et je valide la sélection de cible
	Et j'attend 5 secondes
	Et je reviens à la page d'avant
	Et je click sur le texte Yes
	Et j'ouvre une page de tir sauvegardé

	Alors il y a 3 tir sauvegardé
	Et le tir sauvegardé 0 a pour type IndoorRecurveTarget
	Et le tir sauvegardé 1 a pour type FieldTarget
	Et le tir sauvegardé 2 a pour type EnglishTarget


Scénario: test de réouverture de remarque
	Quand J'ouvre une page de sélection de cible
	Et je valide la sélection de cible
	
	Et je click sur l'onglet de remarque
	Et je rentre "remark de la volée 1" dans l'éditeur de remarque de la volée
	Et je rentre "remark générale 1" dans l'éditeur de remarque générales
	Et je click sur le bouton de validation des remarques de la volée
	Et je click sur le bouton de validation des remarques générales
	
	Et je click sur l'onglet de compté
	Et je tire une flèche en 0, 100
	Et Je click sur le bouton nouvelle volée

	Et je click sur l'onglet de remarque
	Et je rentre "remark de la volée 2" dans l'éditeur de remarque de la volée
	Et je click sur le bouton de validation des remarques de la volée
	Et je rentre "remark générale 2" dans l'éditeur de remarque générales
	Et je click sur le bouton de validation des remarques générales

	Et je reviens à la page d'avant
	Et je click sur le texte Yes
	Et j'ouvre une page de tir sauvegardé
	Et j'ouvre le tir sauvegardé 0

	Et je click sur l'onglet de remarque
	Et je click sur le bouton d'historique de remarque générales

	Alors la remarque 0 est "remark générale 1"
	Alors la remarque 1 est "remark générale 2"
	
	Quand je reviens à la page d'avant
	Et je click sur le bouton d'historique de remarque de la volée
	Alors la remarque 0 est "remark de la volée 1"
	Alors la remarque 1 est "remark de la volée 2"
	Et la volée de la remarque 0 est 1
	Et la volée de la remarque 1 est 2


Scénario: test de réouverture d'une cible
	Quand J'ouvre une page de sélection de cible
	Et je click sur le texte FieldTarget
	Et je valide la sélection de cible

	Et je tire une flèche en 0, 100
	Et je tire une flèche en 50, 0

	Et Je click sur le bouton nouvelle volée

	Et je tire une flèche en 25, 50
	Et je tire une flèche en 50, 20

	Alors le score de la volée est 12/12
	Et le score total est 23/24

	Quand je reviens à la page d'avant
	Et je click sur le texte Yes
	Et j'ouvre une page de tir sauvegardé
	Et j'ouvre le tir sauvegardé 0

	Alors il y a une cible FieldTarget
	Et le nombre de flèches actuelles sur la cible est de 2
	Et la flèche numéro 0 est en 564, 1088
	Et la flèche numéro 1 est en 589, 1058
	
	Et le numero de la volée est 2
	Et le nombre de flèches dans la liste est de 2
	Et le score de la volée est 12/12
	Et le score total est 23/24


	
Scénario: test de réouverture plusieurs cibles
	Quand J'ouvre une page de sélection de cible
	Et je click sur le texte FieldTarget
	Et je valide la sélection de cible
	Et j'attend 5 secondes
	Et je reviens à la page d'avant
	Et je click sur le texte Yes

	Et J'ouvre une page de sélection de cible
	Et je click sur le texte FieldTarget
	Et je valide la sélection de cible
	Et je tire une flèche en 0, 100
	Et je tire une flèche en 50, 0

	Et je reviens à la page d'avant
	Et je click sur le texte Yes
	Et j'ouvre une page de tir sauvegardé
	Et j'ouvre le tir sauvegardé 1

	Alors le score de la volée est 0/0
	
	Quand je reviens à la page d'avant
	Et je click sur le texte Yes
	Et j'ouvre une page de tir sauvegardé
	Et j'ouvre le tir sauvegardé 0

	Alors le score de la volée est 11/12


Scénario: test de réouverture d'une zapette
	Quand J'ouvre une page de sélection de cible
	Et je click sur le texte FieldTarget
	Et je click sur l'option cible

	Et je valide la sélection de cible

	Et je click sur le boutton 3
	Et je click sur le boutton 4
	
	Et Je click sur le bouton nouvelle volée

	Et je click sur le boutton 6
	Et je click sur le boutton 5

	Et je reviens à la page d'avant
	Et je click sur le texte Yes
	Et j'ouvre une page de tir sauvegardé
	Et j'ouvre le tir sauvegardé 0

	Alors il y a des boutons de FieldTarget
	Et le numero de la volée est 2
	Et le nombre de flèches dans la liste est de 2
	Et le score de la volée est 11/12
	Et le score total est 18/24


Scénario: test de sauvegarde des settings d'un compté 
	Quand J'ouvre une page de sélection de cible
	Et je valide la sélection de cible
	Et j'ouvre le menu de paramètre
	Et je click sur l option flèche ordonnée
	Et je click sur l'option de moyenne
	Et je click sur l'option toutes flèches
	Et je click sur le slider de nombre fixe de flèche
	Et je rentre 3 en nombre de flèche

	Et je click sur le texte Finish
	Et je reviens à la page d'avant
	Et je click sur le texte Yes
	Et j'ouvre une page de tir sauvegardé

	Et j'ouvre le tir sauvegardé 0
	Et j'ouvre le menu de paramètre

	Alors le nombre de flèche est activé
	Et le nombre de flèches est de 3
	Et l'option flèche ordonnée est activée
	Et l'option de moyenne est activée
	Et l'option toutes flèches est activée














































































































































































































































































































































































































































































































































































































































































































































































































