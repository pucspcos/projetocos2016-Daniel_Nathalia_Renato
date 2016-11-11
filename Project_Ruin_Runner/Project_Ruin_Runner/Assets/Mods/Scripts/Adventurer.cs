using UnityEngine;
using System.Collections;

public class Adventurer : MonoBehaviour
{
    ModdedGameManager gameManager;
	private Utils.Map.MapGenerator mapGenerator = null;

	Animator adventurerAnimator;
    Rigidbody2D adventurerRdb;
    
    string inputHorizontal = "Horizontal";
    string inputVertical = "Vertical";
    Vector3 originalPosition = Vector3.zero;
    Vector3 velocity;
	public float originalSpeed = 10.0f;
	public float speed;

    void Start()
    {
		gameManager = FindObjectOfType<ModdedGameManager>();
        mapGenerator = GameObject.FindObjectOfType<Utils.Map.MapGenerator>();

		adventurerAnimator = this.gameObject.GetComponent<Animator>();
        adventurerRdb = this.gameObject.GetComponent<Rigidbody2D>();

        originalPosition = transform.position;
		speed = originalSpeed;
    }

    void Update()
    {
        velocity = new Vector2(Input.GetAxisRaw(inputHorizontal),
            Input.GetAxisRaw(inputVertical)).normalized * (speed * (mapGenerator == null ? 1 : mapGenerator.tileScale));

        adventurerAnimator.SetFloat("walking", velocity.magnitude);
    }

    void FixedUpdate()
    {
        Vector2 velocity2D = new Vector2(velocity.x, velocity.y);

        adventurerRdb.MovePosition(Vector3.Lerp(adventurerRdb.position, adventurerRdb.position + velocity2D, Time.fixedDeltaTime));

        this.transform.up = velocity2D;
    }

	void OnTriggerEnter2D(Collider2D colisor)
    {
		if (colisor.gameObject.tag.ToString().Equals("Enemy"))
        {
            Mob touchedMob = colisor.GetComponent<Mob>();
		
			if (gameManager != null) {
				gameManager.sufferDamage (touchedMob.Damage);

				if (gameManager.actualHealth <= 0) 
				{
					gameManager.actualHealth = gameManager.maxHealth;

					transform.position = originalPosition;
					speed = originalSpeed;
					             
					gameManager.DecrementLife ();
				}
			}
        }
    }
}
