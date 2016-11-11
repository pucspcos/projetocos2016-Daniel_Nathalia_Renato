/**
 * Created by Mario Madureira Fontes 
 * Procedural Game Jam 2015
 */
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Utils.Map;

public class ModdedGameManager : MonoBehaviour {
	private MapGenerator mapGenerator;

	public int lifes = 3;
	public int extraLifeLevel = 5;
	public int maxHealth = 100;
	public int actualHealth;

	public Slider healthbar;
	public Text lifesHUD;
	public Text levelHUD;

	public Text totalHitsHUD;
	public Text totalExtraLifesHUD;
	public GameObject gameOverPanel;
	public GameObject extraLifeAdvice;

	private int actualLevel = 1;
	private int totalHits = 0;
	private int totalExtraLife = 0;

	void Start () {
		mapGenerator = FindObjectOfType<MapGenerator> ();

		actualHealth = maxHealth;

		healthbar.minValue = 0;
		healthbar.maxValue = maxHealth;

		if (gameOverPanel != null) {
			gameOverPanel.SetActive (false);
		}

		if (extraLifeAdvice != null) {
			extraLifeAdvice.SetActive (false);
		}

		UpdateMenuGUI ();
	}
		
	public IEnumerator IncrementLevel () {
		actualLevel++;

		if (actualLevel % extraLifeLevel == 0) {
			extraLifeAdvice.SetActive(true);

			lifes++;
			totalExtraLife++;

			yield return new WaitForSeconds(1.0f);

			extraLifeAdvice.SetActive(false);
		}

		UpdateMenuGUI();
	}

	public void IncrementHits()
	{
		totalHits++;
	}

	public void sufferDamage (int damage) 
	{
		totalHits++;
		actualHealth -= damage;
		UpdateMenuGUI ();
	}

	public void DecrementLife () 
	{
		lifes--;
		UpdateMenuGUI ();
	}

	void UpdateMenuGUI () {
		if (lifes <= 0) 
		{
			actualHealth = 0;

			if (mapGenerator != null) {
				Destroy (mapGenerator.gameObject);
			}

			if (totalHitsHUD != null) {
				totalHitsHUD.text = "Total Hits: " + totalHits.ToString();
			}

			if (totalExtraLifesHUD != null) {
				totalExtraLifesHUD.text = "Extra Lifes Gained: " + totalExtraLife.ToString();
			}

			if (gameOverPanel != null) {
				gameOverPanel.SetActive (true);
			}
		} 

		healthbar.value = actualHealth;
		lifesHUD.text = "x " + lifes;
		levelHUD.text = "Level: " + actualLevel;
	}
}