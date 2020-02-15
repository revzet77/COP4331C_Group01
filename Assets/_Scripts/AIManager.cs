using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour
{
    enum FightStyle
    {
        Long = 0,
        Mid = 1,
        Short = 2
    }

    // stupid AI's are meant to be more like cannon fodder, not super in depth code
    // the fightStyle will not change, thus is private and should not be edited 
    // within the class
    protected class stupidAI
    {
        private int curStyle;

        public stupidAI(int style){
            curStyle = style;
        } 
        // default is mid if not specified
        public stupidAI(){
            curStyle = 1;
        } 

        public int getStyle(){
            return curStyle;
        }
    }

    // smart AI's are supposed to be the adaptive versions of the enemy
    protected class smartAI
    {
        int curStyle;

        public smartAI(int style){
            curStyle = style;
        } 
        // default is mid if not specified
        public smartAI(){
            curStyle = 1;
        } 

        public int getStyle(){
            return curStyle;
        }

        public void setStyle(int style){
            curStyle = style;
        }
    }

    public int curStyle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
