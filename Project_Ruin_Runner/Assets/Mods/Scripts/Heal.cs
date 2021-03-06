﻿/**
 * Created by Daniel Haruo Tamura
 */
using UnityEngine;

public class Heal : MonoBehaviour {
	ModdedGameManager moddedGameManager = null;

	public int damageHealed = 50;

	void Start () 
	{
		moddedGameManager = FindObjectOfType<ModdedGameManager> ();
	}

	void OnTriggerEnter2D(Collider2D colisor) 
	{
		if (colisor.gameObject.tag.ToString() == "Player" && 
			moddedGameManager.actualHealth < moddedGameManager.maxHealth) 
		{
			moddedGameManager.healDamage (damageHealed);

			Destroy (this.gameObject);
		}
	}
}
