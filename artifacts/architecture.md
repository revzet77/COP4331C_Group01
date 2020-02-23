# Program Organization


### Context Diagram

![Context Diagram](https://github.com/revzet77/COP4331C_Group01/blob/master/artifacts/images/context_diagram.png)

When the player interacts with the game, they will enter the main gaming loop. This is a conventional organization style for games, and the player's entire experience will be within the loop. This includes attacking enemies, losing health, creative gameplay, and any standard experience a player can create with a conventional game design model (e.g: a systems with rules that ends with a win or lose state). The gaming loop end either when the player reaches a win or lose state. 

| **Architecture Components**	| **User Story ID's** |
|-------------------------|-----------------|
| Start Game Coroutine	| 2, 10 |
| Play Game Coroutine	| 1, 4 |
| End Game Coroutine	| 8 |

### Container Diagram

![Container Diagram](https://github.com/revzet77/COP4331C_Group01/blob/master/artifacts/images/container_diagram.png)

The architecture for our game consists of a Game Manager that uses coroutines dedicated to starting each round, playing each round, and ending each round, respectively. In the first coroutine, player and all objects will be spawned. In the second coroutine, player will be playing the actual game, interacting with Non-Player Characters (enemies) and the environment. Player input will be received and movement will be updated, along with health of player and enemies. In the third coroutine, win/loss state will be determined and displayed to the user.

The architecture relates to the user stories through each coroutine. The first coroutine relates to our gamer wanting an environment with enemies to fight. The second coroutine relates to our gamer wanting to move his/her avatar around within the environment and interacting with enemies. The third coroutine relates to our gamer wanting to know when he/she has succeeded or failed based on their health and the amount of enemies left. 

Throughout the game loop, the Game Manager uses information from the health system to check if the player is still alive, as well as handling any powerups that affect the health. It also interacts with the weapon system to determine which weapon is being used and how much damage it deals to the enemies. The game manager also manages the inputs given by the user and handles that input relative to what is happening in the game. Also, the game manager allows an environment for the enemey AI to function, so information and behaviors from the AI Manager are used whenever an enemy is alive. 

| **Architecture Components**	| **User Story ID's** |
|-------------------------|-----------------|
| Game Manager	| 3 |
| Health and Weapon System	| 4, 5, 6, 11 |
| Input Manager	| 0, 13 |
| AI Manager | 2, 5, 7, 9, 12 |

### Component Diagram

![Component Diagram](https://github.com/revzet77/COP4331C_Group01/blob/master/artifacts/images/Component_diagram.png)


The InputHandler works around the user by taking direct inputs from the UI, keyboard, and mouse and converting that into motion and actions performed by the player character. This includes feats like running, jumping, shooting their weapon, etc. Each of these inputs will be sent to a Controller based off of the states set by the Game Manager script. This will allow the game to adapt the controls as it sees fit based off of if the player is in a menu, in game, or has paused the game.

The AI Manager works by taking in updates on the Players current stats and reacts by setting different AI states to try and defeat the player. This would include change AI tactics to be more defensive if the player has not moved a certain amount of distance within a given timeframe. The AI Manager will then set the modes of the NPC's and will also send locational points to move at to the Movement Manager, which will move the NPC to that given location.


| **Architecture Components**	| **User Story ID's** |
|-------------------------|-----------------|
| AIControl	| 2, 5, 7, 9, 12 |
| PlayerControl	| 0, 4, 5, 6, 11, 13 |



# Major Classes

In this project, we have three key approaches designing each of the classes being used. 
-	**Manager**
-	**Handler**
-	**Controller**
-	**Stats**

The Manager class is designed to act as the starting point for all the logic. All the input from this class is information sent from the last frame update, which includes information such as state transitions and transform data of in-game objects. With this input the Manager sets the states for the particular frame and sends them as output to all of the connected Handler classes.
Next, there’s the Handler classes. All handler classes will take in states given from the manager class as well as some form of input from the user (ie. keyboard, mouse, or UI input). Using the states given from the Manager class, the input is sent as output to one of succeeding Controller classes.
At the end of the hierarchy, we have the Controller classes, these take in the output calculated by their corresponding Handler classes and translate that input into audio/visual feedback displayed in-game. 
While they are not directly a part of the logical hierarchy, all controllers will have an associated Stats class. These are merely classes that are given public, fixed values that are used by their related Controller class. These values often pertain to values used to determine speed, jump height, rotation speed, and other similar values.


### Input Handler

![Class Diagram](https://github.com/revzet77/COP4331C_Group01/blob/master/artifacts/images/InputHandlerC4.png)

- **PlayerController** manages the player object's interaction with the enviornment as well as with the user. This class relates to the gamer wanting to move around the environment using conventional 3rd person game controls.
- **PlayerStats** tracks the health, position, and weapon choice of the player while playing the game. This class relates to the gamer wanting to know how much health he/she has and which weapon they are using. 
- **CameraController** manages the position and movement, if any, of the camera objets. CameraStats tracks position and physics of camera objects. These classes relate to the gamer wanting to interact with enemies by being able to see where they are in the environment in relation to the player avatar.


| **Major Classes**	| **User Story ID's** |
|---------------|-----------------|
| PlayerController	| 0, 1, 5, 6 |
| PlayerStats |	4, 11 |
| CameraController |	0, 1, 9 |
| CameraStats |	0, 1, 9 |

### AI Manager

![AI Manager](https://github.com/revzet77/COP4331C_Group01/blob/master/artifacts/images/AI%20Manager.jpg)

- **AI Manager** This handles all the enemies currently in play and switches the fighting style between long, mid and short range throughout the game.
- **SmartAI** These AI's will change types and cycle through a more sophisticated attack loop.
- **StupidAI** These AI's do not change type and have a pretty normal attack loop.
- **Mode Manager** This handles the attack loops for enemies- mainly switching between offense and defense.
- **Movement Manager** This handles all movement for enemies from basic navMesh, to finding the shortest path, to simple bounding movements.

| **Major Classes**	| **User Story ID's** |
|---------------|-----------------|
| AI Manager	| 2, 4, 5, 12 |
| StupidAI |2 |
| SmartAI |	2, 7 |
| Mode Manager |	2, 7 |
| Movement Manager |	2, 7, 9, 12 |

### Game Manager

![Game Manager](https://github.com/revzet77/COP4331C_Group01/blob/master/artifacts/images/GameManager.png)

- **GameManager** controls the loop of the game using coroutines. This class allows the main classes to interact with each other and relies on the game state, as well as the player state, to determine when the game will end. This allows for a smooth flow and an actual game to run. 
- **GameStates** holds the states of the game using boolean and integer values. This class is necessary for maintaining and ending the game.

| **Major Classes**	| **User Story ID's** |
|---------------|-----------------|
| Game Manager	| 3, 8 |
| Game States |	3, 8 |


# Data Design

Data like health, position, amount of enemies, and round number are all local variables. When the game is over, the game essentially restarts, so no previous data is needed. Thus, there will be no database for this project, as all the data is handled live, in-game. The PlayerStats and CameraStats hold information for in-game 

# Business Rules

Because our program is a game, external limitations and policies do not really affect us, except for the preferences and previous experiences of the users themselves.
- An assumption we can have is that the user has prior gaming experience, thus is familiar with WASD controls that can move the player around within a virtual 3D space.
- This game is targeted towards a wide range of gamers, as such it should efficiently run on most modern machines. Keeping this in mind reservations were held with adding features to AI and graphics to ensure the game runs smoothly on the system.

# User Interface Design

Currently there is no user interface outside of a third-person camera perspective of a static player model. The user moves the player model with W (forward), A (left), S (backward), D (right), mouse (camera control).

However, our future interface will be a third person display, always displaying what is in front of the player avatar. There will also be a health bar for the actualy player, floating health bars for each enemy, and an area that displays the weapon being used, as well as any power ups obtained. We also want to implement an in-gamemenu where the player can have options like changing weapons or pausing the game. 
Our interface relates to the gamer wanting to know what their health is, what the enemies' health is, what weapon is being used, being able to explore the environment by seeing what the avatar is seeing in the game environment, and having a smooth, immersive experience.

TODO: add pictures (wallace)

| **Interface Component**	| **User Story ID's** |
|---------------------|-----------------|
| 3rd person camera |	0 |
| WASD controls	| 1 |
| Health Bar for player/enemies	| 5, 11 |
| Weapon system	| 4, 6, 11 |
| In-game menu	| 3, 6 |

# Resource Management

Resource management is largely to be handled in two ways:
-	Pooling of graphically intensive assets
-	Multi-threading of CPU-intensive calculations made by AI. In-game there constantly going to be many graphical assets that are on display in a given frame. While this may result in the game having high-fidelity, it may also result in slower performance. To counteract this while still retaining the desired fidelity, many graphical assets will following a strict pooling method. Where only a set number of a certain asset is allowed to exist at a given time. If at any point in the game’s logic should there a request to add more than the allotted number of assets, the earliest spawned asset will be reset and redeployed as the newest spawn of that given asset. The next case of resource management is taken care of by multi-threading AI. While most of the game’s logic will be handled frame-by-frame some of the logic, specifically the AI, will need to be handled at a much quicker rate. As a result, most of the logic used by the AI manager will be handled through the use of multi-threading. This ultimately allows our AI to quickly handle tasks like state management and movement pathing for multiple NPC’s at once without putting too much strain on the performance.


# Security

Our objects will have private variables and methods to prevent unwanted access. We will also use whatever encapsulation Unity provides for our classes. However, we will not be applying any other security measures as this is a locally installed .exe, so the only security concerns would be if the user alters source code in any way to cheat in the game. Not to mention, this isn't a competitive game so cheating is okay.

# Performance

Our objective is to have this game run on very low power computers, so as such we have taken a couple steps to improve performance. First of all, the graphics in this game are lo-poly to prevent any buffering. Next, we have included stupidAI's into our design. These AI's have less computational work to do compared to the smart, adaptive ones. That way, the player has the illusion o fighting many smart enemies, because there is no visual difference between the stupid and smart AI's in the game. We are also incorporating best practice tenchinques into our coding to prevent unnecessary slow downs that could result in the player being taken out of the game.

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

Much of our error processing is already handled by the default Unity engine. In this regard, most errors are usually to be ignored as long as it does not directly result in the game ceasing normal function (ie. A direct crash to desktop). For QA testing however, a log of any anomalies in behavior (like NPCs not responding to instructions within 5 seconds) will be displayed in the Unity Console.

# Fault Tolerance

Because our program is a game, faults can be tolerated, such as minor glitches, errors, or even the game crashing. Perfect performance is not the first priority for our program. 

# Architectural Feasibility

All of the team members have experience with C#, and several members have worked with game development, AI, or Unity in other classes. Because of this, We believe it this project's requirements are reasonable because almost everyone on the team has a good base of knowledge of Unity or C#. The hardest part of this project will be staying on pace, AI coding, and playtesting.

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

With this project, an emphasis on modularity was one of the primary concerns. As discussed, change within a project of this scale is often a constant. Thus, rigidity in the programming logic has been designed to be kept at a minimum. To allow for this, the project implements a strict logical order between the classes (See Major Classes) but does not have any limit to how many types of classes used or implemented. The flexibility comes from how output is sent to other classes. For instance, one of the outputs sent from InputHandler is keyboard input. Depending on the active states, this keyboard input can be sent as output to any number of Controller classes as long as it follows that logical hierarchy. As a result, the project has a modular logical hierarchy where features can be added, removed, or adjusted if the hierarchy is still followed.
