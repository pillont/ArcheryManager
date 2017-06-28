# language: fr-FR
Fonctionnalité: TargetSettingFeature
	tests des fonctions 

	#TODO
#@mytag
#Scénario: test l'ordre des flèches par défault
#	Quand J'ouvre une page de cible fita
#	Et je tire une flèche en 200, 100
#	Et je tire une flèche en 100, 300
#	Et je tire une flèche en 0, 0
#	
#	#par défault les flèches ne sont pas ordonnées
#	Alors la fleche 0 de la liste est un 5
#	Alors la fleche 1 de la liste est un 4
#	Alors la fleche 2 de la liste est un X10


#@mytag
#Scénario: test la fonctionnalité d'ordonner les flèches tirées après le tir
#	Quand J'ouvre une page de cible fita
#	Et je tire une flèche en 200, 100
#	Et je tire une flèche en 100, 300
#	Et je tire une flèche en 0, 0
#	Et j'ouvre le menu de paramètre
#	Et je click sur l option flèche ordonnée
#	Et je reviens à la page d'avant
#
#	#les flèches sont ordonnées
#	Alors la fleche 0 de la liste est un x10
#	Alors la fleche 1 de la liste est un 5
#	Alors la fleche 2 de la liste est un 4


#@mytag
#Scénario: test de la fonctionnalité d'ordonner les flèches avant le tir
#	Quand J'ouvre une page de cible fita
#	Quand j'ouvre le menu de paramètre
#	Et je click sur l option flèche ordonnée
#	Et je reviens à la page d'avant
#	Et je tire une flèche en 200, 100
#	Et je tire une flèche en 100, 300
#	Et je tire une flèche en 0, 0
#	
#	#les flèches sont ordonnées
#	Alors la fleche 0 de la liste est un x10
#	Alors la fleche 1 de la liste est un 5
#	Alors la fleche 2 de la liste est un 4


#@mytag
#Scénario: test de la fonctionnalité d'ordonner et de retourner à l ordre par défault
#	Quand J'ouvre une page de cible fita
#	Quand j'ouvre le menu de paramètre
#	Et je click sur l option flèche ordonnée
#	Et je reviens à la page d'avant
#	Et je tire une flèche en 200, 100
#	Et je tire une flèche en 100, 300
#	Et je tire une flèche en 0, 0
#	Et j'ouvre le menu de paramètre
#	Et je click sur l option flèche ordonnée
#	Et je reviens à la page d'avant
#
#	#comme par défault les flèches ne sont pas ordonnées
#	Alors la fleche 0 de la liste est un 5
#	Alors la fleche 1 de la liste est un 4
#	Alors la fleche 2 de la liste est un X10



