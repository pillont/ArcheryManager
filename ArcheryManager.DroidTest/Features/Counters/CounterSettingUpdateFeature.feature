# language: fr-FR
Fonctionnalité: CounterSettingUpdateFeature
	
Scénario: test passage de zappette à cible
		Quand J'ouvre une page de sélection de cible
		Et je click sur l'option cible
		Et je valide la sélection de cible
		Et j'ouvre le menu de paramètre
		Alors il n'y a pas le switch de moyenne

		Quand je reviens à la page d'avant
		Quand je reviens à la page d'avant
		Et je click sur l'option cible
		Et je valide la sélection de cible
		Et j'ouvre le menu de paramètre
		Alors il y a le switch de moyenne


Scénario: test nombre de flèche endessous de l'actuel
		Quand J'ouvre une page de cible fita
		Et je tire une flèche en 30, 40
		Et je tire une flèche en 80, 20
		Et je tire une flèche en 30, 80
		Et je tire une flèche en 30, 80
		Et je tire une flèche en 30, 50
		Et j'ouvre le menu de paramètre
		Et je click sur le check nombre de flèches défini
		Et je rentre 4 en nombre de flèche
		Et je click sur le texte NumberOfArrows
		Alors il y a un message d'erreur
		Et je click sur ok
		Alors le nombre de flèches est de 5



Scénario: test nombre de flèche endessous de l'actuel et du minimum
		Quand J'ouvre une page de cible fita
		Et je tire une flèche en 30, 40
		Et je tire une flèche en 80, 20
		Et je tire une flèche en 30, 80
		Et je tire une flèche en 30, 80
		Et j'ouvre le menu de paramètre
		Et je click sur le check nombre de flèches défini
		Et je rentre 1 en nombre de flèche
		Et je click sur le texte NumberOfArrows
		Alors il y a un message d'erreur
		Et je click sur ok
		Alors le nombre de flèches est de 4
		