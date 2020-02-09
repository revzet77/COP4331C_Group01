***Populate each section with information as it applies to your project. If a section does not apply, explain why. Include diagrams (or links to diagrams) in each section, as appropriate. For example, sketches of the user interfaces along with an explanation of how the interface components will work; ERD diagrams of the database; rough class diagrams; context diagrams showing the system boundary; etc.***

# Program Organization

***You should have a diagram of your high level architecture in this section, along with a description of each component and a table that relates each component to one or more user stories.***

The architecture for our game consists of a Game Manager that uses coroutines dedicated to starting each round, playing each round, and ending each round, respectively. In the first coroutine, player and all objects will be spawned. In the second coroutine, player will be playing the actual game, interacting with Non-Player Characters (enemies) and the environment. Player input will be received and movement will be updated, along with health of player and enemies. In the third coroutine, win/loss state will be determined and displayed to the user.

The architecture relates to the user stories through each coroutine. The first coroutine relates to our gamer wanting an environment with enemies to fight. The second coroutine relates to our gamer wanting to move his/her avatar around within the environment and interacting with enemies. The third coroutine relates to our gamer wanting to know when he/she has succeeded or failed based on their health and the amount of enemies left. 

# Major Classes

***You should have an UML class diagram in this section, along with a description of each class and a table that relates each component to one or more user stories. At a minimum, you need 1 diagram of your major classes. You are encouraged to also include more detailed diagrams that include all of your classes.***

![Class Diagram](https://github.com/revzet77/COP4331C_Group01/blob/master/artifacts/images/class%20diagram.png)

- PlayerController
- PlayerStats
- CameraController
- CameraStats

# Data Design

There will be no database for this project, all the data is handled live in-game. 

# Business Rules

***You should list the assumptions, rules, and guidelines from external sources that are impacting your program design.

- The user has prior gaming experience, thus is familiar with the controls.
- 

# User Interface Design

***You should have one or more user interface screens in this section. Each screen should be accompanied by an explaination of the screens purpose and how the user will interact with it. You should relate each screen to one another as the user transitions through the states of your application. You should also have a table that relates each window or component to the support using stories.***

- Currently there is no user interface outside of a third-person camera perspective of a static player model. The user moves the player model with W (forward), A (left), S (backward), D (right), mouse (camera control):
![Interface Diagram](https://github.com/revzet77/COP4331C_Group01/blob/master/artifacts/images/interfaceDiagram.jpg)

- Future UI implementation will include:
  - player health bar.
  - floating enemy health bars.
  - weapon ammo counter + equipped weapon.
  - in-game menu accesible via 'esc' for exiting or pausing the game.

# Resource Management

TBD

# Security

##EnCapSULatIoN

# Performance

TBD

# Scalability

TBD

# Interoperability

TBD

# Internationalization/Localization

TBD

# Input/Output

Keyboard input -> Fun stuff on the screen

# Error Processing

TBD

# Fault Tolerance

TBD

# Architectural Feasibility

TBD

# Overengineering

TBD

# Build-vs-Buy Decisions

***This section should list the third party libraries your system is using and describe what those libraries are being used for.***

- No third party libraries in use currently.

# Reuse

TBD

# Change Strategy

TBD
