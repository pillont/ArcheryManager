# language: fr-FR
Fonctionnalité: TimerMultiWaveFeatures
	Test la posibilité de mettre en multi vagues

Scénario: test des options de bases
	Quand J'ouvre une page timer

	Alors l'option de vague est en ABC


Scénario: test de changement d'option en ABCD
	Quand J'ouvre une page timer
	Et que je click sur l'option de vague
	Alors l'option de vague est en ABCD

	
Scénario: test de changement d'option en Shootout
	Quand J'ouvre une page timer
	Et que je click sur l'option de vague
	Et que je click sur l'option de vague
	Alors l'option de vague est en Shootout


Scénario: test de changement d'option retout en ABC
	Quand J'ouvre une page timer
	Et que je click sur l'option de vague
	Et que je click sur l'option de vague
	Et que je click sur l'option de vague
	Alors l'option de vague est en ABC


Scénario: test de changement d'option retout en ABC
	Quand J'ouvre une page timer
	Et que je click sur l'option de vague
	Et que je click sur l'option de vague
	Alors le timer est à 40 sec
	

Scénario: test de changement d'option retout en ABC
	Quand J'ouvre une page timer
	Et que je click sur l'option de vague
	Et que je click sur l'option de vague
	Et que je click sur le timer
	Alors le timer est à 39 sec
		
Scénario: test de vague par défault
	Quand J'ouvre une page timer
	Alors le text de vague est vide


Scénario: test de changement de vague
	Quand J'ouvre une page timer
	Et que je click sur l'option de vague
	Et que je click sur le timer
	Et que j'attend un texte equal à 115
	Et que je click sur le timer

	Alors le texte de vague est CD


Scénario: test de permutation de vague
	Quand J'ouvre une page timer
	Et que je click sur l'option de vague
	Et que je click sur le timer
	Et que j'attend un texte equal à 115
	Et que je click sur le timer
	Et que je click sur le timer
	Et que j'attend un texte equal à 115
	Et que je click sur le timer

	Alors le texte de vague est CD

