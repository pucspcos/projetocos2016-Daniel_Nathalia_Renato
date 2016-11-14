/**
 * Created by Mario Madureira Fontes
 * Edited by Daniel Haruo Tamura
 * Procedural Game Jam 2015
 */
using UnityEngine;
using System.Collections;

public class Heal : MonoBehaviour {
	ModdedGameManager moddedGameManager = null;

	public int damageHealed = 50;

	void Start () 
	{
		moddedGameManager = FindObjectOfType<ModdedGameManager> ();
	}

	void OnTriggerEnter2D(Collider2D colisor) 
	{
		if (colisor.gameObject.tag.ToString() == "Player") 
		{
			moddedGameManager.healDamage (damageHealed);
		}
	}
}
