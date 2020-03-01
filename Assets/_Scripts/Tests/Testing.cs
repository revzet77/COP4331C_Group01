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
using static ModeManager;
using static MovementManager;
using static GameManager;
using static GameStates;

// the testing script is meant to cover all our User stories in the sprint backlog
// current user stories in the backlog that are either working/testing/done:
// 000, 001, 002, 003, 007, 008, 011, 013
// please CTRL-F to find the test for each story
// ALL unit tests must go with a user story
public class testing 
{
    // AI Manager tests
    // test stupid AI (2 constructors, getstyle)
    // User story 007 / 002
    [Test]
    void test_stupidAI(){
       
        stupidAI stu = new stupidAI();
        Assert.That(stu.getStyle(), Is.EqualTo(1));
       
        stupidAI stu2 = new stupidAI(0);
        Assert.That(stu.getStyle(), Is.EqualTo(10));
       
        
    }
    // test smart AI (2 constructors, get/set)
    // User story 007/002
    [Test]
    void test_smartAI(){

        smartAI stu = new smartAI();
        Assert.That(stu.getStyle(), Is.EqualTo(1));

        smartAI stu2 = new smartAI(0);
        Assert.That(stu2.getStyle(), Is.EqualTo(0));

        stu2.setStyle(2);
        Assert.That(stu.getStyle(), Is.EqualTo(2));

    }
    // Mode Manager tests
    // User story 007/002
    [Test]
    void test_enemyMode(){

        enemyMode enMode = new enemyMode();

        Assert.That(enMode.getMode(), Is.EqualTo(1));

    }
    
    // User Story 000 / 013
    [Test]
    void test_inputHandler(){
        InputHandler inp = new InputHandler();
        inp.TestInputs();

    }
    
    // User Story 00
    [Test]
    void test_CameraController(){
        CameraController cam = new CameraController();

        Assert.That(cam.GetPlayerTransform(), !(Is.EqualTo(null)));
        Assert.That(cam.GetTargetPosition(), !(Is.EqualTo(null)));
        Assert.That(cam.GetCameraStats(), !(Is.EqualTo(null)));
        

    }
    
    // User Story 00
    [Test]
    void test_PlayerController(){
        PlayerController play = new PlayerController();

        Assert.That(play.GetPlayerStats(), !(Is.EqualTo(null)));
        Assert.That(play.GetCharacterController(), !(Is.EqualTo(null)));
        Assert.That(play.GetCameraTransform(), !(Is.EqualTo(null)));

    }

    
    // Game Manager test
    // This tests existance of GameObjects necesary for game flow, the coroutines, and the handler functions
    // User Stories 003 / 008 / 011
	[Test]
    void test_GameManager(){
        
        GameManager game = new GameManager();

        Assert.IsNotNull(game);
        Assert.IsNotNull(game.playerController, "game.playerController");
        Assert.IsNotNull(game.gameState, "game.gameState");
    }
    

    // test enemy mode (2 constructors)
    // Movement Manager tests
    // theres no code for it yet




}
