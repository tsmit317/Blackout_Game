using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
//depricated use movementscript instead
public class PlayerController : MonoBehaviour {
	/*
	private Rigidbody2D playerBody;
	private Collider2D playerCollider;
	private Vector3 lastCheckpoint, startingPos;

	public float speed;
	public bool isFacingRight, isGrounded, movementEnabled;
	public LayerMask groundLayer;

	void Start () {
		playerBody = GetComponent<Rigidbody2D> ();
		playerCollider = GetComponent<Collider2D> ();
		startingPos = gameObject.transform.position;
		lastCheckpoint = gameObject.transform.position;
		isFacingRight = true;
		isGrounded = true;
		movementEnabled = true;
	}

	void Update () {
		isGrounded = Physics2D.IsTouchingLayers (playerCollider, groundLayer);
		if(isGrounded && Input.GetKeyDown(KeyCode.Space))
			playerBody.velocity = new Vector2 (playerBody.velocity.x, speed);

		if (Input.GetKeyDown (KeyCode.Q))
			SetDeath (true);
	}

	void FixedUpdate(){
		if(movementEnabled)
			Moving (Input.GetAxis ("Horizontal"), speed);
	}

	private void Moving(float horizontal, float speedVelocity){
		playerBody.velocity = new Vector2 ((horizontal * speedVelocity), playerBody.velocity.y);
		Flip (horizontal);
	}

	private void Flip(float horizontal){
		if((horizontal>0 && !isFacingRight) || (horizontal<0 && isFacingRight)){
			isFacingRight = !isFacingRight;
			Vector3 theFlipScale = transform.localScale;
			theFlipScale.x *= (-1);
			transform.localScale = theFlipScale;
		}
	}

	private void SetDeath(bool isDead){
		if(isDead){			
			if(lastCheckpoint!=startingPos){
				HealthBarManager healthBarManager = GetComponent<HealthBarManager> ();
				healthBarManager.SendMessage ("Reset");
				playerBody.transform.position = lastCheckpoint;
			}else{
				SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
				playerBody.transform.position = startingPos;
			}
		}
	}

	public void SetCheckpointPosition(Vector3 checkpointPos){
		lastCheckpoint = checkpointPos;
	}

	public void RecieveKnockBackMessage(Vector2 knockbackDistance){
		playerBody.velocity = knockbackDistance * 2;
	}

	void OnTriggerStay2D(Collider2D collider){
		if(Input.GetKeyDown(KeyCode.X) && collider.tag == "Door"){
			Debug.Log ("player StayDetected");
			collider.gameObject.SendMessage("EnterDoor");
		}
	}
	/*
	//When player comes into contact with platform, sets the platform as the parent.
	//Allows the player to move with the platform, rather than sliding off.
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.transform.tag == "MovingPlatform")
		{
			transform.parent = other.transform;
		}
	}

	//When player jumps off platform, removes platform as player.
	//Keeps player from moving with platform while on the ground.
	void OnCollisionExit2D(Collision2D other)
	{
		if (other.transform.tag == "MovingPlatform")
		{
			transform.parent = null;
		}
	}*
	/*/
}
