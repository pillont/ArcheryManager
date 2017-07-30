# language: fr-FR
Fonctionnalité: SpecificCounterSettingFeature
	test des paramètres spécifique

Scénario: test du bouton terminé
	Quand J'ouvre une page zappette
	Et j'ouvre le menu de paramètre
	Et je click sur le check nombre de flèches défini
	Et je remplit le nombre de flèche par 3
	Et je click sur le texte Finish
	Et je click sur le boutton 3
	Et je click sur le boutton 5
	Et je click sur le boutton 8
	Et je click sur le boutton 10

	Alors le nombre de flèches dans la liste est de 3