using UnityEngine;
using System.Collections;

public class EnemyProjectileController : MonoBehaviour {

    public float speed;
	public MovementScript player;
    public GameObject impactEffect;
    public int damageToGive;
    private Rigidbody2D myrigidbody2D;
    private HealthBarManager hurtPlayer;
    

	// Use this for initialization
	void Start ()
    {
		player = FindObjectOfType<MovementScript>();

        myrigidbody2D = GetComponent<Rigidbody2D>();

        if(player.transform.position.x < transform.position.x)
        {
            speed = -speed;

        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        myrigidbody2D.velocity = new Vector2(speed, myrigidbody2D.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" || other.tag == "Level")
        {
            Destroy(gameObject);
        }
        else
        {
            
        }
        
        
    }
}
