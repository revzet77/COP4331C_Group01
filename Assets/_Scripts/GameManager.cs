using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static PlayerController playerController;
    public static GameStates gameState;
    public static GameManager gameInstance;
    public static UIManager UI_Man;

    private WaitForSeconds m_StartWait;     
    private WaitForSeconds m_EndWait;
     
    //TODO: manager for enemies
    

    private void Start()
    {
		gameInstance = this;
        if(gameState == null)
            gameState = GetComponent<GameStates>();
        UI_Man = GetComponent<UIManager>();

        Debug.Log("The Game has initiated");

        m_StartWait = new WaitForSeconds(1F);
        m_EndWait = new WaitForSeconds(1f);

        StartGame();
    }

    public void StartGame()
    {
        StartCoroutine(GameLoop());
    }

    public IEnumerator GameLoop()
    {
        // TODO: Refrernce Game State if valid
        gameState.resetGameStats();
        while(!gameState.isGameOver)
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
        // TODO: Pick starting position of player
        
        spawnRobots();
        spawnPowerups();
        gameState.waveNumber++;
        
        Debug.Log("In the wave! waveNumber = " + gameState.waveNumber);
        
        yield return m_StartWait;
    }


 	public IEnumerator WavePlaying()
    {
        Debug.Log("Playing the wave! Before the while loop");

        // Keeps game running until player health is 0 or until all enemies defeated
        while(!gameState.isPlayerDead && !gameState.isWaveOver)
        {
            // TODO: Update score and score text UI
            // TODO: Update player health and health bar
            
            yield return null;
        }
        Debug.Log("Playing the wave! Past the while loop");
    }

    public IEnumerator WaveEnding()
    {
    	Debug.Log("Ending the wave!");
    	if(gameState.isPlayerDead || gameState.finishedAllWaves)
    	{
            GameOver();
            yield break;
        }
        gameState.isWaveOver = false;
        yield return m_EndWait;
    }
    
    public static void GameOver()
    {
        Debug.Log("Game is over!");
        gameState.isGameOver = true;
        UI_Man.showMenu();
        // TODO: pass final score to UI_Man
        return;
    }

    public void spawnRobots()
    {
        return;
    }

    public void destroyActiveEnemies()
    {
        return;
    }

    public void spawnPowerups()
    {
        return;
    }

}