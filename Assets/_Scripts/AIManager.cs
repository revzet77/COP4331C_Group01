using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using static MovementController;
using static Enemyid;
using static ModeController;


public class AIManager : MonoBehaviour
{

  // NOTE: these gameobjects need to be added via unity console
    public GameObject meleePrefab;
    public GameObject midPrefab;
    public GameObject longPrefab;
    public Transform playerpos;
    public GameObject currentenemy;
    /////////////////////////////////////
    public int overallStyle;
    public int [] damageCount;
    public ArrayList stupidList;
    public ArrayList smartList;
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
        removeDead();
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
            
            //attack
            checkAttack();
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
    
    //.... by Wallace
    public int enemyCount(){
        int count = stupidList.Count + smartList.Count;
        return count;
    }
    //....

 
    // kills wave
    // todo: destroy movers, test function
    private void killWave(){
        // destroy all current enemies
        foreach(stupidAI go in stupidList)
        {
         Destroy(go.enemy);
        }
        stupidList.Clear();
        
        foreach(smartAI go in smartList)
        {
         Destroy(go.enemy);
        }
        smartList.Clear();
    }

    
    // restarts wave
    private void reviveWave(){
        // respawn all enemies
        // currently there are five enemies to spawn at fiver different spawn points
        // stretch goal: fix longprefab
    
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
            stupidAI shortR = new stupidAI(fightrange, myPrefab, spawners[Random.Range(0, 5)].GetComponent<Transform>(), i);
            stupidList.Add(shortR);
            smartAI smartie = new smartAI(smartrange, smartPrefab, spawners[Random.Range(0, 5)].GetComponent<Transform>(), i + 5);
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

    // todo: fix gameobject, currently wont pass right one. As of now it will only kill enemy with id 0
    public void recieveDamage(int damageType, GameObject enem){
        Debug.Log("entering recieveDamage");
        currentenemy = enem;
        int id = 0;
        //testing gameobject
        
        // increment damage counter
        if(enem == null){
            Debug.Log("entering recieveDamage, enem is null");
            
        }
        else{
            if(enem.GetComponent<Enemyid>() != null){
                id = enem.GetComponent<Enemyid>().Id;
                Debug.Log("id found. it is " + id);
            }
            else{
                Debug.Log("entering recieveDamage, Enemyid is null");
                
            }
        }
        
        
        
        if(damageType < 3 && damageType >= 0){
            damageCount[damageType]++;
        }
        else{
            Debug.Log("recieveDamage: damage types need to be in range 0-2!");
        }
        
        // match id to AI object, give damage
        foreach(stupidAI go in stupidList)
        {
           // Debug.Log(pos + " , " + go.enemy.GetInstanceID());
            if(go.enemy.GetComponent<Enemyid>().Id == id){
                Debug.Log("found AI");
                go.takeDamage();
            }
        }
          
        foreach(smartAI go in smartList)
        {
            //Debug.Log(pos + " , " + go.enemy.GetInstanceID());
            if(go.enemy.GetComponent<Enemyid>().Id == id){
                Debug.Log("found AI");
                go.takeDamage();
            }
        }
        
        
    }

    // for weapons
    public void damageAll(){

        foreach(stupidAI go in stupidList)
        {
            go.takeDamage();
        }

        
        foreach(smartAI go in smartList)
        {
            go.takeDamage();
        }
       

    }
 
    // removes any enemies who have been set to dead
    protected void removeDead(){

        foreach(stupidAI go in stupidList)
        {
            if(go.isDead){
                
                Destroy(go.enemy);
                go.enemy = null;
            }
        }

        
        foreach(smartAI go in smartList)
        {
            if(go.isDead){
                
                Destroy(go.enemy);
                go.enemy = null;
                
            }
        }

        for(int i = 0; i < stupidList.Count; i++){

        
                stupidAI temp = (stupidAI)stupidList[i];
                if(temp.enemy == null){
                    stupidList[i] = null;
                }


        }

        for(int i = 0; i < stupidList.Count; i++){

        
                smartAI temp = (smartAI)smartList[i];
                if(temp.enemy == null){
                    smartList[i] = null;
                }


        }

        stupidList.Remove(null);
        stupidList.Remove(null);
        stupidList.Remove(null);
        stupidList.Remove(null);
        stupidList.Remove(null);

        smartList.Remove(null);
        smartList.Remove(null);
        smartList.Remove(null);
        smartList.Remove(null);
        smartList.Remove(null);

    }

    public bool isNullstupid(stupidAI s){
        if (s == null){
            return true;
        }
        
        return false;
    }

    public bool isNullsmart(smartAI s){
        if (s == null){
            return true;
        }
        
        return false;
    }

  
    
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

    // if the enemy's path is completed, then attack
    
    private void checkAttack(){

        
        float minMoveDistance = 20.0f;
        foreach(stupidAI go in stupidList)
        {
            switch (go.getStyle())
            {
            case 0:
                minMoveDistance = 4.0F;
                break;
            case 1:
                minMoveDistance = 7.0F;
                break;
            case 2:
                minMoveDistance = 12.0F;
                break;
            default:
                minMoveDistance = 7.0F;
                
                break;
            }
            
            float distance = Vector3.Distance(go.enemy.GetComponent<Transform>().position, playerpos.position);
            //Debug.Log("distance is" + distance);
            if (distance < minMoveDistance)
            {
                if(Random.Range(0, 120) == 3){
                    Debug.Log("player would be hurt here.... IF I COULD HURT THEM");
                    // decrement play health
                    PlayerStats stats = GameObject.Find("PlayerController").GetComponent<PlayerStats>();
                    stats.currentHealth--;
                    // Gus - add animation here
                    go.attack();
                }
                 
            }

            
        }
      
        foreach(smartAI go in smartList)
        {
            
            switch (go.getStyle())
            {
            case 0:
                minMoveDistance = 4.0F;
                break;
            case 1:
                minMoveDistance = 7.0F;
                break;
            case 2:
                minMoveDistance = 12.0F;
                break;
            default:
                minMoveDistance = 7.0F;
                
                break;
            }
            
            float distance = Vector3.Distance(go.enemy.GetComponent<Transform>().position, playerpos.position);
            //Debug.Log("distance is" + distance);
            if (distance < minMoveDistance)
            {
                if(Random.Range(0, 120) == 3){
                    Debug.Log("player would be hurt here.... IF I COULD HURT THEM");
                    //  decrement player health
                    PlayerStats stats = GameObject.Find("PlayerController").GetComponent<PlayerStats>();
                    stats.currentHealth--;
                    // Gus - add animation here
                    go.attack();
                }
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
    
    public UnityEngine.AI.NavMeshAgent agent;
    public MovementController mover;
    //-----ADDED BY GUS
    public AIAnimationController animations;
    //-----
    public bool closeEnough;
    protected int health;
    public Enemyid id;
    public bool isDead;

    public stupidAI(int style, GameObject myPrefab, Transform spawnLocation, int idSet){
        //id = idSet;
        closeEnough = false;
        isDead = false;
        // Instantiate at position (0, 0, 0) and zero rotation.
        enemy = Instantiate(myPrefab, spawnLocation.position, Quaternion.identity);
        enemy.tag = "NPC";
        agent = enemy.AddComponent(typeof(UnityEngine.AI.NavMeshAgent)) as UnityEngine.AI.NavMeshAgent;
        agent.speed = 3;
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
        id = enemy.AddComponent(typeof(Enemyid)) as Enemyid;
        id.setID(idSet);
        health = 3;
       
    } 


    // for smart AI only
    protected stupidAI(){
        closeEnough = false;
        isDead = false;
        
    }

    // for gamemanager/weapons
    public int getStyle(){
        return curStyle;
    }

    // for gamemanager/weapons
    public int getHealth(){
        return health;
    }

    // for gamemanager/weapons
    public void takeDamage(){
        Debug.Log("Entering takeDamage");
        health = health - 1;
        if(health <= 0){
            die();
        }
        // --- ADDED BY GUS
        // Mayhaps an if statement for a threshold before animation set off to prevent too many animation events 
        animations.TakeDamage();
        // ----
    }

    // ----- ADDED BY GUS
    public void attack()
    {
        animations.Attack();
    }
    // -----


    // sets bool to dead, the next update() clears out dead AI's in removeDead()
    protected void die(){
        //---Added BY GUS
        animations.Die();
        //----
        isDead = true;
        Debug.Log("enemy died");
    }


}


// smart AI's are supposed to be the adaptive versions of the enemy
// spawn initial model but can change type

public class smartAI : stupidAI
{
    public smartAI(int style, GameObject myPrefab, Transform spawnLocation, int idSet){
        //id = idSet;
        // Instantiate at position (0, 0, 0) and zero rotation.
        enemy = Instantiate(myPrefab, spawnLocation.position, Quaternion.identity);
        enemy.tag = "NPC";
        agent = enemy.AddComponent(typeof(UnityEngine.AI.NavMeshAgent)) as UnityEngine.AI.NavMeshAgent;
        agent.speed = 3;
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
        id = enemy.AddComponent(typeof(Enemyid)) as Enemyid;
        id.setID(idSet);
        health = 5;
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


