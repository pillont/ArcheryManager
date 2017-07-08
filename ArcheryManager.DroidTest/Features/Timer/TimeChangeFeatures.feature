# language: fr-FR
Fonctionnalité: TimeChangeFeatures
	test de changement de temps dans un timer

Scénario: test d'ouverture de picker
	Quand J'ouvre une page timer
	Et Je click sur le bouton de réglage de temps

	Alors un picker s'ouvre 


Scénario: test de temps par défault
	Quand J'ouvre une page timer
	
	Alors le timer est à 120 sec


	
Plan du scénario: test de changement de temps avant changement de vague
	Quand J'ouvre une page timer
	Et Je click sur le bouton de réglage de temps
	Et je selectionne <time> dans le picker
	Et je click sur l'option de vague

	Alors le timer est à <time> sec
	
	Exemples: 
	| time |
	| 240  |
	| 150  |
	| 300  |


Plan du scénario: test de changement de temps
	Quand J'ouvre une page timer
	Et Je click sur le bouton de réglage de temps
	Et je selectionne <time> dans le picker

	Alors le timer est à <time> sec
	
	Exemples: 
	| time |
	| 240  |
	| 150  |
	| 300  |


Plan du Scénario: test de lancement apres changement de temps
	Quand J'ouvre une page timer
	Et Je click sur le bouton de réglage de temps
	Et je selectionne <time> dans le picker
	Et je lance le timer
	Et j'attend 10 secondes

	Alors le timer est à <time> sec
	
	Exemples: 
	| time |
	| 240  |
	| 150  |
	| 300  |

