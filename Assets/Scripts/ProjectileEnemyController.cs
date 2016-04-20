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
                if (!facingRight)
                {
                    GameObject flipThis = Instantiate(enemyProjectile, launchPoint.position, launchPoint.rotation) as GameObject;
                    flipThis.transform.localScale = new Vector3(-2.5f, 3, 1);
                    shotCounter = waitBetweenShots;
                }
                else
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
