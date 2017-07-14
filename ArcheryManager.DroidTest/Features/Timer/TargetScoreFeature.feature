# language: fr-FR
Fonctionnalité: TargetScoreFeature
	Test des scores de la page de cible 

Scénario: Score par défault
	Quand J'ouvre une page de cible fita
	Alors le score de la volée est 0/0
	Alors le score total est 0/0

Scénario: Score après tir
	Quand J'ouvre une page de cible fita
	Et je tire une flèche en 100, 200
	Et je tire une flèche en 50, 235
	Et je tire une flèche en 0, 0
	
	Alors le score de la volée est 20/30
	Alors le score total est 20/30

Scénario: Score après une nouvelle volée
	Quand J'ouvre une page de cible fita
	Et je tire une flèche en 100, 200
	Et je tire une flèche en 50, 235
	Et je tire une flèche en 0, 0
	Et Je click sur le bouton nouvelle volée

	Alors le score de la volée est 0/0
	Alors le score total est 20/30

Scénario: Score tir après une nouvelle volée
Quand J'ouvre une page de cible fita
	Et je tire une flèche en 100, 200
	Et je tire une flèche en 50, 235
	Et je tire une flèche en 0, 0
	Et Je click sur le bouton nouvelle volée
	Et je tire une flèche en 100, 200
	Et je tire une flèche en 50, 235
	Et je tire une flèche en 0, 0

	Alors le score de la volée est 20/30
	Alors le score total est 40/60



