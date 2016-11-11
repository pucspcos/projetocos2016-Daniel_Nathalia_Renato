/**
 * Created by Mario Madureira Fontes 
 * Procedural Game Jam 2015
 */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Utils.Map;

public class Treasure : PlaceBehaviour {
	ModdedGameManager gameManager = null;
	MapGenerator mapGenerator = null;
	//PlaceObjectMap placement = null;

	void Start () {
		gameManager = FindObjectOfType<ModdedGameManager> ();
		mapGenerator = FindObjectOfType<MapGenerator> ();
		//placement = FindObjectOfType<PlaceObjectMap> ();
	}

	IEnumerator OnTriggerEnter2D(Collider2D colisor) {
		if (colisor.gameObject.layer == 8) {
			yield return StartCoroutine (gameManager.IncrementLevel ());
			yield return StartCoroutine (mapGenerator.GenerateMap ());
			//placement.ApplyLevelAjustment();
		}
	}
}