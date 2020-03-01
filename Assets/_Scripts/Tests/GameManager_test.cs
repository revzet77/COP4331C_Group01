using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject startGameButton;
    public PlayerController playerController;
    public Text titleText;
    public Text gameOverText;
    public Text scoreText;
    public Text waveText;
    public float m_StartDelay = 1f;         
    public float m_EndDelay = 1f;           

    private WaitForSeconds m_StartWait;     
    private WaitForSeconds m_EndWait;
    
    //private static GameStates gameState;
    //private static GameManager gameInstance;
    
    public GameStates gameState;
    public GameManager gameInstance;
    
    //TODO: manager for enemies
    //private enemyManager[] activeEnemies;


    private void Start()
    {
		gameInstance = this;
        titleText.enabled = true;
        gameOverText.enabled = false;
        scoreText.enabled = false;
        waveText.enabled = false;
        startGameButton.SetActive(true);
        
        gameState = GetComponent<GameStates>();
        gameState.score = 0;
        gameState.waveNumber = 0;
        gameState.isPlayerDead = false;
        gameState.isGameOver = false;

        Debug.Log("The Game has initiated");

        m_StartWait = new WaitForSeconds(m_StartDelay);
        m_EndWait = new WaitForSeconds(m_EndDelay);

        // SceneManager.LoadScene("actual_level", LoadSceneMode.Single);
		// SceneManager.LoadScene("actual_level", LoadSceneMode.Additive);

        StartCoroutine(GameLoop());
    }


    public IEnumerator GameLoop()
    {
        // TODO: Refrernce Game State if valid
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
    }


    public IEnumerator WaveStarting()
    {
        titleText.enabled = false;
        startGameButton.SetActive(false);

        // TODO: Pick starting position of player
        //player.transform.position = new Vector3(0, -3.22f, 0);
        //player.transform.eulerAngles = new Vector3(90, 180, 0);

        scoreText.text = "Score: " + gameState.score;
        waveText.text = "Wave: " + gameState.waveNumber;
        scoreText.enabled = true;
        waveText.enabled = true;
        
        // TODO: health restore function for player
        //player.GetComponent<PlayerController>().RestoreHealth();
        
        gameOverText.enabled = false;
        spawnRobots();
        spawnPowerups();

        //DisablePlayerControl();
        Debug.Log("In the wave! waveNumber = " + gameState.waveNumber);
        
        gameState.waveNumber++;
        
        Debug.Log("In the wave! waveNumber = " + gameState.waveNumber);
        
        yield return m_StartWait;
    }


 	public IEnumerator WavePlaying()
    {
        //EnablePlayerControl();
        
        Debug.Log("Playing the wave! Before the while loop");
        int i = 0;
        // TODO: add robot manager class so 2nd condition can be met
        // Keeps game running until player health is 0 or until all enemies defeated
        while(!gameState.isPlayerDead && !gameState.isWaveOver)
        {
            Debug.Log("In the while loop, pray for me. iteration number is = " + i);
            i++;
            // TODO: UPDATE SCORE!
            yield return null;
            Debug.Log("In the while loop, pray for me 2. iteration number is = " + i);
        }
        Debug.Log("Playing the wave! Past the while loop");
        
    }

    public IEnumerator WaveEnding()
    {
    	Debug.Log("Ending the wave! pt 1");
    	if(gameState.isPlayerDead || gameState.finishedAllWaves)
    	{
            GameOver();
            yield break;
        }
        Debug.Log("Ending the wave! pt 2");
        gameState.isWaveOver = false;
        yield return m_EndWait;
    }
    
    public static void GameOver()
    {
        //DisablePlayerControl();
        Debug.Log("Game is over!");
        //gameInstance.titleText.enabled = true;
        //gameInstance.startGameButton.SetActive(true);
        //gameState.isGameOver = true;
        //gameInstance.spawner.StopSpawning();
        //gameInstance.gameOverText.enabled = true;

    }

    public void spawnRobots()
    {
        
    }

    public void destroyActiveEnemies()
    {

    }

    public void spawnPowerups()
    {

    }

    public void EnablePlayerControl()
    {

    }

    public void DisablePlayerControl()
    {

    }

}