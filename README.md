# Physique 3D dans Unity
Quelques exemples pour démontrer l'usage de la physique dans Unity (version 5.6).

Les démonstrations de ce projet sont des expérimentations dans le but d'avoir les connaissance nécessaire à créer [une présentation sur la physique de Unity](https://docs.google.com/presentation/d/1cEp7v0rYgRKL1XR2oStYawRknT3foLZcdEpbUECgTGU/edit?usp=sharing) et à la ponctuer.


## Contrôle
Les véhicules et personnages présents sont fait pour être contrôllés à l'aide d'une manette. Pour de meilleurs résultats, utiliser une manette de XBox sur l'OS Windows.

### Navigation
- **Gachette de droite :** aller à la scène suivante
- **Gachette de gauche :** retourner à la scène précédente
- **Épaule de droite :** aller à la prochaine étape (quelques scènes seulement)

### Objet déplaçable
- **Joystick de gauche :** se déplacer

### Personnage
- **Joystick de gauche :** se déplacer
- **Bouton 'A' :** sauter

### Véhicule
- **Joystick de gauche :** tourner
- **Bouton 'A' :** accélérer
- **Bouton 'B' :** freiner
- **Bouton 'Y' :** reculer
- **Bouton 'X' :** réinitialiser la position


## Scènes
- Le dossier **DemoScenes** contient les différentes démos en plusieurs scènes. Aller dans la scène **Kinematic** permet d'utiliser la navigation entre les scènes.
- **main** contient toutes les démonstrations.
- **drive** contient un vaste terrain et un véhicule pour mieux démontrer l'usage du _Wheel Collider_ que dans la scène _main_.
