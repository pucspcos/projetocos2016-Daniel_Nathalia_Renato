/**
 * Created by Mario Madureira Fontes
 * Edited by Daniel Haruo Tamura
 * Procedural Game Jam 2015
 */
using UnityEngine;
using System.Collections;
using Utils.Map;

public class Treasure : PlaceBehaviour {
	ModdedGameManager moddedGameManager = null;
	MapGenerator mapGenerator = null;

	void Start () {
		moddedGameManager = FindObjectOfType<ModdedGameManager> ();
		mapGenerator = FindObjectOfType<MapGenerator> ();
	}

	IEnumerator OnTriggerEnter2D(Collider2D colisor) {
		if (colisor.gameObject.tag.ToString() == "Player") {
			yield return StartCoroutine (moddedGameManager.incrementLevel ());
			yield return StartCoroutine (mapGenerator.GenerateMap ());
		}
	}
}