# language: fr-FR
Fonctionnalité: TargetRotationFeature
	test sur la rotation du portable sur la page de cible


Scénario: test la position des flèches avant rotation
	Quand J'ouvre une page de cible fita
	Et je tire une flèche en 200, 100
	Et je tire une flèche en 150, 200

	Alors la flèche numéro 0 est en 629, 795
	Alors la flèche numéro 1 est en 566, 916
	
	
Scénario: test la position des flèches après rotation
	Quand J'ouvre une page de cible fita
	Et je tire une flèche en 200, 100
	Et je tire une flèche en 150, 200
	Et je tourne le téléphone

	Alors la flèche numéro 0 est en 484, 550
	Et la flèche numéro 1 est en 436, 643


Scénario: test la position de moyenne après rotation
	Quand J'ouvre une page de cible fita
	Et j'ouvre le menu de paramètre
	Et je click sur l'option de moyenne
	Et je reviens à la page d'avant
	Et je tire une flèche en 200, 100
	Et je tire une flèche en 150, 200
	Et je tourne le téléphone

	Alors la moyenne est centrée en 295, 455
	Et la moyenne est de taille 68, 134

	