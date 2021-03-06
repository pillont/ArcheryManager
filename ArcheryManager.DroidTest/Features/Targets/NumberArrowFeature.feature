﻿# language: fr-FR
Fonctionnalité:  NumberArrowFeature
	test les possibilités de tirer un nombre de flèche défini ou non


Scénario: test la possibilité de tirer un nombre de flèches libre
	Quand J'ouvre une page de cible fita
	Et je tire une flèche en 200, 100
	Et je tire une flèche en 100, 300
	Et je tire une flèche en 0, 0
	Et Je click sur le bouton nouvelle volée
	Et  je tire une flèche en 100, 300

	# possible de changer parceque le nombre de flèches est libre
	Alors le bouton nouvelle volée est activé


Scénario: test la desactivation par défault du bouton nombre de flèche
	Quand J'ouvre une page de cible fita
	Et j'ouvre le menu de paramètre
	
	Alors le nombre de flèche est désactivé
	

Scénario: test du minimum de flèche
	Quand J'ouvre une page de cible fita
	Et j'ouvre le menu de paramètre
	Et je click sur le check nombre de flèches défini
	Et je remplit le nombre de flèche par 2

	Alors le nombre de flèche est de 3
	

Scénario: test l'activation du bouton nombre de flèche
	Quand J'ouvre une page de cible fita
	Et j'ouvre le menu de paramètre
	Et je click sur le check nombre de flèches défini
	
	Alors le nombre de flèche est activé
	Et le nombre de flèche est de 6

	
Scénario: test la non possibilité de tirer plus du max
	Quand J'ouvre une page de cible fita
	Et j'ouvre le menu de paramètre
	Et je click sur le check nombre de flèches défini
	Et je click sur le texte Finish
	Et je tire une flèche en 200, 100
	Et je tire une flèche en -200, -200
	Et je tire une flèche en 0, 0
	Et je tire une flèche en 100, 200
	Et je tire une flèche en 200, 200
	Et je tire une flèche en 100, 100
	
	#le nombre de flèche défini est atteint
	Et je tire une flèche en 100, 200
	
	Alors le message d'erreur du nombre de flèche est affiché
	Et le nombre de flèches dans la liste est de 6
	Et le nombre de flèches actuelles sur la cible est de 6


Scénario: test la non possibilité de tirer plus du max dans la vue de bouton
	Quand J'ouvre une page zappette
	Et j'ouvre le menu de paramètre
	Et je click sur le check nombre de flèches défini
	Et je click sur le texte Finish
	Et je click sur le boutton 10
	Et je click sur le boutton 9
	Et je click sur le boutton 8
	Et je click sur le boutton 7
	Et je click sur le boutton 6
	Et je click sur le boutton 5
	
	#le nombre de flèche défini est atteint
	Et je click sur le boutton X10
	
	Alors le nombre de flèches dans la liste est de 6
	Et le message d'erreur du nombre de flèche est affiché