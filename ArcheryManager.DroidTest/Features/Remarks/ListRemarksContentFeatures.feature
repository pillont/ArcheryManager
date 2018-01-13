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


	#// FAIL
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


Scénario: test de la taille des ligne de la list
	Quand J'ouvre une page tabbed de cible fita
	Et je click sur l'onglet de remarque
	Et je rentre "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nibh eros, vehicula at rhoncus at, egestas non felis. Maecenas pulvinar feugiat mollis. In sed nisl dui. Nam magna urna, congue ut maximus at, feugiat vitae sem. Aenean fringilla nibh ac urna sodales, in efficitur tellus sollicitudin. Vivamus gravida semper mi, sit amet maximus justo posuere vel. Fusce id purus nec nunc ultrices pulvinar vel sit amet ex. Fusce a tincidunt enim. Aliquam commodo nisl eros, vel luctus dui consequat id. Nullam egestas vel purus id ultrices. Vestibulum dictum laoreet augue vitae rhoncus. Nullam vestibulum tellus et tortor hendrerit sodales." dans l'éditeur de remarque de la volée
	Et je click sur le bouton de validation des remarques de la volée
	Et je click sur l'onglet de compté
	Et je tire une flèche en -10, 20
	Et Je click sur le bouton nouvelle volée
	Et je click sur l'onglet de remarque
	Et je rentre "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nibh eros, vehicula at rhoncus at, egestas non felis. Maecenas pulvinar feugiat mollis. In sed nisl dui. Nam magna urna, congue ut maximus at, feugiat vitae sem. Aenean fringilla nibh ac urna sodales, in efficitur tellus sollicitudin. Vivamus gravida semper mi, sit amet maximus j" dans l'éditeur de remarque de la volée
	Et je click sur le bouton de validation des remarques de la volée

	Et je rentre "Lorem ipsum " dans l'éditeur de remarque de la volée
	Et je click sur le bouton de validation des remarques de la volée

	Et je click sur le bouton d'historique de remarque de la volée

	Alors la volée de la remarque 0 a comme taille 158
	Et la volée de la remarque 1 a comme taille 158
	Et la remarque 0 a comme taille 1034 
	Et la remarque 1 a comme taille 578

	Quand je scrool en bas
	# scrool remove the first remarks of the view
	Alors la volée de la remarque 1 a comme taille 158
	Et la remarque 1 a comme taille 65


Scénario: test du text par défault pour une liste vide
	Quand J'ouvre une page tabbed de cible fita
	Et je click sur l'onglet de remarque
	Et je click sur le bouton d'historique de remarque générales

	Alors il y a le texte EmptyList
	
