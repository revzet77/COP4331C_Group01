using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	public GameObject gameMenu;
	public Slider healthBar;                        
    
	private void Start()
	{
		if(gameMenu == null)
			gameMenu = GameObject.Find("Game Over Menu");
		if(healthBar == null)
			healthBar = GameObject.Find("Health Bar").GetComponent<Slider>();
	}

	public void showMenu()
	{
		gameMenu.SetActive(true);
	}

	public void hideMenu()
	{
		gameMenu.SetActive(false);
	}

	public void UpdateHealthBar(float currentHealth)
	{
		healthBar.value = currentHealth;
	}
}