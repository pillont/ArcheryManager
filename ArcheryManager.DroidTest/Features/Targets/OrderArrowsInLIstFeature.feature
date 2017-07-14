# language: fr-FR
Fonctionnalité: TargetSettingFeature
	tests des fonctions 

	# cible
Scénario: test l'ordre des flèches par défault dans la page cible
	Quand J'ouvre une page de cible fita
	Et je tire une flèche en 200, 100
	Et je tire une flèche en 100, 298
	Et je tire une flèche en 0, 0
	
	#par défault les flèches ne sont pas ordonnées
	Alors la fleche 0 de la liste est un 3
	Alors la fleche 1 de la liste est un M
	Alors la fleche 2 de la liste est un X10

		
Scénario: test la fonctionnalité d'ordonner les flèches tirées après le tir dans la page cible
	Quand J'ouvre une page de cible fita
	Et je tire une flèche en 200, 100
	Et je tire une flèche en 100, 298
	Et je tire une flèche en 0, 0
	Et j'ouvre le menu de paramètre
	Et je click sur l option flèche ordonnée
	Et je reviens à la page d'avant

	#les flèches sont ordonnées
	Alors la fleche 0 de la liste est un X10
	Alors la fleche 1 de la liste est un 3
	Alors la fleche 2 de la liste est un M

	Scénario: test la fonctionnalité d'ordonner des flèches de même valeur dans la page cible
	Quand J'ouvre une page de cible fita
	Et je tire une flèche en 20, 30
	Et je tire une flèche en 0, 0
	Et je tire une flèche en 30, 20
	Et j'ouvre le menu de paramètre
	Et je click sur l option flèche ordonnée
	Et je reviens à la page d'avant

	#les flèches sont ordonnées
	Alors la fleche 0 de la liste est un X10
	Alors la fleche 1 de la liste est un 10
	Alors la fleche 2 de la liste est un 10


Scénario: test de la fonctionnalité d'ordonner les flèches avant le tir dans la page cible
	Quand J'ouvre une page de cible fita
	Quand j'ouvre le menu de paramètre
	Et je click sur l option flèche ordonnée
	Et je reviens à la page d'avant
	Et je tire une flèche en 200, 100
	Et je tire une flèche en 100, 298
	Et je tire une flèche en 0, 0
	
	#les flèches sont ordonnées
	Alors la fleche 0 de la liste est un X10
	Alors la fleche 1 de la liste est un 3
	Alors la fleche 2 de la liste est un M

Scénario: test de la fonctionnalité d'ordonner et de retourner à l ordre par défault dans la page cible
	Quand J'ouvre une page de cible fita
	Quand j'ouvre le menu de paramètre
	Et je click sur l option flèche ordonnée
	Et je reviens à la page d'avant
	Et je tire une flèche en 200, 100
	Et je tire une flèche en 100, 298
	Et je tire une flèche en 0, 0
	Et j'ouvre le menu de paramètre
	Et je click sur l option flèche ordonnée
	Et je reviens à la page d'avant

	#comme par défault les flèches ne sont pas ordonnées
	Alors la fleche 0 de la liste est un 3
	Alors la fleche 1 de la liste est un M
	Alors la fleche 2 de la liste est un X10


	#buttons
Scénario: test l'ordre des flèches par défault dans la page zappette
	Quand J'ouvre une page zappette
	Et je click sur le boutton 5
	Et je click sur le boutton 3
	Et je click sur le boutton X10
	
	#par défault les flèches ne sont pas ordonnées
	Alors la fleche 0 de la liste est un 5
	Alors la fleche 1 de la liste est un 3
	Alors la fleche 2 de la liste est un X10


Scénario: test la fonctionnalité d'ordonner les flèches tirées après le tir dans la page zappette
 Quand J'ouvre une page zappette
	Et je click sur le boutton 5
	Et je click sur le boutton 3
	Et je click sur le boutton X10
	Et j'ouvre le menu de paramètre
	Et je click sur l option flèche ordonnée
	Et je reviens à la page d'avant

	#les flèches sont ordonnées
	Alors la fleche 0 de la liste est un X10
	Alors la fleche 1 de la liste est un 5
	Alors la fleche 2 de la liste est un 3

	Scénario: test la fonctionnalité d'ordonner des flèches de même valeur dans la page zappette
 Quand J'ouvre une page zappette
	Et je click sur le boutton 10
	Et je click sur le boutton X10
	Et je click sur le boutton 10
	Et j'ouvre le menu de paramètre
	Et je click sur l option flèche ordonnée
	Et je reviens à la page d'avant

	#les flèches sont ordonnées
	Alors la fleche 0 de la liste est un X10
	Alors la fleche 1 de la liste est un 10
	Alors la fleche 2 de la liste est un 10


Scénario: test de la fonctionnalité d'ordonner les flèches avant le tir dans la page zappette
 Quand J'ouvre une page zappette
	Quand j'ouvre le menu de paramètre
	Et je click sur l option flèche ordonnée
	Et je reviens à la page d'avant
	Et je click sur le boutton 5
	Et je click sur le boutton 3
	Et je click sur le boutton X10
	
	#les flèches sont ordonnées
	Alors la fleche 0 de la liste est un X10
	Alors la fleche 1 de la liste est un 5
	Alors la fleche 2 de la liste est un 3

Scénario: test de la fonctionnalité d'ordonner et de retourner à l ordre par défault dans la page zappette
 Quand J'ouvre une page zappette
	Quand j'ouvre le menu de paramètre
	Et je click sur l option flèche ordonnée
	Et je reviens à la page d'avant
	Et je click sur le boutton 5
	Et je click sur le boutton 3
	Et je click sur le boutton X10
	Et j'ouvre le menu de paramètre
	Et je click sur l option flèche ordonnée
	Et je reviens à la page d'avant

	#comme par défault les flèches ne sont pas ordonnées
	Alors la fleche 0 de la liste est un 5
	Alors la fleche 1 de la liste est un 3
	Alors la fleche 2 de la liste est un X10
