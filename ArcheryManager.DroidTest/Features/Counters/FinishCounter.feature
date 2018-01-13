# language: fr-FR
Fonctionnalité: FinishCounter

Scénario: test de finir un compté vide
	Quand J'ouvre une page de cible fita
	Et je click sur le bouton de validation d'un compté
	Alors il y a le texte CantFinishEmptyCount


Scénario: test de finir un compté
	Quand J'ouvre une page de cible fita
	Et je tire une flèche en 0, 100
	Et je click sur le bouton de validation d'un compté

	Alors une vue de bilan de compté s'ouvre