# language: fr-FR
Fonctionnalité: CounterQuitMessageFeature
	test le message de confirmation pour quitter une page de compté

Scénario: test le message pour quitter une cible bouton navigation
	Quand J'ouvre une page tabbed de cible fita
	Et je reviens à la page d'avant

	Alors il y a le texte SureQuitCount

	Quand je click sur le texte No

	Alors il y a dans un onglet une cible EnglishTarget

	Quand je reviens à la page d'avant
	Quand je click sur le texte Yes

	Alors il y a le titre de backdoor

	Scénario: test le message pour quitter un compteur par le timer
	Quand J'ouvre une page tabbed de cible fita
	Et je click sur le tab timer
	Et je reviens à la page d'avant

	Alors il y a le texte SureQuitCount


Scénario: test le message pour quitter une zapette bouton navigation
	Quand J'ouvre une page tabbed de zappette
	Et je reviens à la page d'avant

	Alors il y a le texte SureQuitCount

	Quand je click sur le texte No

	Alors il y a des boutons de EnglishTarget

	Quand je reviens à la page d'avant
	Et je click sur le texte Yes
	Et je scrool en haut
	Alors il y a le titre de backdoor

Scénario: test la restitution des option d'un timer après le message d'erreur 
	Quand J'ouvre une page tabbed de cible fita
	Et je click sur le tab timer
	Et Je click sur le bouton de réglage de temps
	Et je selectionne 200 dans le picker
	Et je passe à l'option de vague suivante
	Et je lance le timer
	Et j'attend 5 secondes
	Et je reviens à la page d'avant
	Et je click sur le texte No
	Et je click sur le tab timer

	Alors le timer est à 200 sec
	Et l'option de vague est en ABCD
	Et le texte de vague contient CD

Scénario: test la restitution de score après le message d'erreur dans une zapette 
	Quand J'ouvre une page tabbed de zappette
	Et je click sur le boutton 3
	Et je click sur le boutton 8
	Et je click sur le boutton 6
	Et je click sur le boutton 7

	Et je reviens à la page d'avant
	Et je click sur le texte No

	Alors le nombre de flèches dans la liste est de 4
	Et la fleche 0 de la liste est un 3
	Et la fleche 1 de la liste est un 8
	Et la fleche 2 de la liste est un 6
	Et la fleche 3 de la liste est un 7


	
Scénario: test la restitution de score après le message d'erreur dans une cible
	Quand J'ouvre une page tabbed de cible fita
	Et je tire une flèche en 0, 0
	Et je tire une flèche en 50, 70
	Et je tire une flèche en 30, 20

	Et je reviens à la page d'avant
	Et je click sur le texte No

	Alors le nombre de flèches dans la liste est de 3
	Et la fleche 0 de la liste est un X10
	Et la fleche 1 de la liste est un 8
	Et la fleche 2 de la liste est un 10
	
	Et la fleche 0 de la cible est en 376, 713
	Et la fleche 1 de la cible est en 437, 798
	Et la fleche 2 de la cible est en 415, 737


