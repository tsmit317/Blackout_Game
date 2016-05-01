using UnityEngine;
using System.Collections;

public class ProjectileEnemyController : MonoBehaviour
{
    //facing variables
    public GameObject enemyGraphic;
    bool canFlip = true;
    bool facingRight = true;
    float flipTime = 5f;
    float nextFlipChance = 0f;

    //shooting variables
    public float shootTime;
    float startShootTime;
    bool isShooting;
    Rigidbody2D enemyRB;
    public GameObject enemyProjectile;
    public Transform launchPoint;
    public float waitBetweenShots;
    private float shotCounter;

	//Sound Delaying Variables ((Created by Tyler for experimentation))
	private bool soundCanPlay = true;
	private float soundCanPlayTime;
	private float soundDelayTime = 5f;

    //public Collider2D other;

    // Use this for initialization
    void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();

        shotCounter = waitBetweenShots;

        //other = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
		if (Time.time > soundCanPlayTime) //Allowing the sound that was delayed to play again if the conditions are met.
		{
			soundCanPlay = true;
		}

            shotCounter -= Time.deltaTime;
        if (Time.time > nextFlipChance)
        {
            if (Random.Range(0, 10) >= 5)
            {
                flipFacing();
            }
            nextFlipChance = Time.time + flipTime;
        }

        //if (other.tag == "Player" && shotCounter < 0)
        {
            //Instantiate(enemyProjectile, launchPoint.position, launchPoint.rotation);
            //shotCounter = waitBetweenShots;
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && shotCounter < 0)
        {
            //Instantiate(enemyProjectile, launchPoint.position, launchPoint.rotation);
            //shotCounter = waitBetweenShots;
        }
        if (other.tag == "Player")
        {
			if(soundCanPlay)//Plays the sound if 'soundCanPlay' thinks it's ok. He knows best. ((This is to prevent sound spamming))
			{
				SoundManager.instance.playSoundEffect (5);//You just got detected!
				soundCanPlay = false; //Sound cant play if player reenters before the time is up.
				soundCanPlayTime = Time.time + soundDelayTime;//Setting a time to revert the soundCanPlay bool at.
			}

            if (facingRight && other.transform.position.x < transform.position.x)
            {
                flipFacing();
            }
            else if (!facingRight && other.transform.position.x > transform.position.x)
            {
                flipFacing();
            }
            canFlip = false;
            isShooting = true;
            startShootTime = Time.time + shootTime;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && shotCounter < 0)
        {
            
            if (startShootTime < Time.time)
            {
				SoundManager.instance.playSoundEffect (1);

                if (!facingRight)//Firing left
                {
                    GameObject flipThis = Instantiate(enemyProjectile, launchPoint.position, launchPoint.rotation) as GameObject;
                    flipThis.transform.localScale = new Vector3(-1.8f, 2.3f, 1);
                    shotCounter = waitBetweenShots;
                }
                else //Firing Right
                {
                    Instantiate(enemyProjectile, launchPoint.position, launchPoint.rotation);
                    shotCounter = waitBetweenShots;
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            canFlip = true;
            isShooting = false;
            enemyRB.velocity = new Vector2(0f, 0f);
        }
    }

    void flipFacing()
    {
        if (!canFlip) return;
        float facingX = enemyGraphic.transform.localScale.x;
        facingX *= -1f;
        enemyGraphic.transform.localScale = new Vector3(facingX, enemyGraphic.transform.localScale.y, enemyGraphic.transform.localScale.z);
        facingRight = !facingRight;
    }
}
