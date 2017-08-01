# language: fr-FR
Fonctionnalité: CounterBoutonAddArrowFeature
	test le nombre de flèche max

Scénario: test le nombre de flèche max dans une zapette
	Quand J'ouvre une page zappette
	Et j'ouvre le menu de paramètre
	Et je click sur le slider de nombre fixe de flèche
	Et je rentre 3 en nombre de flèche
	Et je click sur le texte Finish
	Et je click sur le boutton 3
	Et je click sur le boutton 5
	Et je click sur le boutton 8
	Et je click sur le boutton 4

	Alors le nombre de flèches dans la liste est de 3
	Et le message d'erreur du nombre de flèche est affiché