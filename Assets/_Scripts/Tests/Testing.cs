using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;


using static CameraController;
using static CameraStats;
using static InputHandler;
using static PlayerController;
using static PlayerStats;
using static AIManager;
using static ModeController;
using static GameManager;
using static GameStates;
using static UIManager;
using static MovementController;

// the testing script is meant to cover all our User stories in the sprint backlog
// current user stories in the backlog that are either working/testing/done:
// 000, 001, 002, 003, 004, 007, 008, 010,  011, 012, 013
// please CTRL-F to find the test for each story
// ALL unit tests must go with a user story
public class testing 
{
    // AI Manager tests
    // test stupid AI (2 constructors, getstyle)
    // User story 007 / 002
    [Test]
    public void test_AIManager(){
        AIManager ai_guy = new AIManager();
        Assert.That(ai_guy.overallStyle, Is.EqualTo(1));
        Assert.That(ai_guy.damageCount, !(Is.EqualTo(null)));
        Assert.That(ai_guy.killed, Is.EqualTo(true));
        Assert.That(ai_guy.isAlive, Is.EqualTo(false));

        ai_guy.setLive();
        Assert.That(ai_guy.isAlive, Is.EqualTo(true));
        ai_guy.setDead();
        Assert.That(ai_guy.isAlive, Is.EqualTo(false));
        Assert.That(ai_guy.killed, Is.EqualTo(true));

    }

    [Test]
    public void test_stupidAI(){
       
        
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = new Vector3(0, 0.5f, 0);
        stupidAI stu = new stupidAI(cube, cube.transform);
        Assert.That(stu.getStyle(), Is.EqualTo(1));
       
        stupidAI stu2 = new stupidAI(0, cube, cube.transform);
        Assert.That(stu.getStyle(), Is.EqualTo(0));
       
        
    }
    // test smart AI (2 constructors, get/set)
    // User story 007/002
    [Test]
    public void test_smartAI(){
    
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = new Vector3(0, 0.5f, 0);
        smartAI stu = new smartAI(cube, cube.transform);
        Assert.That(stu.getStyle(), Is.EqualTo(1));

        smartAI stu2 = new smartAI(0, cube, cube.transform);
        Assert.That(stu2.getStyle(), Is.EqualTo(0));

        stu2.setStyle(2);
        Assert.That(stu.getStyle(), Is.EqualTo(2));

    }
    // Mode Manager tests
    // User story 007/002
    [Test]
    public void test_enemyMode(){

        enemyMode enMode = new enemyMode();

        Assert.That(enMode.getMode(), Is.EqualTo(1));

    }
    
    // User Story 000 / 013 /001 
    [Test]
    public void test_inputHandler(){
        InputHandler inp = new InputHandler();
        inp.TestInputs();

    }
    
    // User Story 000 /001
    [Test]
    public void test_CameraController(){
        CameraController cam = new CameraController();

        Assert.That(cam.GetPlayerTransform(), !(Is.EqualTo(null)));
        Assert.That(cam.GetTargetPosition(), !(Is.EqualTo(null)));
        Assert.That(cam.GetCameraStats(), !(Is.EqualTo(null)));
        

    }
    
    // User Story 000
    [Test]
    public void test_PlayerController(){
        PlayerController play = new PlayerController();

        Assert.That(play.GetPlayerStats(), !(Is.EqualTo(null)));
        Assert.That(play.GetCharacterController(), !(Is.EqualTo(null)));
        Assert.That(play.GetCameraTransform(), !(Is.EqualTo(null)));

    }

    
    // Game Manager test
    // User Stories 003 / 008 / 011 / 004
	[Test]
    public void test_GameManager(){
        
        GameManager game = new GameManager();
        
        Assert.IsNotNull(GameManager.gameState, "GameManager.gameState");
        Assert.IsNotNull(GameManager.UI_Man, "GameManager.UI_Man");
        Assert.IsNotNull(game.player, "game.player");
        Assert.IsNotNull(game.pStats, "game.pStats");

    }
    
    // UI Manager test
    // User Stories 005 / 008 / 011 /010
    [Test]
    public void test_UIManager(){
        
        UIManager game = new UIManager();

        Assert.IsNotNull(game.gameMenu, "game.gameMenu");
        Assert.IsNotNull(game.playerUI, "game.playerUI");
        Assert.IsNotNull(game.healthBar, "game.healthBar");
    }
    

    // test enemy mode (2 constructors)
    // user story 012
    // Movement Controller tests
    [Test]
    public void test_MovementController(){
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        UnityEngine.AI.NavMeshAgent agent = cube.AddComponent(typeof(UnityEngine.AI.NavMeshAgent)) as UnityEngine.AI.NavMeshAgent;

        MovementController mover = new MovementController(agent);
        Assert.IsNotNull(mover);
 
    }




}
