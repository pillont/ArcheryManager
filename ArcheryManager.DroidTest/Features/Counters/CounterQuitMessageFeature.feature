# language: fr-FR
Fonctionnalité: CounterQuitMessageFeature
	test le message de confirmation pour quitter une page de compté

Scénario: test le message pour quitter une cible bouton navigation
	Quand J'ouvre une page de cible fita
	Et je reviens à la page d'avant

	Alors il y a le texte SureQuitCount

	Quand je click sur le boutton No

	Alors il y a une cible EnglishTarget

	Quand je reviens à la page d'avant
	Et je click sur le boutton Yes

	Alors il y a le titre de backdoor

Scénario: test le message pour quitter une zapette bouton navigation
	Quand J'ouvre une page zappette
	Et je reviens à la page d'avant

	Alors il y a le texte SureQuitCount

	Quand je click sur le boutton No

	Alors il y a des boutons de EnglishTarget

	Quand je reviens à la page d'avant
	Et je click sur le boutton Yes

	Alors il y a le titre de backdoor
