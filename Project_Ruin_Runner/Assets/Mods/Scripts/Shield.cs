/**
 * Created by Daniel Haruo Tamura
 */
using UnityEngine;

public class Shield : MonoBehaviour {
	ModdedGameManager moddedGameManager = null;

	public float invulnerableTimeBonus = 6f;
	public int scoreValue = 1;

	void Start () 
	{
		moddedGameManager = FindObjectOfType<ModdedGameManager> ();
	}

	void OnTriggerEnter2D(Collider2D colisor) 
	{
		if (colisor.gameObject.tag.ToString() == "Player") 
		{
			moddedGameManager.invulnerableTime += invulnerableTimeBonus;
			moddedGameManager.speedUpTime = 0;
			moddedGameManager.changeScore (scoreValue);

			Destroy (this.gameObject);
		}
	}
}
