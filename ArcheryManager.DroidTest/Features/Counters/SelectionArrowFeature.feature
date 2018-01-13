# language: fr-FR
Fonctionnalité: SelectionArrowFeature
	test de la sélection et du blocage d'ajout de flèche


Scénario: test blocage d'ajout de flèche durant une sélection dans une cible
	Quand J'ouvre une page de cible fita
	Et je tire une flèche en -10, 20
	Et je tire une flèche en -50, 100
	Et je tire une flèche en 200, 50
	Et je sélectionne la flèche 1
	Et je tire une flèche en -50, 100

	Alors le nombre de flèches dans la liste est de 3
	Et le message d'erreur d'ajout pendant sélection est affiché

Scénario: test blocage d'ajout de flèche durant une sélection dans une zapette
	Quand J'ouvre une page zappette
	Et je click sur le boutton 3
	Et je click sur le boutton 5
	Et je click sur le boutton 8
	Et je sélectionne la flèche 1
	Et je click sur le boutton 9

	Alors le nombre de flèches dans la liste est de 3
	Et le message d'erreur d'ajout pendant sélection est affiché

Scénario: test déblocage d'ajout de flèche après une sélection dans une zapette
	Quand J'ouvre une page zappette
	Et je click sur le boutton 3
	Et je click sur le boutton 5
	Et je click sur le boutton 8
	Et je sélectionne la flèche 1
	Et je sélectionne la flèche 1
	Et je click sur le boutton 9

	Alors le nombre de flèches dans la liste est de 4
	Et le message d'erreur d'ajout pendant sélection n'est pas affiché

	
Scénario: test déblocage d'ajout de flèche après une sélection dans une cible
	Quand J'ouvre une page de cible fita
	Et je tire une flèche en -10, 20
	Et je tire une flèche en -50, 100
	Et je tire une flèche en 200, 50
	Et je sélectionne la flèche 1
	Et je sélectionne la flèche 1
	Et je tire une flèche en 50, 100


	Alors le nombre de flèches dans la liste est de 4
	Et le message d'erreur d'ajout pendant sélection n'est pas affiché


 #TODO
Scénario: test de retour des boutons apres une sélection sur une cible
	Quand J'ouvre une page de cible fita
	Et je tire une flèche en 0, 100
	Et je sélectionne la flèche 0
	Et je sélectionne la flèche 0
	
	Alors il y a 3 boutons dans la barre de menu

	#TODO
Scénario: test de retour des boutons apres une sélection sur une zapette
	Quand J'ouvre une page zappette
	Et je click sur le boutton 4
	Et je sélectionne la flèche 0
	Et je sélectionne la flèche 0

	Alors il y a 3 boutons dans la barre de menu


Scénario: test de changement des boutons lors d'un changement de page apres une sélection sur une zapette
	Quand J'ouvre une page zappette
	Et je click sur le boutton 4
	Et je sélectionne la flèche 0
    Et je click sur l'onglet de remarque

	Alors il y a 0 boutons dans la barre de menu

	Quand je reviens à la page d'avant
	Et je click sur le texte Yes
	Et J'ouvre une page tabbed de cible fita
	Et je tire une flèche en 10, 10
	Et je sélectionne la flèche 0
    Et je click sur l'onglet de remarque

	Alors il y a 0 boutons dans la barre de menu

Scénario: test de boutons de sélection apres un retour 
	Quand J'ouvre une page tabbed de cible fita
	Et je tire une flèche en 0, 0
	Et je sélectionne la flèche 0
	Et je click sur le tab timer
	Alors il y a 3 boutons dans la barre de menu

	Quand je click sur l'onglet de compté
	Alors il y a 2 boutons dans la barre de navigation