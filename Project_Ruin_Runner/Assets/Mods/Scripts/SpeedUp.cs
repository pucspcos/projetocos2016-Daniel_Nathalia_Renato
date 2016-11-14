/**
 * Created by Daniel Haruo Tamura
 */
using UnityEngine;

public class SpeedUp : MonoBehaviour {
	ModdedGameManager moddedGameManager = null;

	public float speedUpBoost = 15f;
	public float speedUpTimeBonus = 6f;
	public int scoreValue = 1;

	void Start () 
	{
		moddedGameManager = FindObjectOfType<ModdedGameManager> ();
	}

	void OnTriggerEnter2D(Collider2D colisor) 
	{
		if (colisor.gameObject.tag.ToString() == "Player") 
		{
			moddedGameManager.invulnerableTime = 0;
			moddedGameManager.speed = speedUpBoost;
			moddedGameManager.speedUpTime += speedUpTimeBonus;
			moddedGameManager.changeScore (scoreValue);

			Destroy (this.gameObject);
		}
	}
}
