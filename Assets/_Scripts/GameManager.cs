using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gameInstance;
    public static GameStates gameState;
    public static UIManager UI_Man;
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
        if(player == null) Debug.Log("No way Jose!");

        Debug.Log("The Game has initiated");

        m_StartWait = new WaitForSeconds(1F);
        m_EndWait = new WaitForSeconds(1f);

        // Comment this out + set Main Menu to active to test functionality
        StartGame();
    }

    public void StartGame()
    {
        StartCoroutine(GameLoop());
    }

    public IEnumerator GameLoop()
    {
        // TODO: Refrernce Game State if valid
        gameState.resetGame();
        pStats.currentHealth = pStats.maxHealth;
        // Spawn location of player at beginning of the game
        player.transform.position = new Vector3(-43,0,-97);
        
        while(!gameState.isGameOver(pStats))
        {
        	Debug.Log("The game Loop has started");
            yield return StartCoroutine(WaveStarting());
            Debug.Log("Still in the game loop, but WaveStart is done");
            yield return StartCoroutine(WavePlaying());
            Debug.Log("Still in the game loop, but WavePlaying is done");
            yield return StartCoroutine(WaveEnding());
            Debug.Log("Still in the game loop, but WaveEnding is done");
        }
        yield return null;
    }


    public IEnumerator WaveStarting()
    {        
        // TODO: Spawn enemies here

        //spawnEnemies();
        gameState.waveNumber++;
        UI_Man.updateWaveNumber(gameState.waveNumber);

        Debug.Log("Playing the wave! Past the while loop");
        yield return m_StartWait;
    }


    private int i;   // Just for testing
 	public IEnumerator WavePlaying()
    {
        Debug.Log("Playing the wave! Before the while loop");
        // Keeps game running until player health is 0 or until all enemies defeated
        while(!gameState.isPlayerDead(pStats) && !gameState.isWaveOver())
        {
            // TODO: Update score and health when enemies get hit with bullets
            i++;
            if(i>=30) {
                gameState.score++;
                i=0;
            }
            // TODO: Update player's health in PlayerStats when hit
            // TODO: Track how many enemies alive still
            UI_Man.UpdateHealthBar(pStats.currentHealth);
            UI_Man.updateScore(gameState.score);
            
            yield return null;
        }
    }

    public IEnumerator WaveEnding()
    {
    	Debug.Log("Ending the wave!");
    	//if(gameState.isPlayerDead || gameState.finishedAllWaves
    	if(gameState.isGameOver(pStats))
        {
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
        UI_Man.showMenu();
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