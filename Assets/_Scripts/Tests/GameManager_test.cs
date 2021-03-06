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

        UI_Man.showMenu(UI_Man.mainMenu);
    }

    public void StartGame()
    {
        StartCoroutine(GameLoop());
    }

    public IEnumerator GameLoop()
    {
        Debug.Log("The Game Loop has started");
        
        gameState.resetGame();
        pStats.currentHealth = pStats.maxHealth;
        
        while(!gameState.isGameOver(pStats))
        {
            Debug.Log("While loop started, entering WaveStarting");
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
        Debug.Log("In WavePlaying coroutine!");
        
        // Keeps game running until player health is 0 OR until all enemies are defeated
        // TODO: check how many enemies are left using gameState.isWavOver() function or some
        // function from AI_Manager that can return a boolean here
        while(!gameState.isPlayerDead(pStats) && !gameState.isWaveOver())
        {
            /* TODO: 
                - Update score and health when enemies get hit with bullets
                - Update player's health in PlayerStats when hit
                - Track how many enemies alive still
            */
            UI_Man.UpdateHealthBar(pStats.currentHealth);
            UI_Man.updateScore(gameState.score);

            yield return null;
        }
        Debug.Log("In WavePlaying coroutine, AFTER while loop");
    }

    public IEnumerator WaveEnding()
    {
        Debug.Log("In WaveEnding coroutine");
        

        // If player died or player finished all the waves, sends to game over menu
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
        
        // TODO: AI_Manager function to destroy all active enemies


        UI_Man.showMenu(UI_Man.gameOverMenu);
        UI_Man.hidePlayerUI();
        UI_Man.DisplayFinalScores(gameState);
        return;
    }
    
}