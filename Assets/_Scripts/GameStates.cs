using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameStates : MonoBehaviour
{
	public bool isPlayerDead = false;
	public bool isGameOver = false;
	public bool isWaveOver = false;
	public bool finishedAllWaves = false;
	public int maxWaves = 5;
	public int waveNumber;
	public int score;

	public void resetGameStats()
	{
		isPlayerDead = false;
		isGameOver = false;
		isWaveOver = false;
		waveNumber = 0;
		score = 0;
		return;
	}

	// TODO: switch bool values to functions in GameManager
	// TODO: get PlayerStats passed into here
	/*
	public bool isPlayerDead(PlayerStats stats)
	{
		if(stats.health <= 0)
			return true;
		else
			return false;
	}

	public bool finishedAllWaves()
	{
		if(waveNumber > maxWaves)
			return true;
		else
			return false;
	}

	public bool isGameOver()
	{
		if(isPlayerDead() || finishedAllWaves())
			return true;
		else
			return false;
	}
	*/
}