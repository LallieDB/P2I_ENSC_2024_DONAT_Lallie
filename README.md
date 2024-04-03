# P2I_ENSC_2024

## Installation
### Lien GitHub et lancement de l’exécutable
Pour installer le projet sur votre ordinateur, placez-vous tout d'abord dans le bon emplacement de fichier et suivez les consignes suivantes.
Ouvrez votre terminal de commande et tapez l'instruction suivante : 
`git clone https://github.com/LallieDB/P2I_ENSC_2024.git`

L’exécutable est le dossier : **“TheBirdAndTheIsland.zip”**. Dézipper le dossier.

Ensuite, il vous faudra double-cliquer sur le fichier **“ClickHereToLaunchTheGame.exe”** (il est possible qu’on vous demande si vous êtes sûr de vouloir exécuter le fichier, dans ce cas, il faut que vous allez dans “Informations complémentaires” puis que vous cliquez sur “Exécuter quand même”).

**ATTENTION :** Pour quitter la fenêtre du projet, il faudra que vous ouvrez le gestionnaire des tâches en utilisant les commandes suivantes : “Ctrl +Alt + Suppr”

### Ouvrir le projet sur Unity
Ce projet a été réalisé avec la version 2022.3.13f1 de Unity.
Ouvrez le projet P2I_ENSC_2024 sur Unity.
Dans l'onglet "Projet", allez dans "Assets" et doucle cliquez sur le fichier "GameScene".
Vous pouvez maitenant lancer le projet dans l'onglet Game de Unity ! 

## Le jeu
### Introduction
Ce projet comporte le jeu **L'île et l'oiseau**. 
Dans ce jeu, un dodo doit faire des quêtes pour partir d'une île avant que les humains débarquent et le tue.


### Fonctionnalités
Cette version git comporte :
- la carte du jeu sur lequel le dodo peut se déplacer
- le dodo pousse un cri lorsque la touche F est appuyée
- 2 personnages non jouables : un perroquet que l'on peut faire tourner et une plante avec une tête de perroquet qui donne sa première quête au dodo pour lui permettre d'accéder à la partie Nord de l'île.
- Incorporation de dialogues à choix à l'aide d'une classe Dialogue et du script DialogueManager.
- On peut parler au perroquet à l'aide de la touche P. Le perroquet a deux dialogues différents : un dialogue de base et un second qui s'active si on le pousse. Si on s'excuse dans le deuxième dialogue, le premier dialogue revient.
- Un coffre au trésor que l'on peut ouvrir en appuyant sur la touche O et qui contient une bouteille de poison.
- Des messages dans le jeu qui s'activent à proximité des coffres et des personnages pour dire au joueur sur quelle touche il faut qu'il appuie pour interagir avec le décor.
- Le dodo a un inventaire qui lui permet de stocker des objets
- La plante donne pour quête au joueur de lui rapporter de l'eau. On peut donner la bouteille de poison pour faire disparaître la plante et accéder à la partie Nord de l'île.

### Animations
Le dodo a une animation de déplacement par direction de déplacement (haut, bas, droite, gauche)
Le dodo a une animation quand il reste immobile. (Il tourne en rond)
Le perroquet a deux animations : 
- une animation de base où il bat des ailes
- une animation quand il a la tête retournée ou qu'il tourne


