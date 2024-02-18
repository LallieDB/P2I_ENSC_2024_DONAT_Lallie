# P2I_ENSC_2024

## Installation
Pour installer le projet sur votre ordinateur, placez-vous tout d'abord dans le bon emplacement de fichier et suivez les consignes suivantes.

Ouvrez votre terminal de commande et tapez l'instruction suivante : 

`git clone https://github.com/LallieDB/P2I_ENSC_2024.git`

Ouvrez le projet P2I_ENSC_2024 sur Unity.
Dans l'onglet "Projet", allez dans "Assets" et doucle cliquez sur le fichier "sauvegarde".
Vous pouvez lancez le projet dans l'onglet Game de Unity ! 

## Le jeu
### Introduction
Ce projet comporte le jeu **L'île et l'oiseau**. 
Dans ce jeu, un dodo doit faire des quêtes pour partir d'une île avant que les humains débarquent et le tue.


### Fonctionnalités
Cette version git comporte :
- la carte du jeu sur lequel le dodo peut se déplacer
- le dodo pousse un cri lorsque la touche F est appuyée
- 2 personnages non jouables : un perroquet qu'on peut faire tourner et une plante avec une tête de perroquet qui empêche au dodo d'accéder à la partie Nord de l'île
- Incorporation de dialogues à choix à l'aide d'une classe Dialogue et du script DialogueManager.
- On peut parler au perroquet à l'aide de la touche P. Le perroquet a deux dialogues différents : un dialogue de base et un second qui s'active si on le pousse. Si on s'excuse dans le deuxième dialogue, le premier dialogue revient.
- Deux coffres au trésor que l'on peut ouvrir en appuyant sur la touche O.
- Des messages dans la console qui s'activent à proximité des coffres et des personnages pour dire au joueur quelle touche il faut qu'il appuie pour interagir avec le décor.

### Animations
Le dodo a une animation de déplacement par direction de déplacement (haut, bas, droite, gauche)
Le dodo a une animation quand il reste immobile. (Il tourne en rond)
Le perroquet a deux animations : 
- une animation de base où il bat des ailes
- une animation quand il tourne ou quand il n'est pas droit (si il a la tête à l'envers par exemple)

