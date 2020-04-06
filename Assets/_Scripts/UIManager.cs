using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	public GameObject gameOverMenu;
	public GameObject mainMenu;
	public GameObject playerUI;
	public Slider healthBar;
	public Text scoreText;
	public Text waveText;
	public Text enemyText;
	public Text weaponText;
	public Text fscoreText;
	public Text fwaveText;

	private void Start()
	{
		if(gameOverMenu == null)
			gameOverMenu = GameObject.Find("Game Over Menu");
		if(mainMenu == null)
			mainMenu = GameObject.Find("Main Menu");
		if(playerUI == null)
			playerUI = GameObject.Find("Player UI");
		if(healthBar == null)
			healthBar = GameObject.Find("Health Bar").GetComponent<Slider>();
	}

	public void showMenu(GameObject menu)
	{
		menu.SetActive(true);
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

	public void updateEnemyCount(int count)
	{
		enemyText.text = "Enemies Remaining: " + count;
		return;
	}

	public void updateWeaponText(Gun activeGun)
	{
		if(activeGun == null){
			Debug.Log("No gun found!");
			return;
		}
		string gunID = activeGun.name;
		if(gunID.Equals("AK74"))
			weaponText.text = "mid range:\n" + "AK74";
		if(gunID.Equals("M107"))
			weaponText.text = "long range:\n" + "M107";
		if(gunID.Equals("Bennelli_M4"))
			weaponText.text = "shoty range:\n" + "Bennelli M4";
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