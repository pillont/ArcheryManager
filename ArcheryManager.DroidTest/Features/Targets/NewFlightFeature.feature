# language: fr-FR
Fonctionnalité: NewFlightFeature
	test la possibilité de passer ou non à une nouvelle volée

	#TODO
#@mytag
#Scénario: test l'impossibilité de passer à une nouvelle volée sans avoir tiré de flèche
#	Quand J'ouvre une page de cible fita
#	# pas de flèches tiré
#	Alors le bouton nouvelle volée est désactivé

#@mytag
#Scénario: test la possibilité de passer à une nouvelle volée après avoir tiré une flèche
#	Quand J'ouvre une page de cible fita
#	Et je tire une flèche en 200, 100
#	# flèches tiré, possibilité de changer de volée
#	Alors le bouton nouvelle volée est activé
	
#@mytag
#Scénario: test l'impossibilité de passer à une nouvelle volée après avoir supprimé une flèche
#	Quand J'ouvre une page de cible fita
#	Et je tire une flèche en 200, 100
#	Et je supprime la dernière flèche
#	# plus de flèches tiré
#	Alors le bouton nouvelle volée est désactivé

	
#@mytag
#Scénario: test la desactivation du bouton nouvelle volée avec un nombre défini de flèches
#	Quand J'ouvre une page de cible fita
#	Et j'ouvre le menu de paramètre
#	Et je click sur le check nombre de flèches défini
#	Et je remplit le nombre de flèche par 5
#	Et je reviens à la page d'avant
#	Et je tire une flèche en 200, 100
#	Et je tire une flèche en 100, 300
#	Et je tire une flèche en 0, 0
#	
#	# pas toutes les flèches de tirées
#	Alors le bouton nouvelle volée est desactivé 


#@mytag
#Scénario: test l'activation du bouton nouvelle volée avec un nombre défini de flèches
#	Quand J'ouvre une page de cible fita
#	Et j'ouvre le menu de paramètre
#	Et je click sur le check nombre de flèches défini
#	Et je remplit le nombre de flèche par 5
#	Et je reviens à la page d'avant
#	Et je tire une flèche en 200, 100
#	Et je tire une flèche en 100, 300
#	Et je tire une flèche en 0, 0
#	Et je tire une flèche en 100, 200
#	Et je tire une flèche en 300, 100
#	
#	#le nombre de flèche défini est atteint
#	Alors le bouton nouvelle volée est activé

