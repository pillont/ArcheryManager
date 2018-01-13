# language: fr-FR
Fonctionnalité: TargetRotationFeature
	test sur la rotation du portable sur la page de cible


#
Scénario: test la position des flèches avant rotation
	Quand J'ouvre une page de cible fita
	Et je tire une flèche en 200, 100
	Et je tire une flèche en 150, 200

	Alors la flèche numéro 0 est en 749, 1142
	Alors la flèche numéro 1 est en 695, 1246
	
	
#
Scénario: test la position des flèches après rotation
	Quand J'ouvre une page de cible fita
	Et je tire une flèche en 200, 100
	Et je tire une flèche en 150, 200
	Et je tourne le téléphone

	Alors la flèche numéro 0 est en 581, 787
	Et la flèche numéro 1 est en 546, 857


#
Scénario: test la position de moyenne après rotation
	Quand J'ouvre une page de cible fita
	Et j'ouvre le menu de paramètre
	Et je click sur l'option de moyenne
	Et je click sur le texte Finish
	Et je tire une flèche en 200, 100
	Et je tire une flèche en 150, 200
	Et je tourne le téléphone

	Alors la moyenne est centrée en 442, 719
	Et la moyenne est de taille 51, 95

	