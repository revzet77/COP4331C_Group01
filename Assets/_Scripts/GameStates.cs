using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameStates : MonoBehaviour
{
	public bool isPlayerDead = false;
	public bool isGameOver = false;
	public bool isWaveOver = false;
	public bool finishedAllWaves = false;
	public int waveNumber = 0;
	public int maxWaves = 5;
	public int score = 0;
}