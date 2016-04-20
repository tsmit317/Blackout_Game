using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Movement : MonoBehaviour {

	public float walkingSpeed,runningSpeed, jumpingSpeed;
	public bool isGrounded, isFacingRight, movementEnabled;
	public LayerMask groundLayer;	//used to determine what is ground
    //public BurstJump boost;                          //Locke's Variables

    private Vector2 boostSpeed = new Vector2(50, 0); //Locke's Variables
    private bool canBoost = true;                    //Locke's Variables 
    private float boostCooldown = 2f;                //Locke's Variables
    private Rigidbody2D playerBody;
	private Collider2D playerCollider;
	private Animator playerAnimator;

	void Start () {
		playerBody = GetComponent<Rigidbody2D> ();
		playerCollider = GetComponent<Collider2D> ();
		playerAnimator = GetComponent<Animator> ();
		
		/*assigning initial settings*/
		isFacingRight = true;
		isGrounded = true;
		movementEnabled = true;
	}

	void FixedUpdate(){
		if(movementEnabled){
			float movingDirection = Input.GetAxis ("Horizontal"); 
			Moving (movingDirection, walkingSpeed);
			if(Input.GetKey(KeyCode.Z)) //checking if run key is held
				Moving (movingDirection, walkingSpeed + runningSpeed);
			Flip (movingDirection); //flipping player accordingly when moving
		}
	}

	void Update () {
		isGrounded = Physics2D.IsTouchingLayers (playerCollider, groundLayer);
		if(Input.GetKey(KeyCode.X) && isGrounded)  //not allowing more than 1 jump at a time
			playerBody.velocity = new Vector2 (playerBody.velocity.x, jumpingSpeed);
		if (Input.GetKeyDown (KeyCode.LeftAlt))		//suicide button
			SetDeath (true);


        if (!isGrounded && canBoost && Input.GetKeyDown(KeyCode.R))  //Locke's Coroutine statement in the Update Method, uses 'R' key to activate boost for testing purposes
        {
            StartCoroutine(Boost(0.15f));
        }
    }

    IEnumerator Boost(float boostDuration) //Locke's Coroutine that does the Aerial Dash
    {
        float time = 0;
        canBoost = false;

        while (boostDuration > time)
        {
            time += Time.deltaTime;
            GetComponent<Rigidbody2D>().velocity = boostSpeed;
            if (isFacingRight == true)
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(4, 0));
            }
            else if (isFacingRight == false)
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(-4, 0));
            }

            yield return 0;
        }
        yield return new WaitForSeconds(boostCooldown);
        canBoost = true;
    }

    /* Method for actual moving player left/right */
    private void Moving(float horizontal, float speedVelocity){
		float temp = horizontal * speedVelocity;
		playerBody.velocity = new Vector2 (temp, playerBody.velocity.y);
		//playerAnimator.SetFloat ("Speed", Mathf.Abs (temp));
	}

	/* Method to Flip character facing direction*/
	private void Flip(float horizontal){
		if((horizontal>0 && !isFacingRight) || (horizontal<0 && isFacingRight)){
			isFacingRight = !isFacingRight;
			Vector3 theFlipScale = transform.localScale;
			theFlipScale.x *= (-1);
			transform.localScale = theFlipScale;
		}
	}

	public void SetDeath(bool isDead){
		if(isDead){
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex); //basically reloading the stage
		}
	}
}
