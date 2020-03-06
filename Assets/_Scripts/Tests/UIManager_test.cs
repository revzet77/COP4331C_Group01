using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	public GameObject gameMenu;
	public GameObject playerUI;
	public Slider healthBar;
	public Text scoreText;
	public Text waveText;
	public Text enemyText;
	public Text fscoreText;
	public Text fwaveText;

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
		waveText.text = "Wave: " + wave;
		return;
	}

	public void updateScore(int score)
	{
		scoreText.text = score.ToString();
		return;
	}

	public void DisplayFinalScores(GameStates g_state)
	{
		fscoreText.text = "Final Score: " + g_state.score;
		fwaveText.text = "Waves Played: " + g_state.waveNumber;
		return;
	}
}