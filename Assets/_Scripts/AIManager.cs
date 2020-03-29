using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using static MovementController;
using static ModeController;


public class AIManager : MonoBehaviour
{
  
  // todo: fighting
  // todo: enemy health
  // todo: enemy death
  // NOTE: these gameobjects need to be added via unity console
    public GameObject meleePrefab;
    public GameObject midPrefab;
    public GameObject longPrefab;
    public Transform playerpos;
    /////////////////////////////////////
    public int overallStyle;
    public int [] damageCount;
    ArrayList stupidList;
    ArrayList smartList;
    GameObject [] spawners;
    // tracks if game is still active
    public bool isAlive, killed;

    // FightStyles: 0: short, 1: mid, 2: long

    // Start is called before the first frame update
    void Start()
    {
        overallStyle = 1;
        // damage on everything set to 0 to begin
        damageCount = new int[] { 0,0,0};
        spawners = new GameObject[5]
        {GameObject.Find("spawner0"), GameObject.Find("spawner1"), GameObject.Find("spawner2"), GameObject.Find("spawner3"), GameObject.Find("spawner4")}; 
        // game is inactive. gm must make AI manager active
        killed = true;
        isAlive = false;
        stupidList = new ArrayList();
        smartList = new ArrayList();
    }

    // Update is called once per frame
    void Update()
    {
        //setLive();
        //if gm kills the wave
        if(!isAlive && !killed){
            // kill the game
            killWave();
        }

        // if gm is reviving wave
        if(killed && isAlive){
            // call make method
            reviveWave();
            // make sure to set kill to false
        }
        
        // if currently alive
        if(isAlive){
            int bestStyle = checkDamage();
            if (bestStyle != overallStyle){
            // change smart AI's
            overallStyle = bestStyle;
            changeAllStyles(overallStyle);
            // whichever damage vount has the most is new overallStyle;
            
            }
            // moves AI's
            moveField();
            
        }

    }

    // for game manager
    public void setLive(){
        isAlive = true;
    }

    // for game manager
    public void setDead(){
        isAlive = false;
        killed = true;
    }

    public void incrementDamage(int fightType){
        if(fightType > 2 || fightType < 0){
            Debug.Log("invalid index! styles are 0-2");
            return;
        }
        
        damageCount[fightType]++;
    }

 
    // kills wave
    // todo: destroy movers, test function
    private void killWave(){
        // destroy all current enemies
        foreach(stupidAI go in stupidList)
        {
         Destroy(go);
        }
        stupidList.Clear();
        
        foreach(smartAI go in smartList)
        {
         Destroy(go);
        }
        smartList.Clear();
    }

    
    // restarts wave
    private void reviveWave(){
        // respawn all enemies
        // currently there are five enemies to spawn at fiver different spawn points
        // todo: fix melee issue
    
        for(int i = 0; i < 5; i++){
            // max of range is excluded
            int fightrange = Random.Range(0, 3);
            int smartrange = fightrange;
            GameObject myPrefab, smartPrefab;
            switch (fightrange)
            {
            case 0:
                myPrefab = meleePrefab;
                smartrange = 1;
                smartPrefab = midPrefab;
                break;
            case 1:
                myPrefab = midPrefab;
                smartPrefab = midPrefab;
                break;
            case 2:
                myPrefab = midPrefab;
                smartPrefab = midPrefab;
                break;
            default:
                myPrefab = midPrefab;
                smartPrefab = midPrefab;
                break;
            }
            stupidAI shortR = new stupidAI(fightrange, myPrefab, spawners[Random.Range(0, 5)].GetComponent<Transform>());
            stupidList.Add(shortR);
            smartAI smartie = new smartAI(smartrange, smartPrefab, spawners[Random.Range(0, 5)].GetComponent<Transform>());
            smartList.Add(smartie);
        }


        // reset damagecount
        for(int i = 0; i < 3; i++){
            damageCount[i] = 0;
        }
        // reset overallStyle
        overallStyle = 1;
        // resets state
        killed = false;
    }

    // checks index of max AI damage
    private int checkDamage(){
        
        int maxVal = damageCount.Max();
        int maxIndex = damageCount.ToList().IndexOf(maxVal);
        return maxIndex;
    }

    // todo - change smart AI's style
    
    private void changeAllStyles(int curStyle){
        // change styles of all current smart AI's
        foreach(smartAI go in smartList)
        {
          go.setStyle(curStyle);
        }
    }
    
    // tells AI's from certain distance from player to move

    private void moveField(){
        foreach(stupidAI go in stupidList)
        {
            float minMoveDistance = 20.0f;
            float distance = Vector3.Distance(go.enemy.GetComponent<Transform>().position, playerpos.position);
            //Debug.Log("distance is" + distance);
            if (distance < minMoveDistance)
            {
                go.closeEnough = true;
            }
            else{
                go.closeEnough = false;
            }
            if(go.closeEnough){
                
                go.mover.moveToPlayer();
            }
            
        }
      
        foreach(smartAI go in smartList)
        {
            
            float minMoveDistance = 20.0f;
            float distance = Vector3.Distance(go.enemy.GetComponent<Transform>().position, playerpos.position);
            //Debug.Log("distance is" + distance);
            if (distance < minMoveDistance)
            {
                go.closeEnough = true;
            }
            else{
                go.closeEnough = false;
            }
            if(go.closeEnough){
                
                go.mover.moveToPlayer();
            }
            
        }
    }
}


