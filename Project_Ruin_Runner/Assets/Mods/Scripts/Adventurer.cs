using UnityEngine;
using System.Collections;

public class Adventurer : MonoBehaviour {
	private GameManager gameManager;

	private Vector3 originalPosition = Vector3.zero;

	public int maxHealth = 100;
	private int actualHealth = 0;

	void Start () {
		gameManager = FindObjectOfType<GameManager> ();

		originalPosition = transform.parent.position;

		actualHealth = maxHealth;
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
		}
	}
}
