# language: fr-FR
Fonctionnalité:  NumberArrowFeature
	test les possibilités de tirer un nombre de flèche défini ou non

	#TODO
#@mytag
#Scénario: test la possibilité de tirer un nombre de flèches libre
#	Quand J'ouvre une page de cible fita
#	Et je tire une flèche en 200, 100
#	Et je tire une flèche en 100, 300
#	Et je tire une flèche en 0, 0
#	Et Je click sur le bouton nouvelle volée
#	Et  je tire une flèche en 100, 300
#	# possible de changer parceque le nombre de flèches est libre
#	Alors le bouton nouvelle volée est activé

#@mytag
#Scénario: test la desactivation par défault du bouton nombre de flèche
#	Quand J'ouvre une page de cible fita
#	Et j'ouvre le menu de paramètre
#	
#	Alors le nombre de flèche est dasactivé
#	Et le check nombre de flèches n'est pas checké
	
#@mytag
#Scénario: test l'activation du bouton nombre de flèche
#	Quand J'ouvre une page de cible fita
#	Et j'ouvre le menu de paramètre
#	Et je click sur le check nombre de flèches défini
#	
#	Alors le nombre de flèche est activé
#	Et le nombre de flèche est de 6

	
#@mytag
#Scénario: test la non possibilité de tirer une nouvelle flèche
#	Quand J'ouvre une page de cible fita
#	Et j'ouvre le menu de paramètre
#	Et je click sur le check nombre de flèches défini
#	Et je reviens à la page d'avant
#	Et je tire une flèche en 200, 100
#	Et je tire une flèche en 100, 300
#	Et je tire une flèche en 0, 0
#	Et je tire une flèche en 100, 200
#	Et je tire une flèche en 300, 100
#	Et je tire une flèche en 100, 100
#	
#	#le nombre de flèche défini est atteint
#	Et je tire une flèche en 100, 200
#	
#	Alors le nombre de flèches dans la liste est de 6
#	Et le nombre de flèches actuelles sur la cible est de 6