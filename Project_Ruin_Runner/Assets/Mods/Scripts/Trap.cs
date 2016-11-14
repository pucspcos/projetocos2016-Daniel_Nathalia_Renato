/**
 * Created by Daniel Haruo Tamura
 */
using UnityEngine;

public class Trap : MonoBehaviour {
	ModdedGameManager moddedGameManager = null;

	Animator trapAnimator;

	public bool isAtivada = false;
	public int damage = 50;

	void Start () 
	{
		moddedGameManager = FindObjectOfType<ModdedGameManager> ();

		trapAnimator = this.gameObject.GetComponent<Animator> ();
		trapAnimator.SetBool("active", false);
		trapAnimator.SetBool("decoy", false);
	}

	void OnTriggerEnter2D(Collider2D colisor) 
	{
		if (colisor.gameObject.tag.ToString() == "Player" && !isAtivada) 
		{
			isAtivada = true;

			if (Random.Range(0, 101) > 50)
			{
				moddedGameManager.sufferDamage (damage);
				trapAnimator.SetBool ("active", true);
			} 
			else
			{
				trapAnimator.SetBool("decoy", true);
			}
		}
	}
}
