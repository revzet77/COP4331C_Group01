using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
	public GameObject gameMenu;
	public GameObject playerUI;
	public Slider healthBar;
	public TextMeshProUGUI scoreTMP;
	public TextMeshProUGUI waveTMP;
	public TextMeshProUGUI enemyTMP;
	public TextMeshProUGUI fscoreTMP;
	public TextMeshProUGUI fwaveTMP;

	
	private void Start()
	{
		if(gameMenu == null)
			gameMenu = GameObject.Find("Game Over Menu");
		if(playerUI == null)
			playerUI = GameObject.Find("Player UI");
		if(healthBar == null)
			healthBar = GameObject.Find("Health Bar").GetComponent<Slider>();
	}

	public void showMenu()
	{
		gameMenu.SetActive(true);
		return;
	}

	public void hidePlayerUI()
	{
		playerUI.SetActive(false);
		return;
	}

	public void UpdateHealthBar(float currentHealth)
	{
		healthBar.value = currentHealth;
		return;
	}

	public void updateWaveNumber(int wave)
	{
		waveTMP.text = "Wave: " + wave;
		return;
	}

	public void updateScore(int score)
	{
		scoreTMP.text = score.ToString();
		return;
	}

	public void DisplayFinalScores(GameStates g_state)
	{
		fscoreTMP.text = "Final Score: " + g_state.score;
		fwaveTMP.text = "Waves Played: " + g_state.waveNumber;
		return;
	}
}