// stupid AI's are meant to be more like cannon fodder, not super in depth code
// the fightStyle will not change, thus is private and should not be edited 
// within the class
// they spawn certain model based on type
public class stupidAI : MonoBehaviour
{
    protected int curStyle;
    public GameObject enemy;
    protected int id;
    protected UnityEngine.AI.NavMeshAgent agent;
    public MovementController mover;
    //-----ADDED BY GUS
    public AIAnimationController animations;
    //-----
    public bool closeEnough;
    public int health;

    public stupidAI(int style, GameObject myPrefab, Transform spawnLocation){
        closeEnough = false;
        // Instantiate at position (0, 0, 0) and zero rotation.
        enemy = Instantiate(myPrefab, spawnLocation.position, Quaternion.identity);
        agent = enemy.AddComponent(typeof(UnityEngine.AI.NavMeshAgent)) as UnityEngine.AI.NavMeshAgent;
        curStyle = style;
         switch (curStyle)
        {
            case 0:
                agent.stoppingDistance = 4.0F;
                break;
            case 1:
                agent.stoppingDistance = 7.0F;
                break;
            case 2:
                agent.stoppingDistance = 12.0F;
                break;
            default:
                agent.stoppingDistance = 7.0F;
                curStyle = 1;
                break;
        }
        //-----ADDED BY GUS
        animations = enemy.GetComponent<AIAnimationController>();
        animations.Initialize(agent);
        //-----
        mover = new MovementController(agent);
        health = 3;
       
    } 
    // default is mid if not specified
    public stupidAI(GameObject myPrefab, Transform spawnLocation){
        // Instantiate at position (0, 0, 0) and zero rotation.
        closeEnough = false;
        enemy = Instantiate(myPrefab, spawnLocation.position, Quaternion.identity);
        agent = enemy.AddComponent(typeof(UnityEngine.AI.NavMeshAgent)) as UnityEngine.AI.NavMeshAgent;
        agent.stoppingDistance = 7.0F;
        curStyle = 1;
        //-----ADDED BY GUS
        animations = enemy.GetComponent<AIAnimationController>();
        animations.Initialize(agent);
        //-----
        mover = new MovementController(agent);
        health = 3;
    } 

    // for smart AI only
    protected stupidAI(){
        closeEnough = false;
        health = 3;
    }

    public int getStyle(){
        return curStyle;
    }


}

// todo: smart ai
// smart AI's are supposed to be the adaptive versions of the enemy
// spawn initial model but can change type

public class smartAI : stupidAI
{
    public smartAI(int style, GameObject myPrefab, Transform spawnLocation){
      
        // Instantiate at position (0, 0, 0) and zero rotation.
        enemy = Instantiate(myPrefab, spawnLocation.position, Quaternion.identity);
        agent = enemy.AddComponent(typeof(UnityEngine.AI.NavMeshAgent)) as UnityEngine.AI.NavMeshAgent;
        curStyle = style;
         switch (curStyle)
        {
            case 0:
                agent.stoppingDistance = 4.0F;
                break;
            case 1:
                agent.stoppingDistance = 7.0F;
                break;
            case 2:
                agent.stoppingDistance = 12.0F;
                break;
            default:
                agent.stoppingDistance = 7.0F;
                curStyle = 1;
                break;
        }
        //-----ADDED BY GUS
        animations = enemy.GetComponent<AIAnimationController>();
        animations.Initialize(agent);
        //-----
        mover = new MovementController(agent);
    }

     public smartAI(GameObject myPrefab, Transform spawnLocation){
        // Instantiate at position (0, 0, 0) and zero rotation.
        enemy = Instantiate(myPrefab, spawnLocation.position, Quaternion.identity);
        agent = enemy.AddComponent(typeof(UnityEngine.AI.NavMeshAgent)) as UnityEngine.AI.NavMeshAgent;
        agent.stoppingDistance = 7.0F;
        curStyle = 1;
        //-----ADDED BY GUS
        animations = enemy.GetComponent<AIAnimationController>();
        animations.Initialize(agent);
        //-----
        mover = new MovementController(agent);
    } 

    public void setStyle(int style){
        curStyle = style;
        switch (curStyle)
        {
            case 0:
                agent.stoppingDistance = 3.0F;
                break;
            case 1:
                agent.stoppingDistance = 7.0F;
                break;
            case 2:
                agent.stoppingDistance = 12.0F;
                break;
            default:
                agent.stoppingDistance = 7.0F;
                curStyle = 1;
                break;
        }
    }

}


