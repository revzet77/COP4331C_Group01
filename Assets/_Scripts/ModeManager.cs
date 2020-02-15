using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// manages the mode for all current active enemies
public class ModeManager : MonoBehaviour
{
    enum AttackMode{
        Offense = 0,
        Defense = 1
    }

    protected class enemyMode(){

        int curMode;

        public enemyMode(){
            curMode = 1;
        }

        public enemyMode(int mode){
            curMode = mode;
        }
    }

}
