# Program Organization


  #**Context Diagram**

![Context Diagram](https://github.com/revzet77/COP4331C_Group01/blob/master/artifacts/images/context_diagram.png)

The architecture for our game consists of a Game Manager that uses coroutines dedicated to starting each round, playing each round, and ending each round, respectively. In the first coroutine, player and all objects will be spawned. In the second coroutine, player will be playing the actual game, interacting with Non-Player Characters (enemies) and the environment. Player input will be received and movement will be updated, along with health of player and enemies. In the third coroutine, win/loss state will be determined and displayed to the user.

The architecture relates to the user stories through each coroutine. The first coroutine relates to our gamer wanting an environment with enemies to fight. The second coroutine relates to our gamer wanting to move his/her avatar around within the environment and interacting with enemies. The third coroutine relates to our gamer wanting to know when he/she has succeeded or failed based on their health and the amount of enemies left. 

| **Architecture Components**	| **User Story ID's** |
|-------------------------|-----------------|
| Start Game Coroutine	| 2, 10 |
| Play Game Coroutine	| 1, 4 |
| End Game Coroutine	| 8 |

  #**Container Diagram**

![Container Diagram](https://github.com/revzet77/COP4331C_Group01/blob/master/artifacts/images/container_diagram.png)

Description TODO

| **Architecture Components**	| **User Story ID's** |
|-------------------------|-----------------|
| TODO	| TODO |
| TODO	| TODO |
| TODO	| TODO |

  #**Component Diagram**

![Component Diagram](https://github.com/revzet77/COP4331C_Group01/blob/master/artifacts/images/Component_diagram.png)


Description TODO

| **Architecture Components**	| **User Story ID's** |
|-------------------------|-----------------|
| TODO	| TODO |
| TODO	| TODO |
| TODO	| TODO |



# Major Classes

***You should have an UML class diagram in this section, along with a description of each class and a table that relates each component to one or more user stories. At a minimum, you need 1 diagram of your major classes. You are encouraged to also include more detailed diagrams that include all of your classes.***

#**Input Handler**

![Class Diagram](https://github.com/revzet77/COP4331C_Group01/blob/master/artifacts/images/class%20diagram.png)

- **PlayerController** manages the player object's interaction with the enviornment as well as with the user. This class relates to the gamer wanting to move around the environment using conventional 3rd person game controls.
- **PlayerStats** tracks the health, position, and weapon choice of the player while playing the game. This class relates to the gamer wanting to know how much health he/she has and which weapon they are using. 
- **CameraController** manages the position and movement, if any, of the camera objets. CameraStats tracks position and physics of camera objects. These classes relate to the gamer wanting to interact with enemies by being able to see where they are in the environment in relation to the player avatar.



| **Major Classes**	| **User Story ID's** |
|---------------|-----------------|
| PlayerController	| 0, 1, 5, 6 |
| PlayerStats |	4, 11 |
| CameraController |	0, 1, 9 |
| CameraStats |	0, 1, 9 |

#**AI Manager**

![AI Manager](https://github.com/revzet77/COP4331C_Group01/blob/master/artifacts/images/AI%20Manager.jpg)

- **AI Manager** This handles all the enemies currently in play and switches the fighting style between long, mid and short range throughout the game.
- **SmartAI** These AI's will change types and cycle through a more sophisticated attack loop.
- **StupidAI** These AI's do not change type and have a pretty normal attack loop.
- **Mode Manager** This handles the attack loops for enemies- mainly switching between offense and defense.
- **Movement Manager** This handles all movement for enemies from basic navMesh, to finding the shortest path, to simple bounding movements.

| **Major Classes**	| **User Story ID's** |
|---------------|-----------------|
| AI Manager	| 2, 4, 5, 12 |
| StupidAI |	2 |
| SmartAI |	2, 7 |
| Mode Manager |	2, 7 |
| Movement Manager |	2, 7, 9, 12 |

#**Game Manager**

TODO (Wallace)


# Data Design

Data like health, position, amount of enemies, and round number are all local variables. When the game is over, the game essentially restarts, so no previous data is needed. Thus, there will be no database for this project, as all the data is handled live, in-game. The PlayerStats and CameraStats hold information for in-game 

# Business Rules

Because our program is a game, external limitations and policies do not really affect us, except for the preferences and previous experiences of the users themselves.
- An assumption we can have is that the user has prior gaming experience, thus is familiar with WASD controls that can move the player around within a virtual 3D space. 

# User Interface Design

Currently there is no user interface outside of a third-person camera perspective of a static player model. The user moves the player model with W (forward), A (left), S (backward), D (right), mouse (camera control).

However, our future interface will be a third person display, always displaying what is in front of the player avatar. There will also be a health bar for the actualy player, floating health bars for each enemy, and an area that displays the weapon being used, as well as any power ups obtained. We also want to implement an in-gamemenu where the player can have options like changing weapons or pausing the game. 
Our interface relates to the gamer wanting to know what their health is, what the enemies' health is, what weapon is being used, being able to explore the environment by seeing what the avatar is seeing in the game environment, and having a smooth, immersive experience.

![Interface Diagram](https://github.com/revzet77/COP4331C_Group01/blob/master/artifacts/images/interfaceDiagram.jpg)

| **Interface Component**	| **User Story ID's** |
|---------------------|-----------------|
| 3rd person camera |	0 |
| WASD controls	| 1 |
| Health Bar for player/enemies	| 5, 11 |
| Weapon system	| 4, 6, 11 |
| In-game menu	| 3, 6 |

# Resource Management

TBD

# Security

Our objects will have private variables and methods to prevent unwanted access. We will also use whatever encapsulation Unity provides for our classes. However, we will not be applying any other security measures as this is a locally installed .exe, so the only security concerns would be if the user alters source code in any way to cheat in the game. Not to mention, this isn't a competitive game so cheating is okay.

# Performance

TBD

# Scalability

Since our program is a single player game, it doesn't require scalability.

# Interoperability

This is not required becuase our program is built within the Unity platform. It does not require other software to assist in functionality.

# Internationalization/Localization

The deployment of this game will only be in the United States so there will be no need to consider internationalization. Not to mention that there are no variables such as time, language, or measurement that would differ depending on the region.

# Input/Output

Keyboard input will move the player around, as well as fire/use any weapons. The result will be the animation and actions of the player model on the screen. 
Input is all handled in the input handler class with an updating functioning polling every frame, error checking here is rather pointless seeing as Unity has a solid model for handling keyboard input, but try-catch blocks are added for sanity sake in case something does happen.

# Error Processing

TBD

# Fault Tolerance

Because our program is a game, faults can be tolerated, such as minor glitches, errors, or even the game crashing. Perfect performance is not the first priority for our program. 

# Architectural Feasibility

TBD

# Overengineering

To make sure we don't overengineer, we are using basic systems and designs first. When those are working, then we will add more to them to further address the user stories. Things that are too complicated but not required by user stories will be used as stretch goals, things that we will not focus on unless there is extra time and all the user stories have been met.
The basic systems and design will follow an object oriented approach by segmenting game components into objects like playerModel, enemyModel, etc. Each with a class possessing stats on gravity, animations, damage, and health. The benefit of this approach being that further mechanics, behaviors and error checking can be easily added in the future without overcomplicating the initial setup.

# Build-vs-Buy Decisions

The project was created on Unity 3D's free edition using free models and packages from the open-source asset store. Since everything needed for creating the game was free, it was very simple to evaluate the cost/benefit of objects.

- [Warrior Pack](https://assetstore.unity.com/packages/3d/animations/warrior-pack-bundle-1-free-36405)
  - Using these models for our characters: the player and enemies.
- [Probuilder](https://unity3d.com/unity/features/worldbuilding/probuilder)
  - Using probuilder for building 3d spaces and environments for testing and play.
- [Low Poly Weapons VOL.1](https://assetstore.unity.com/packages/3d/props/guns/low-poly-weapons-vol-1-151980)
  - Using these models for the weapons equipped by the player.

# Reuse

No reuse, this is a single game executable being created.

# Change Strategy

Every week will determine how the game is looking and see what changes we can add. Also, having people test out the game and give feedback multiple times throughout the development cycle will help us realize things that we missed out for the player experience. 
