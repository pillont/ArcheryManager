# language: fr-FR
Fonctionnalité: TimerMultiWaveFeatures
	Test la posibilité de mettre en multi vagues

Scénario: test des options de bases
	Quand J'ouvre une page timer
	Alors l'option de vague est en ABC


Scénario: test de changement d'option en ABCD
	Quand J'ouvre une page timer
	Et je click sur l'option de vague
	Alors l'option de vague est en ABCD

	
Scénario: test de changement d'option en Shootout
	Quand J'ouvre une page timer
	Et je click sur l'option de vague
	Et je click sur l'option de vague
	Alors l'option de vague est en Shootout


Scénario: test de changement d'option retour en ABC
	Quand J'ouvre une page timer
	Et je click sur l'option de vague
	Et je click sur l'option de vague
	Et je click sur l'option de vague
	Alors l'option de vague est en ABC


Scénario: test de temps pour l'option shootout
	Quand J'ouvre une page timer
	Et je click sur l'option de vague
	Et je click sur l'option de vague
	Alors le timer est à 40 sec
	

Scénario: test de lancement de timer en shootout
	Quand J'ouvre une page timer
	Et je click sur l'option de vague
	Et je click sur l'option de vague
	Et je lance le timer
	Alors le timer est à 39 sec
		
Scénario: test de vague par défault
	Quand J'ouvre une page timer
	Alors le text de vague est vide


Scénario: test du texte de la première vague
	Quand J'ouvre une page timer
	Et je click sur l'option de vague
	Alors le texte de vague contient AB

Scénario: test de changement de vague
	Quand J'ouvre une page timer
	Et je click sur l'option de vague
	Et je lance le timer
	Et j'attend 12 secondes

	Et j'attend un texte equal à 115
	Et je lance le timer

	Alors le texte de vague contient CD


Scénario: test de permutation de vague
	Quand J'ouvre une page timer
	Et je click sur l'option de vague
	Et je lance le timer
	Et j'attend un texte equal à 115
	Et je lance le timer
	Et je lance le timer
	Et j'attend un texte equal à 115
	Et je lance le timer

	Alors le texte de vague contient CD

