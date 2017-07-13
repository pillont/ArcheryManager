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
	