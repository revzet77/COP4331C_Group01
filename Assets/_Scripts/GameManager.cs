using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gameInstance;
    public static GameStates gameState;
    public static UIManager UI_Man;
    public AIManager AI_manager;
    public PlayerController player;
    
    private PlayerStats pStats;
    private WaitForSeconds m_StartWait;     
    private WaitForSeconds m_EndWait;
     
    //TODO: manager for enemies
    

    private void Start()
    {
		gameInstance = this;
        gameState = GetComponent<GameStates>();
        UI_Man = gameInstance.GetComponent<UIManager>();
		pStats = player.GetComponent<PlayerStats>();
        
        Debug.Log("The Game has initiated");

        m_StartWait = new WaitForSeconds(1F);
        m_EndWait = new WaitForSeconds(1f);

        // Comment this out + set Main Menu to active to test functionality
        //StartGame();
        UI_Man.showMenu(UI_Man.mainMenu);
    }

    public void StartGame()
    {
        StartCoroutine(GameLoop());
    }

    public IEnumerator GameLoop()
    {
        Debug.Log("The game Loop has started");
        
        gameState.resetGame();
        pStats.currentHealth = pStats.maxHealth;
        
        while(!gameState.isGameOver(pStats))
        {
            Debug.Log("While loop started");
            yield return StartCoroutine(WaveStarting());
            Debug.Log("Still in while loop, entering WavePlaying");
            yield return StartCoroutine(WavePlaying());
            Debug.Log("Still in while loop, entering WaveEnding");
            yield return StartCoroutine(WaveEnding());
        }
        yield return null;
    }


    public IEnumerator WaveStarting()
    {        
        // TODO: Spawn enemies here

        //spawnEnemies();
        gameState.waveNumber++;
        UI_Man.updateWaveNumber(gameState.waveNumber);

        yield return m_StartWait;
    }


  	public IEnumerator WavePlaying()
    {
        Debug.Log("Playing the wave! Before the while loop");
        // Keeps game running until player health is 0 or until all enemies defeated
        while(!gameState.isPlayerDead(pStats) && !gameState.isWaveOver())
        {
            // TODO: Update score and health when enemies get hit with bullets
            // TODO: Update player's health in PlayerStats when hit
            // TODO: Track how many enemies alive still
            UI_Man.UpdateHealthBar(pStats.currentHealth);
            UI_Man.updateScore(gameState.score);

            yield return null;
        }
    }

    public IEnumerator WaveEnding()
    {
    	Debug.Log("entering WaveEnding coroutine");
    	//if(gameState.isPlayerDead || gameState.finishedAllWaves
    	if(gameState.isGameOver(pStats))
        {
            Debug.Log("Ending the wave!");
            GameOver();
            yield break;
        }
        //gameState.isWaveOver = false;
        yield return m_EndWait;
    }
    
    public static void GameOver()
    {
        Debug.Log("Game is over!");
        //gameState.isGameOver = true;
        gameInstance.destroyActiveEnemies();
        UI_Man.showMenu(UI_Man.gameOverMenu);
        UI_Man.hidePlayerUI();
        UI_Man.DisplayFinalScores(gameState);
        return;
    }

    public void spawnEnemies()
    {
        return;
    }

    // If player dies, destroys enemies still alive to clean up for next game
    public void destroyActiveEnemies()
    {
        return;
    }

}