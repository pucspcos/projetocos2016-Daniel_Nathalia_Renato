/**
 * Created by Mario Madureira Fontes
 * Edited by Daniel Haruo Tamura
 * Procedural Game Jam 2015
 */
using UnityEngine;

public class Adventurer : MonoBehaviour
{
	ModdedGameManager moddedGameManager;
	private Utils.Map.MapGenerator mapGenerator = null;
	public Material normalMaterial;
	public Material invulnerableMaterial;
	public Material speedUpMaterial;

	SpriteRenderer adventurerSprite;
	Animator adventurerAnimator;
    Rigidbody2D adventurerRdb;
    
    string inputHorizontal = "Horizontal";
    string inputVertical = "Vertical";
    Vector3 originalPosition = Vector3.zero;
    Vector3 velocity;

    void Start()
    {
		moddedGameManager = FindObjectOfType<ModdedGameManager>();
        mapGenerator = GameObject.FindObjectOfType<Utils.Map.MapGenerator>();

		adventurerSprite = this.gameObject.GetComponent<SpriteRenderer>();
		adventurerAnimator = this.gameObject.GetComponent<Animator>();
        adventurerRdb = this.gameObject.GetComponent<Rigidbody2D>();

        originalPosition = transform.position;
    }

    void Update()
    {
        velocity = new Vector2(Input.GetAxisRaw(inputHorizontal),
			Input.GetAxisRaw(inputVertical)).normalized * (moddedGameManager.speed * (mapGenerator == null ? 1 : mapGenerator.tileScale));
	
        adventurerAnimator.SetFloat("walking", velocity.magnitude);
    }

    void FixedUpdate()
    {
        Vector2 velocity2D = new Vector2(velocity.x, velocity.y);

        adventurerRdb.MovePosition(Vector3.Lerp(adventurerRdb.position, adventurerRdb.position + velocity2D, Time.fixedDeltaTime));
        
		transform.up = velocity2D;

		if (moddedGameManager.actualHealth <= 0) 
		{
			moddedGameManager.actualHealth = moddedGameManager.maxHealth;
			moddedGameManager.invulnerableTime = 0;
			moddedGameManager.speed = moddedGameManager.originalSpeed;
			moddedGameManager.speedUpTime = 0;
			transform.position = originalPosition;
			moddedGameManager.changeLifes (-1);
		}

		if (moddedGameManager.invulnerableTime > 0) 
		{
			adventurerSprite.material = invulnerableMaterial;
		}
		else if (moddedGameManager.speedUpTime > 0)  
		{
			adventurerSprite.material = speedUpMaterial;
		}
		else 
		{
			adventurerSprite.material = normalMaterial;
		}
    }
}
