using UnityEngine;
using System.Collections;

public class Mob : MonoBehaviour {
	public GameObject prefabMob = null;

	public float timeRefreshFire = 1.0f;
	public Vector2 moveDirection = Vector2.right;

	public int damage = 25;

	void Start () 
	{
		InvokeRepeating ("mover", timeRefreshFire, timeRefreshFire);
	}

	public int Damage {
		get{ return damage; }
		set{ damage = value; }
	}

	void move () 
	{
		GameObject clonePrefab = Instantiate (prefabMob);
		Rigidbody2D cloneRdb = clonePrefab.GetComponent<Rigidbody2D> ();

		clonePrefab.transform.position = this.gameObject.transform.position;
		clonePrefab.transform.rotation = this.gameObject.transform.rotation;

		if (cloneRdb != null) {
			cloneRdb.AddForce (moveDirection, ForceMode2D.Impulse);
		}
	}
}
