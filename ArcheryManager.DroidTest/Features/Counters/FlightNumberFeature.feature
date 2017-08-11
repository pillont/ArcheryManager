# language: fr-FR
Fonctionnalité:  FlightNumberFeature
	
Scénario: test du numéro de volée par défault
	Quand J'ouvre une page de cible fita
	Alors le numero de la volée est 1

	
Scénario: test du changement de numéro de volée 
	Quand J'ouvre une page de cible fita
	Et je tire une flèche en 0, 0
	Et Je click sur le bouton nouvelle volée
	Alors le numero de la volée est 2
	
	Quand je tire une flèche en 0, 0
	Et Je click sur le bouton nouvelle volée
	Alors le numero de la volée est 3


	#test de la remise à zéro du numéro de volée 
	Quand je click sur le bouton de restart
	Alors le numero de la volée est 1
