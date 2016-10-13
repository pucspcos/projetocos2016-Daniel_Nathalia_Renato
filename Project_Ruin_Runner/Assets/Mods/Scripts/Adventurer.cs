using UnityEngine;
using System.Collections;

public class Adventurer : MonoBehaviour {
	private GameManager gameManager;

	private Vector3 originalPosition = Vector3.zero;

	public int maxHealth = 100;
	private int actualHealth = 0;

	public ParticleSystem myEffects;

	void Start () {
		gameManager = FindObjectOfType<GameManager> ();

		originalPosition = transform.parent.position;

		actualHealth = maxHealth;

		if (myEffects != null) {
			myEffects = GetComponent<ParticleSystem> ();
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag.Equals ("Enemy")) {
			Mob touchedMob = other.GetComponent<Mob> ();

			actualHealth -= touchedMob.Damage;

			gameManager.IncrementHits();

			// Player died
			if(actualHealth <= 0) {
				transform.parent.position = originalPosition;

				actualHealth = maxHealth;

				if (gameManager != null) {
					gameManager.DecrementLife ();
				}
			}

			//if(myEffects !=null) myEffects.enableEmission = true;
		}
	}
}
