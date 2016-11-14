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
	public float invulnerableTime = 0;

	public float originalSpeed = 10f;
	public float speed;
	public float speedUpTime = 0;

	int actualLevel = 1;
	int score = 0; 
	int totalHits = 0;
	int totalExtraLife = 0;

	public Slider healthbar;
	public Text lifesHUD;
	public Text levelHUD;
	public Text scoreHUD;

	public GameObject extraLifeAdvice;

	public GameObject gameOverPanel;
	public Text totalHitsHUD;
	public Text totalExtraLifesHUD;
	public Text rankHUD;

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

	void Update()
	{
		if (invulnerableTime > 0) 
		{
			invulnerableTime -= Time.deltaTime;
		} 
		else 
		{
			invulnerableTime = 0;
		}

		if (speedUpTime > 0) 
		{
			speedUpTime -= Time.deltaTime;
		} 
		else 
		{
			speed = originalSpeed;
			speedUpTime = 0;
		}
	}
		
	public void healDamage (int damageHealed)
	{
		int finalResult = actualHealth + damageHealed;

		if (finalResult > maxHealth) 
		{
			actualHealth = maxHealth;
		} 
		else 
		{
			actualHealth += damageHealed;
		}

		updateHUD ();
	}

	public void sufferDamage (int damage) 
	{
		if (invulnerableTime <= 0) 
		{
			totalHits++;
			actualHealth -= damage;
			invulnerableTime += 1f;
			speedUpTime = 0f;

			updateHUD ();
		}
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

		invulnerableTime = 0;
		speedUpTime = 0;
		changeScore(5);

		updateHUD();
	}

	public void changeScore(int value)
	{
		int finalResult = score + value;

		if (finalResult < 0) {
			score = 0;
		} 
		else 
		{
			score = finalResult;
		}

		updateHUD ();
	}
		
	void updateHUD () 
	{
		if (lifes <= 0) 
		{
			string rank = "beginner";

			if (score >= 150) 
			{
				rank = "ruin runner";
			} 
			else if (score >= 100) 
			{
				rank = "adventurer";
			}
			else if (score >= 50) 
			{
				rank = "ranger";
			}
			else if (score >= 20) 
			{
				rank = "scout";
			}
			else if (score >= 10) 
			{
				rank = "apprentice";
			}

			actualHealth = 0;
			totalHitsHUD.text = "Total Hits: " + totalHits.ToString ();
			totalExtraLifesHUD.text = "Extra Lifes Gained: " + totalExtraLife.ToString ();
			rankHUD.text = "GAME OVER! Good hunt, " + rank + "!";

			Destroy (mapGenerator.gameObject);
			gameOverPanel.SetActive (true);
		}

		healthbar.value = actualHealth;
		lifesHUD.text = "x " + lifes;
		levelHUD.text = "Level: " + actualLevel;
		scoreHUD.text = "Score: " + score.ToString("0000");
	}
}