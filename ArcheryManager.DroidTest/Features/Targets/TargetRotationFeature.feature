# language: fr-FR
Fonctionnalité: TargetRotationFeature
	test sur la rotation du portable sur la page de cible


Scénario: test la position des flèches avant rotation
	Quand J'ouvre une page de cible fita
	Et je tire une flèche en 200, 100
	Et je tire une flèche en 150, 200

	Alors la flèche numéro 0 est en 629, 814
	Alors la flèche numéro 1 est en 566, 935
	
	
Scénario: test la position des flèches après rotation
	Quand J'ouvre une page de cible fita
	Et je tire une flèche en 200, 100
	Et je tire une flèche en 150, 200
	Et je tourne le téléphone

	Alors la flèche numéro 0 est en 462, 586
	Et la flèche numéro 1 est en 418, 668


Scénario: test la position de moyenne après rotation
	Quand J'ouvre une page de cible fita
	Et j'ouvre le menu de paramètre
	Et je click sur l'option de moyenne
	Et je reviens à la page d'avant
	Et je tire une flèche en 200, 100
	Et je tire une flèche en 150, 200
	Et je tourne le téléphone

	Alors la moyenne est centrée en 295, 502
	Et la moyenne est de taille 59, 115

	