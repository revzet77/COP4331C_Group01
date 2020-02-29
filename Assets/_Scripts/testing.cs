using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static CameraController;
using static CameraStats;
using static InputHandler;
using static PlayerController;
using static PlayerStats;
using static AIManager;
using static ModeManager;
using static MovementManager;
using static GameManager;
using static GameStates;

// the testing script is meant to cover all our User stories in the sprint backlog
// current automated user stories:
// 003: As a gamer, I want my game to run smoothly so it immerses me.
// 007: As a gamer, I want to have interesting enemies that behave naturally so I am immersed in the game.
// 011: As a gamer, I want to be able to see the status of my health and weaponry.
// ALL unit tests must go with a user story
public class testing : MonoBehaviour
{
    // AI Manager tests
    // test stupid AI (2 constructors, getstyle)
    // User story 007/002
    bool test_stupidAI(){
       
        stupidAI stu = new stupidAI();
        if(stu.getStyle() == 1){
            return true;
        }
        else{
            return false;
        }

        stupidAI stu2 = new stupidAI(0);
        if(stu2.getStyle() == 0){
            return true;
        }
        else{
            return false;
        }
        return true;
        
    }
    // test smart AI (2 constructors, get/set)
    // User story 007/002
    bool test_smartAI(){

        smartAI stu = new smartAI();
        if(stu.getStyle() == 1){
            return true;
        }
        else{
            return false;
        }

        smartAI stu2 = new smartAI(0);
        if(stu2.getStyle() == 0){
            return true;
        }
        else{
            return false;
        }
        stu2.setStyle(2);
        if(stu.getStyle() == 2){
            return true;
        }
        else{
            return false;
        }
        return true;
    }
    // Mode Manager tests
    // User story 007/002
    bool test_enemyMode(){

        enemyMode enMode = new enemyMode();

        if(enMode.getMode() == 1){
            return true;
        }

        return false;
    }
    
    // User Story 00/13
    bool test_inputHandler(){
        InputHandler inp = new InputHandler();
        return inp.TestInputs();

    }
    
    // User Story 00
    bool test_CameraController(){
        CameraController cam = new CameraController();
        if (cam.GetPlayerTransform() == null || cam.GetPlayerTransform().Equals(null))
            return false;

        if (cam.GetTargetPosition() == null || cam.GetTargetPosition().Equals(null))
            return false;

        if (cam.GetCameraStats() == null || cam.GetCameraStats().Equals(null))
            return false;

        return true;
    }
    
    // User Story 00
    bool test_PlayerController(){
        PlayerController play = new PlayerController();

        if (play.GetPlayerStats() == null || play.GetPlayerStats().Equals(null))
            return false;
        if (play.GetCharacterController() == null || play.GetCharacterController().Equals(null))
            return false;
        if (play.GetCameraTransform() == null || play.GetCameraTransform().Equals(null))
            return false;

        return true;
    }

    /*
    // Game Manager test
    // This tests existance of GameObjects necesary for game flow, the coroutines, and the handler functions
    // User Stories 03 and 08
    bool test_GameMangager(){
        GameManager game = new GameManager();

        if(game.gameInstance == null)
            return false;
        if(game.gameState == null)
            return false;
        if(game.player == null)
            return false;
        if(game.playerController == null)
            return false;

        if(game.waveStarting() == null)
            return false;
        if(game.wavePlaying() == null)
            return false;
        if(game.waveEnding() == null)
            return false;
        if(game.GameOver() == null)
            return false;
        if(game.spawnRobots() == null)
            return false;
        if(game.spawnPowerups() == null)
            return false;
        if(game.destroyActiveEnemies() == null)
            return false;
        if(game.EnablePlayerControls() == null)
            return false;
        if(game.DisblePlayerControls() == null)
            return false;

        return true;
    }
     
    */
    // test enemy mode (2 constructors)
    // Movement Manager tests
    // theres no code for it yet

   
    // Start is called before the first frame update
    void Start()
    {
        bool success = true;
        
        success = test_stupidAI();
        success = test_smartAI();
        success = test_enemyMode();
        success = test_inputHandler();
        success = test_CameraController();
        success = test_PlayerController();
        //success = test_GameMangager();
    }


}
