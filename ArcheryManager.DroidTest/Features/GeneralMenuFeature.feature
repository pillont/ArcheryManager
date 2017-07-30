# language: fr-FR
Fonctionnalité: test du menu général

Scénario: test des boutons présents
Quand J'ouvre une page de menu general

Alors il y a le texte Timer
Alors il y a le texte CountShoot
Alors il n'y a pas de barre de navigation

Scénario: test du bouton timer
Quand J'ouvre une page de menu general
Et je click sur le bouton de timer

Alors la page timer s'affiche

Scénario: test du bouton tir compté
Quand J'ouvre une page de menu general
Et je click sur le bouton de tir compté

Alors la page de tir compté s'affiche
