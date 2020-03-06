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
using static UIManager;

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
    public void test_stupidAI(){
       
        stupidAI stu = new stupidAI();
        Assert.That(stu.getStyle(), Is.EqualTo(1));
       
        stupidAI stu2 = new stupidAI(0);
        Assert.That(stu.getStyle(), Is.EqualTo(10));
       
        
    }
    // test smart AI (2 constructors, get/set)
    // User story 007/002
    [Test]
    public void test_smartAI(){

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
    public void test_enemyMode(){

        enemyMode enMode = new enemyMode();

        Assert.That(enMode.getMode(), Is.EqualTo(1));

    }
    
    // User Story 000 / 013
    [Test]
    public void test_inputHandler(){
        InputHandler inp = new InputHandler();
        inp.TestInputs();

    }
    
    // User Story 00
    [Test]
    public void test_CameraController(){
        CameraController cam = new CameraController();

        Assert.That(cam.GetPlayerTransform(), !(Is.EqualTo(null)));
        Assert.That(cam.GetTargetPosition(), !(Is.EqualTo(null)));
        Assert.That(cam.GetCameraStats(), !(Is.EqualTo(null)));
        

    }
    
    // User Story 00
    [Test]
    public void test_PlayerController(){
        PlayerController play = new PlayerController();

        Assert.That(play.GetPlayerStats(), !(Is.EqualTo(null)));
        Assert.That(play.GetCharacterController(), !(Is.EqualTo(null)));
        Assert.That(play.GetCameraTransform(), !(Is.EqualTo(null)));

    }

    
    // Game Manager test
    // User Stories 003 / 008 / 011
	[Test]
    public void test_GameManager(){
        
        GameManager game = new GameManager();
        
        Assert.IsNotNull(game);
        Assert.IsNotNull(game.player, "game.player");
        Assert.IsNotNull(GameManager.gameState, "game.gameState");
        Assert.IsNotNull(GameManager.UI_Man, "game.UI_Man");
        Assert.IsNotNull(game.pStats, "game.pStats");

    }
    
    // UI Manager test
    // User Stories 005 / 008 / 011
    [Test]
    public void test_UIManager(){
        
        UIManager game = new UIManager();

        Assert.IsNotNull(game);
        Assert.IsNotNull(game.gameMenu, "game.gameMenu");
        Assert.IsNotNull(game.playerUI, "game.playerUI");
        Assert.IsNotNull(game.healthBar, "game.healthBar");
    }
    

    // test enemy mode (2 constructors)
    // Movement Manager tests
    // theres no code for it yet




}
