# language: fr-FR
Fonctionnalité: RestartCounter
	test la fonctionnalité de restart d un tir compté

Scénario: test de remise à zéro
	Quand J'ouvre une page de cible fita
	Et j'ouvre le menu de paramètre
	Et je click sur l'option toutes flèches
	Et je reviens à la page d'avant

	Et je tire une flèche en 150, 50
	Et je tire une flèche en 100, 100
	Et je tire une flèche en 50, 150
	Et Je click sur le bouton nouvelle volée
	
	Et je tire une flèche en 150, 50
	Et je tire une flèche en 100, 100
	Et je tire une flèche en 50, 150
	
	Et je click sur le bouton de restart

	Alors le nombre de flèches actuelles sur la cible est de 0
	Et le nombre de flèches précèdente sur la cible est de 0
	Et le score total est de 0
	Et le score de la volée est de 0

Scénario: test reprise après un restart
	Quand J'ouvre une page de cible fita
	Et j'ouvre le menu de paramètre
	Et je click sur l'option toutes flèches
	Et je reviens à la page d'avant

	Et je tire une flèche en 150, 50
	Et je tire une flèche en 100, 100
	Et je tire une flèche en 50, 150
	Et Je click sur le bouton nouvelle volée
	
	Et je click sur le bouton de restart

	Et je tire une flèche en 150, 50
	Et je tire une flèche en 100, 100
	Et je tire une flèche en 50, 150
	
	Alors le nombre de flèches actuelles sur la cible est de 3
	Et le nombre de flèches précèdente sur la cible est de 0
	Et le score total est de 16
	Et le score de la volée est de 16	