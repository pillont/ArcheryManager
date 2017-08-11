# language: fr-FR
Fonctionnalité: TargetInTabbedPage
	
Scénario: test des gestures dans une page avec onglet
	Quand J'ouvre une page tabbed de cible fita
	Et je tire une flèche en 0, 100
	Et je tire une flèche en 0, -100
	Et je tire une flèche en 100, 0
	Et je tire une flèche en -1000, 0

	# test la non concurence des gesture
	Alors le nombre de flèches dans la liste est de 4