# language: fr-FR
Fonctionnalité: RemarksEditionFeature

Scénario: test des élements de la page d'édition de remarques
	Quand J'ouvre une page d'édition de remarque
	
	Alors il y a l'éditeur de remarques de la volée
	Et il y a l'éditeur de remarques générales
	Alors le text de l'éditeur de remarque générales est emptyMessage
	Alors le text de l'éditeur de remarque générales est emptyMessage
	
Scénario: test du bouton valider
	Quand J'ouvre une page d'édition de remarque
	Alors le bouton validé des remarques de la volée n'est pas utilisable
	Alors le bouton validé des remarques général n'est pas utilisable

	Quand je rentre "aaa" dans l'éditeur de remarque de la volée
	Alors le bouton validé des remarques de la volée est utilisable
	Alors le bouton validé des remarques général n'est pas utilisable

	Quand je rentre "aaa" dans l'éditeur de remarque générales
	Alors le bouton validé des remarques de la volée est utilisable
	Alors le bouton validé des remarques général est utilisable
	
	Quand je click sur le bouton de validation des remarques générales
	Alors le bouton validé des remarques général n'est pas utilisable
	Alors le bouton validé des remarques de la volée est utilisable
	Alors le text de l'éditeur de remarque générales est emptyMessage
	Alors le text de l'éditeur de remarque générales est "aaa"
	
	Quand je click sur le bouton de validation des remarques de la volée
	Alors le bouton validé des remarques général n'est pas utilisable
	Alors le bouton validé des remarques de la volée n'est pas utilisable
	Alors le text de l'éditeur de remarque générales est emptyMessage
	Alors le text de l'éditeur de remarque générales est emptyMessage
	