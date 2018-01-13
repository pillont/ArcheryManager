# language: fr-FR
Fonctionnalité: ToolbarItemsCounter
	

Scénario: test les boutons dans un compté
	Quand J'ouvre une page tabbed de cible fita
	Alors il y a 2 boutons dans la barre de navigation

	Quand je tire une flèche en 0, 0
	Alors il y a 3 boutons dans la barre de navigation

	Quand je click sur le tab timer
	Alors il y a 3 boutons dans la barre de navigation

	Quand je click sur l'onglet de remarque
	Alors il y a 0 boutons dans la barre de navigation


Scénario: test le bouton nouvelle volée dans un compté après le changement de setting 
	Quand J'ouvre une page tabbed de cible fita
	Et j'ouvre le menu de paramètre
	Et je click sur le slider de nombre fixe de flèche
	Et je rentre 6 en nombre de flèche
	Et je click sur le texte Finish

	Quand je tire une flèche en 0, 0
	Quand je tire une flèche en 0, 0
	Quand je tire une flèche en 0, 0

	Alors le bouton nouvelle volée est désactivé

	Quand j'ouvre le menu de paramètre
	Et je rentre 3 en nombre de flèche
	Et je click sur le texte Finish

	Alors le bouton nouvelle volée est activé


Scénario: test le bouton nouvelle volée après un retour 
	Quand J'ouvre une page tabbed de cible fita
	Et je tire une flèche en 0, 0
	Et je tire une flèche en 0, 0
	Alors le bouton nouvelle volée est activé
	
	Quand je reviens à la page d'avant
	Et je click sur le texte No
	Alors le bouton nouvelle volée est activé

	
Scénario: test de boutons de timer apres un retour 
	Quand J'ouvre une page tabbed de cible fita
	Et je click sur le tab timer
	Alors il y a 3 boutons dans la barre de menu
	
	Quand je reviens à la page d'avant
	Et je click sur le texte No
	Et je click sur le tab timer
	Alors il y a 3 boutons dans la barre de menu
	

Scénario: test de boutons de nouvelle volée pour un tir sauvegardé
	Quand J'ouvre une page de sélection de cible
	Et je valide la sélection de cible
	Et je tire une flèche en 0, -100
	Et je tire une flèche en 0, 100
	Et je reviens à la page d'avant
	Et je click sur le texte Yes
	Et j'ouvre une page de tir sauvegardé
	Et j'ouvre le tir sauvegardé 0

	Alors le bouton nouvelle volée est activé
