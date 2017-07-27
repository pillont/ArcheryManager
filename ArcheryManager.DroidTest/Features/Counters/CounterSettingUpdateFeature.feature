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
		