# language: fr-FR
Fonctionnalité: TargetRotationFeature
	test sur la rotation du portable sur la page de cible


Scénario: test la position des flèches avant rotation
	Quand J'ouvre une page de cible fita
	Et je tire une flèche en 200, 100
	Et je tire une flèche en 150, 200

	Alors la flèche numéro 0 est en 558, 758
	Alors la flèche numéro 1 est en 512, 844
	
	
Scénario: test la position des flèches après rotation
	Quand J'ouvre une page de cible fita
	Et je tire une flèche en 200, 100
	Et je tire une flèche en 150, 200
	Et je tourne le téléphone

	Alors la flèche numéro 0 est en 429, 522
	Et la flèche numéro 1 est en 394, 588
	