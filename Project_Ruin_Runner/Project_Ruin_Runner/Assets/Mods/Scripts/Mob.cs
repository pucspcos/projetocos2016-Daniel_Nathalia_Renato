/**
 * Created by Mario Madureira Fontes
 * Edited by Daniel Haruo Tamura
 * Procedural Game Jam 2015
 */
using UnityEngine;
using System.Collections;

public class Mob : MonoBehaviour
{	
	ModdedGameManager moddedGameManager;

	public Rigidbody2D mobRdb;

	public Vector2 moveDirection = Vector2.right;
	public float timeRefresh = 1.0f;
   
    public int damage = 25;

	void Start()
	{
		moddedGameManager = FindObjectOfType<ModdedGameManager>();

		mobRdb = this.gameObject.GetComponent<Rigidbody2D> ();

		InvokeRepeating("mover", timeRefresh, timeRefresh);
	}

    void mover()
	{
		mobRdb.AddForce(moveDirection, ForceMode2D.Impulse);
    }

	void OnTriggerEnter2D(Collider2D colisor)
	{
		if (colisor.gameObject.tag.ToString() == "Player")
		{
			moddedGameManager.sufferDamage (damage);
		}
	}
}
