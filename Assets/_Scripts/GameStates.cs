using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameStates : MonoBehaviour
{
	//public bool isPlayerDead = false;
	//public bool isGameOver = false;
	//public bool finishedAllWaves = false;
	public bool WaveOver = false;
	public int maxWaves = 5;
	public int waveNumber;
	public int score;
	

	public bool isPlayerDead(PlayerStats stats)
	{
		if(stats.currentHealth <= 0)
			return true;
		else
			return false;
	}

	public bool isWaveOver(int enemyCount)
	{ // TODO: check how  many enemies are alive
		if(enemyCount > 0 && !WaveOver) return false;
		else
		{
			WaveOver = false;
			return true;
		}
	}

	public bool finishedAllWaves()
	{
		if(waveNumber >= maxWaves)
			return true;
		else
			return false;
	}

	// TODO: Make winning state/cond, with winning UI Text in Game Over Menu
	public bool isGameOver(PlayerStats stats)
	{
		if(!isPlayerDead(stats) && !finishedAllWaves())
			return false;
		else
			return true;
	}

	public void resetGame()
	{
		//isPlayerDead = false;
		//isGameOver = false;
		//isWaveOver = false;
		waveNumber = 0;
		score = 0;
		return;
	}
}