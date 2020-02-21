***Populate each section with information as it applies to your project. If a section does not apply, explain why. Include diagrams (or links to diagrams) in each section, as appropriate. For example, sketches of the user interfaces along with an explanation of how the interface components will work; ERD diagrams of the database; rough class diagrams; context diagrams showing the system boundary; etc.***

# Program Organization

***You should have a diagram of your high level architecture in this section, along with a description of each component and a table that relates each component to one or more user stories.***

The architecture for our game consists of a Game Manager that uses coroutines dedicated to starting each round, playing each round, and ending each round, respectively. In the first coroutine, player and all objects will be spawned. In the second coroutine, player will be playing the actual game, interacting with Non-Player Characters (enemies) and the environment. Player input will be received and movement will be updated, along with health of player and enemies. In the third coroutine, win/loss state will be determined and displayed to the user.

The architecture relates to the user stories through each coroutine. The first coroutine relates to our gamer wanting an environment with enemies to fight. The second coroutine relates to our gamer wanting to move his/her avatar around within the environment and interacting with enemies. The third coroutine relates to our gamer wanting to know when he/she has succeeded or failed based on their health and the amount of enemies left. 

| Architecture Components	| User Story ID's |
|-------------------------|-----------------|
| Start Game Coroutine	| 2, 10 |
| Play Game Coroutine	| 1, 4 |
| End Game Coroutine	| 8 |

# Major Classes

***You should have an UML class diagram in this section, along with a description of each class and a table that relates each component to one or more user stories. At a minimum, you need 1 diagram of your major classes. You are encouraged to also include more detailed diagrams that include all of your classes.***

![Class Diagram](https://github.com/revzet77/COP4331C_Group01/blob/master/artifacts/images/class%20diagram.png)

- PlayerController manages the player object's interaction with the enviornment as well as with the user. This class relates to the gamer wanting to move around the environment using conventional 3rd person game controls.
- PlayerStats tracks the health, position, and weapon choice of the player while playing the game. This class relates to the gamer wanting to know how much health he/she has and which weapon they are using. 
- CameraController manages the position and movement, if any, of the camera objets. CameraStats tracks position and physics of camera objects. These classes relate to the gamer wanting to interact with enemies by being able to see where they are in the environment in relation to the player avatar.


| Major Classes	| User Story ID's |
|---------------|-----------------|
| PlayerController	| 0, 1, 5, 6 |
| PlayerStats |	4, 11 |
| CameraController |	0, 1, 9 |
| CameraStats |	0, 1, 9 |

# Data Design

Data like health, position, amount of enemies, and round number are all local variables. When the game is over, the game essentially restarts, so no previous data is needed. Thus, there will be no database for this project, as all the data is handled live, in-game. The PlayerStats and CameraStats hold information for in-game 

# Business Rules

***You should list the assumptions, rules, and guidelines from external sources that are impacting your program design.***

Because our program is a game, external limitations and policies do not really affect us, except for the preferences and previous experiences of the users themselves.
- An assumption we can have is that the user has prior gaming experience, thus is familiar with WASD controls that can move the player around within a virtual 3D space. 

# User Interface Design

***You should have one or more user interface screens in this section. Each screen should be accompanied by an explaination of the screens purpose and how the user will interact with it. You should relate each screen to one another as the user transitions through the states of your application. You should also have a table that relates each window or component to the support using stories.***

Currently there is no user interface outside of a third-person camera perspective of a static player model. The user moves the player model with W (forward), A (left), S (backward), D (right), mouse (camera control).

However, our future interface will be a third person display, always displaying what is in front of the player avatar. There will also be a health bar for the actualy player, floating health bars for each enemy, and an area that displays the weapon being used, as well as any power ups obtained. We also want to implement an in-gamemenu where the player can have options like changing weapons or pausing the game. 
Our interface relates to the gamer wanting to know what their health is, what the enemies' health is, what weapon is being used, being able to explore the environment by seeing what the avatar is seeing in the game environment, and having a smooth, immersive experience.

![Interface Diagram](https://github.com/revzet77/COP4331C_Group01/blob/master/artifacts/images/interfaceDiagram.jpg)

| Interface Component	| User Story ID's |
|---------------------|-----------------|
| 3rd person camera |	0 |
| WASD controls	| 1 |
| Health Bar for player/enemies	| 5, 11 |
| Weapon system	| 4, 6, 11 |
| In-game menu	| 3, 6 |

# Resource Management

TBD

# Security

Our objects will have private variables and methods to prevent unwanted access. We will also use whatever encapsulation Unity provides for our classes. However, we will not be 

# Performance

TBD

# Scalability

Since our program is a single player game, it doesn't require scalability.

# Interoperability

This is not required becuase our program is built within the Unity platform. It does not require other software to assist in functionality.

# Internationalization/Localization

This is not required as our game will only be in English.

# Input/Output

Keyboard input will move the player around, as well as fire/use any weapons. The result will be the movement of the player on the screen and a fun, interactive experience for the user.

# Error Processing

TBD

# Fault Tolerance

Because our program is a game, faults can be tolerated, such as minor glitches, errors, or even the game crashing. Perfect performance is not the first priority for our program. 

# Architectural Feasibility

TBD

# Overengineering

To make sure we don't overengineer, we are using bacis systems and designs first. When those are working, then we will add more to them to further address the user stories. Things that are too complicated but not required by user stories will be used as stretch goals, things that we will not focus on unless there is extra time and all the user stories have been met.

# Build-vs-Buy Decisions

***This section should list the third party libraries your system is using and describe what those libraries are being used for.***

- [Warrior Pack](https://assetstore.unity.com/packages/3d/animations/warrior-pack-bundle-1-free-36405)
  - Using these models for our characters: the player and enemies.
- [Probuilder](https://unity3d.com/unity/features/worldbuilding/probuilder)
  - Using probuilder for building 3d spaces and environments for testing and play.

# Reuse

No reuse, this is a single game executable being created.

# Change Strategy

Every week will determine how the game is looking and see what changes we can add. Also, having people test out the game and give feedback multiple times throughout the development cycle will help us realize things that we missed out for the player experience. 
