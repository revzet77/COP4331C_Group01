using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static CameraController;
using static CameraStats;
using static InputHandler;
using static  PlayerController;
using static PlayerStats;
using static AIManager;
using static ModeManager;
using static MovementManager;

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
    // User story 007
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
    // User story 007
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
    // User story 007
    bool test_enemyMode(){

        enemyMode enMode = new enemyMode();

        if(enMode.getMode() == 1){
            return true;
        }

        return false;
    }
    // test enemy mode (2 constructors)
    // Movement Manager tests
    // theres no code for it yet

    // Start is called before the first frame update
    void Start()
    {
        
    }


}
