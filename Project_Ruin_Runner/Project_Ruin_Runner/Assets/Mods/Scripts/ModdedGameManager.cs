/**
 * Created by Mario Madureira Fontes
 * Edited by Daniel Haruo Tamura
 * Procedural Game Jam 2015
 */
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Utils.Map;

public class ModdedGameManager : MonoBehaviour {
	private MapGenerator mapGenerator;

	public int lifes = 3;
	public int extraLifeLevelPeriod = 5;
	public int maxHealth = 100;
	public int actualHealth;

	public float originalSpeed = 10.0f;
	public float speed;

	private int actualLevel = 1;
	private int totalExtraLife = 0;
	private int totalHits = 0;

	public Slider healthbar;
	public Text lifesHUD;
	public Text levelHUD;

	public GameObject gameOverPanel;
	public Text totalExtraLifesHUD;
	public Text totalHitsHUD;
	public GameObject extraLifeAdvice;

	void Start () {
		mapGenerator = FindObjectOfType<MapGenerator> ();
		actualHealth = maxHealth;
		speed = originalSpeed;

		healthbar.minValue = 0;
		healthbar.maxValue = maxHealth;
		gameOverPanel.SetActive (false);
		extraLifeAdvice.SetActive (false);

		updateHUD ();
	}
		
	public void healDamage (int damageHealed)
	{
		actualHealth += damageHealed;
		updateHUD ();
	}

	public void sufferDamage (int damage) 
	{
		totalHits++;
		actualHealth -= damage;
		updateHUD ();
	}

	public void changeLifes (int value) 
	{
		lifes += value;
		updateHUD ();
	}

	public IEnumerator incrementLevel () {
		actualLevel++;

		if (actualLevel % extraLifeLevelPeriod == 0) 
		{
			lifes++;
			totalExtraLife++;

			extraLifeAdvice.SetActive(true);
			yield return new WaitForSeconds(1.0f);
			extraLifeAdvice.SetActive(false);
		}

		updateHUD();
	}
		
	void updateHUD () 
	{
		if (lifes <= 0) 
		{
			actualHealth = 0;

			Destroy (mapGenerator.gameObject);
			totalExtraLifesHUD.text = "Extra Lifes Gained: " + totalExtraLife.ToString ();
			totalHitsHUD.text = "Total Hits: " + totalHits.ToString ();

			gameOverPanel.SetActive (true);
		}

		healthbar.value = actualHealth;
		lifesHUD.text = "x " + lifes;
		levelHUD.text = "Level: " + actualLevel;
	}
}