/**
 * Created by Daniel Haruo Tamura
 */
using UnityEngine;

public class Coin : MonoBehaviour {
	ModdedGameManager moddedGameManager = null;

	public int scoreValue = 5;

	void Start () 
	{
		moddedGameManager = FindObjectOfType<ModdedGameManager> ();
	}

	void OnTriggerEnter2D(Collider2D colisor) 
	{
		if (colisor.gameObject.tag.ToString() == "Player") 
		{
			moddedGameManager.changeScore(scoreValue);

			Destroy (this.gameObject);
		}
	}
}
