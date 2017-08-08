# language: fr-FR
Fonctionnalité: ListRemarksContentFeatures
	
	Scénario: test de sauvegarde des remarques générales
	Quand J'ouvre une page tabbed de cible fita
	Et je click sur l'onglet de remarque
	Et je rentre "aaa" dans l'éditeur de remarque générales
	Et je click sur le bouton de validation des remarques générales
	Et je click sur l'onglet de compté
	Et je tire une flèche en -10, 20
	Et Je click sur le bouton nouvelle volée
	Et je click sur l'onglet de remarque
	Et je rentre "bbb" dans l'éditeur de remarque générales
	Et je click sur le bouton de validation des remarques générales

	Et je rentre "ccc" dans l'éditeur de remarque générales
	Et je click sur le bouton de validation des remarques générales

	Et je click sur le bouton d'historique de remarque générales

	Alors la remarque 0 est "aaa"
	Alors la remarque 1 est "bbb"
	Alors la remarque 2 est "ccc"
	Et la volée de la remarque 0 n'est pas visible
	Et la volée de la remarque 1 n'est pas visible
	Et la volée de la remarque 2 n'est pas visible


	
	Scénario: test de sauvegarde des remarques de volées
	Quand J'ouvre une page tabbed de cible fita
	Et je click sur l'onglet de remarque
	Et je rentre "aaa" dans l'éditeur de remarque de la volée
	Et je click sur le bouton de validation des remarques de la volée
	Et je click sur l'onglet de compté
	Et je tire une flèche en -10, 20
	Et Je click sur le bouton nouvelle volée
	Et je click sur l'onglet de remarque
	Et je rentre "bbb" dans l'éditeur de remarque de la volée
	Et je click sur le bouton de validation des remarques de la volée

	Et je rentre "ccc" dans l'éditeur de remarque de la volée
	Et je click sur le bouton de validation des remarques de la volée

	Et je click sur le bouton d'historique de remarque de la volée

	Alors la remarque 0 est "aaa"
	Et la remarque 1 est "bbb"
	Et la remarque 2 est "ccc"
	Et la volée de la remarque 0 est 1
	Et la volée de la remarque 1 est 2
	Et la volée de la remarque 2 est 2
