Feature: TargetSettingFeature
	tests des fonctions 

@mytag
Scenario: test l'ordre des flèches par défault
	When J'ouvre une page de cible fita
	And je tire une flèche en 200, 100
	And je tire une flèche en 100, 300
	And je tire une flèche en 0, 0
	
	#par défault les flèches ne sont pas ordonnées
	Then la fleche 0 de la liste est un 5
	Then la fleche 1 de la liste est un 4
	Then la fleche 2 de la liste est un X10


@mytag
Scenario: test la fonctionnalité d'ordonner les flèches tirées après le tir
	When J'ouvre une page de cible fita
	And je tire une flèche en 200, 100
	And je tire une flèche en 100, 300
	And je tire une flèche en 0, 0
	And j'ouvre le menu de paramètre
	And je click sur l option flèche ordonnée
	And je reviens à la page d'avant

	#les flèches sont ordonnées
	Then la fleche 0 de la liste est un x10
	Then la fleche 1 de la liste est un 5
	Then la fleche 2 de la liste est un 4


@mytag
Scenario: test de la fonctionnalité d'ordonner les flèches avant le tir
	When J'ouvre une page de cible fita
	When j'ouvre le menu de paramètre
	And je click sur l option flèche ordonnée
	And je reviens à la page d'avant
	And je tire une flèche en 200, 100
	And je tire une flèche en 100, 300
	And je tire une flèche en 0, 0
	
	#les flèches sont ordonnées
	Then la fleche 0 de la liste est un x10
	Then la fleche 1 de la liste est un 5
	Then la fleche 2 de la liste est un 4


@mytag
Scenario: test de la fonctionnalité d'ordonner et de retourner à l ordre par défault
	When J'ouvre une page de cible fita
	When j'ouvre le menu de paramètre
	And je click sur l option flèche ordonnée
	And je reviens à la page d'avant
	And je tire une flèche en 200, 100
	And je tire une flèche en 100, 300
	And je tire une flèche en 0, 0
	And j'ouvre le menu de paramètre
	And je click sur l option flèche ordonnée
	And je reviens à la page d'avant

	#comme par défault les flèches ne sont pas ordonnées
	Then la fleche 0 de la liste est un 5
	Then la fleche 1 de la liste est un 4
	Then la fleche 2 de la liste est un X10

@mytag
Scenario: test l'impossibilité de passer à une nouvelle volée sans avoir tiré de flèche
	When J'ouvre une page de cible fita
	# pas de flèches tiré
	Then le bouton nouvelle volée est désactivé

@mytag
Scenario: test la possibilité de passer à une nouvelle volée après avoir tiré une flèche
	When J'ouvre une page de cible fita
	And je tire une flèche en 200, 100
	# flèches tiré, possibilité de changer de volée
	Then le bouton nouvelle volée est activé
	
@mytag
Scenario: test l'impossibilité de passer à une nouvelle volée après avoir supprimé une flèche
	When J'ouvre une page de cible fita
	And je tire une flèche en 200, 100
	And je supprime la dernière flèche
	# plus de flèches tiré
	Then le bouton nouvelle volée est désactivé

	#TODO a partir d ici (ou tout le fichier) revérifier que les tests ont une et une seul clause then
@mytag
Scenario: test la possibilité de tirer un nombre de flèches libre
	When J'ouvre une page de cible fita
	And je tire une flèche en 200, 100
	And je tire une flèche en 100, 300
	And je tire une flèche en 0, 0
	Then le bouton nouvelle volée est activé

	When Je click sur le bouton nouvelle volée
	Then le nombre de flèches dans la liste est de 0
	And le nombre de flèches actuelles sur la cible est de 0
	
	When  je tire une flèche en 100, 300
	# possible de changer parceque le nombre de flèches est libre
	Then le bouton nouvelle volée est activé

	When Je click sur le bouton nouvelle volée
	Then le nombre de flèches dans la liste est de 0
	And le nombre de flèches actuelles sur la cible est de 0
	
	
@mytag
Scenario: test l'activation et desactivation du bouton nombre de flèche
	When J'ouvre une page de cible fita
	And j'ouvre le menu de paramètre
	
	Then le nombre de flèche est dasactivé
	And le check nombre de flèches n'est pas checké

	When je click sur le check nombre de flèches défini
	
	Then le nombre de flèche est activé
	And le nombre de flèche est de 6


@mytag
Scenario: test l'activation et desactivation du bouton nouvelle volée avec un nombre défini de flèches
	When J'ouvre une page de cible fita
	And j'ouvre le menu de paramètre
	And je click sur le check nombre de flèches défini

	When je remplit le nombre de flèche par 5
	And je reviens à la page d'avant
	And je tire une flèche en 200, 100
	And je tire une flèche en 100, 300
	And je tire une flèche en 0, 0
	
	# pas toutes les flèches de tirées
	Then le bouton nouvelle volée est desactivé 
	
	
	When je tire une flèche en 100, 200
	And je tire une flèche en 300, 100
	#le nombre de flèche défini est atteint
	Then le bouton nouvelle volée est activé


@mytag
Scenario: test la non possibilité de tirer une nouvelle flèche
	When J'ouvre une page de cible fita
	And j'ouvre le menu de paramètre
	And je click sur l option nombre de flèches 
	And je reviens à la page d'avant
	And je tire une flèche en 200, 100
	And je tire une flèche en 100, 300
	And je tire une flèche en 0, 0
	And je tire une flèche en 100, 200
	And je tire une flèche en 300, 100
	And je tire une flèche en 100, 100

	Then le nombre de flèches dans la liste est de 6
	And le nombre de flèches actuelles sur la cible est de 6

	#le nombre de flèche défini est atteint
	When je tire une flèche en 100, 200
	
	Then le nombre de flèches dans la liste est de 6
	And le nombre de flèches actuelles sur la cible est de 6


