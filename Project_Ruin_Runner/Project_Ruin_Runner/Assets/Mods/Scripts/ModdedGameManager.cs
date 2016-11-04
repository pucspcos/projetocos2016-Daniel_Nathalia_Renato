/**
 * Created by Mario Madureira Fontes 
 * Procedural Game Jam 2015
 */
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Utils.Map;

public class ModdedGameManager : MonoBehaviour {
	private MapGenerator mapGen;

	public int lifes = 3;
	public int extraLifeLevels = 5;
	public int maxHealth = 100;
	public int actualHealth = 0;

	public Slider healthbar;
	public Text lifesHUD;
	public Text levelHUD;

	public Text TotalHitsGUI;
	public Text TotalLifesGainedGUI;
	public GameObject GameOverGUI;
	public GameObject ExtraLifeGUI;

	private int countLevels = 1;
	private int countHits = 0;
	private int countLifeGained = 0;

	void Start () {
		mapGen = FindObjectOfType<MapGenerator> ();

		actualHealth = maxHealth;

		healthbar.minValue = 0;
		healthbar.maxValue = maxHealth;

		if(GameOverGUI !=null) GameOverGUI.SetActive (false);
		if (ExtraLifeGUI != null) ExtraLifeGUI.SetActive(false);

		UpdateMenuGUI ();
	}
		
	public IEnumerator IncrementLevels () {
		countLevels++;

		if (countLevels % extraLifeLevels == 0) {
			ExtraLifeGUI.SetActive(true);
			yield return new WaitForSeconds(1.0f);
			lifes++;
			countLifeGained++;
			ExtraLifeGUI.SetActive(false);
		}

		UpdateMenuGUI();
	}

	public void IncrementHits()
	{
		countHits++;
	}

	public void sufferDamage (int damage) 
	{
		countHits++;
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

			if(mapGen !=null) Destroy(mapGen.gameObject);
			if(TotalHitsGUI !=null) TotalHitsGUI.text += countHits;
			if(TotalLifesGainedGUI !=null) TotalLifesGainedGUI.text += countLifeGained;
			if(GameOverGUI !=null) GameOverGUI.SetActive(true);
		} 

		healthbar.value = actualHealth;
		lifesHUD.text = "x " + lifes;
		levelHUD.text = "Level: " + countLevels;
	}
}