# language: fr-FR
Fonctionnalité: ToolbarItemsKeepingFeature
	
Scénario: test de maintient des boutons apres les options sans selection
	Quand J'ouvre une page tabbed de cible fita
	Et j'ouvre le menu de paramètre
	Et je click sur le texte Finish

	Alors il y a 2 boutons dans la barre de navigation
	Alors il y a le texte Finish
	
	Quand je tire une flèche en 0, 0
	Et j'ouvre le menu de paramètre
	Et je click sur le texte Finish
	
	Alors il y a 3 boutons dans la barre de navigation
	Alors il y a le texte Finish
	Alors il y a le texte NewFlight





