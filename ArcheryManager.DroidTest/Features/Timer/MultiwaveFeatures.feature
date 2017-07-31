# language: fr-FR
Fonctionnalité: TimerMultiWaveFeatures
	Test la posibilité de mettre en multi vagues

Scénario: test des options de bases
	Quand J'ouvre une page timer
	Alors l'option de vague est en ABC


Scénario: test de changement d'option en ABCD
	Quand J'ouvre une page timer
	Et je passe à l'option de vague suivante
	Alors l'option de vague est en ABCD


Scénario: test de changement d'option en Duel
	Quand J'ouvre une page timer
	Et je passe à l'option de vague suivante
	Et je passe à l'option de vague suivante
	Alors l'option de vague est en Duel

	
Scénario: test de vague par défaut en duel 
	Quand J'ouvre une page timer
	Et je passe à l'option de vague suivante
	Et je passe à l'option de vague suivante
	
	Alors le texte de vague contient AB


Scénario: test de permutation de la vague en duel
	Quand J'ouvre une page timer
	Et je passe à l'option de vague suivante
	Et je passe à l'option de vague suivante
	Et je lance le timer
	Et j'arrete le timer

	Alors le texte de vague contient CD
	
Scénario: test de maintien de rythme en duel
	Quand J'ouvre une page timer
	Et je passe à l'option de vague suivante
	Et je passe à l'option de vague suivante
	Et je lance le timer
	Et j'arrete le timer
	Et je lance le timer
	Et j'arrete le timer

	Alors le texte de vague contient AB

Scénario: test de changement d'option en Shootout
	Quand J'ouvre une page timer
	Et je passe à l'option de vague suivante
	Et je passe à l'option de vague suivante
	Et je passe à l'option de vague suivante
	Alors l'option de vague est en ShootOut


Scénario: test de changement d'option retour en ABC
	Quand J'ouvre une page timer
	Et je passe à l'option de vague suivante
	Et je passe à l'option de vague suivante
	Et je passe à l'option de vague suivante
	Et je passe à l'option de vague suivante
	Alors l'option de vague est en ABC


Scénario: test de temps pour l'option shootout
	Quand J'ouvre une page timer
	Et je passe à l'option de vague suivante
	Et je passe à l'option de vague suivante
	Et je passe à l'option de vague suivante
	Alors le timer est à 40 sec
	

Scénario: test de lancement de timer en shootout
	Quand J'ouvre une page timer
	Et je passe à l'option de vague suivante
	Et je passe à l'option de vague suivante
	Et je passe à l'option de vague suivante
	Et je lance le timer
	Alors le timer est à 40 sec
		
Scénario: test de vague par défault
	Quand J'ouvre une page timer
	Alors le text de vague est vide


Scénario: test de la perduration de la vague
	Quand J'ouvre une page timer
	Et je passe à l'option de vague suivante
	Et je lance le timer
	Et j'attend 12 secondes
	Alors le texte de vague contient AB

Scénario: test du texte de la première vague
	Quand J'ouvre une page timer
	Et je passe à l'option de vague suivante
	Alors le texte de vague contient AB

Scénario: test de changement de vague
	Quand J'ouvre une page timer
	Et je passe à l'option de vague suivante
	Et je lance le timer
	Et j'attend 12 secondes
	Et j'arrete le timer
	Et je lance le timer

	Alors le texte de vague contient CD


Scénario: test de permutation de vague
	Quand J'ouvre une page timer
	Et je passe à l'option de vague suivante
	Et je lance le timer
	Et j'attend 12 secondes
	Et j'arrete le timer
	Et je lance le timer
	Et j'attend 12 secondes
	Et j'arrete le timer
	Et je lance le timer
	Et j'attend 12 secondes

	Alors le texte de vague contient CD

Scénario: test de changement de vague apres timer entier
	Quand J'ouvre une page timer
	Et je passe à l'option de vague suivante
	Et je lance le timer
	Et j'attend 150 secondes

	Alors le texte de vague contient CD

Scénario: test de maintient d'une seul vague
	Quand J'ouvre une page timer
	Et je lance le timer
	Et j'arrete le timer

	Alors le text de vague est vide


Scénario: test changement de vague pendant que le timer est actif
	Quand J'ouvre une page timer
	Et je lance le timer
	Et je passe à l'option de vague suivante
	Et j'attend 10 secondes

	Alors le timer est à 120 sec

