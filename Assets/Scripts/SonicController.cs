using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SonicController : MonoBehaviour {

    float maxSpeed = 7f;
    float jumpForce = 700f;
    bool facingRight = true;
    Rigidbody2D rigidbody2D; //'new' keyword may cause probs. Keep an eye out.
    Animator anim;//anim is the variable name for Animator.

    bool grounded = false;
    public Transform groundCheck; //Creating an object that represents where the ground should be.
    float groundRadius = 0.2f;//How big the sphere is when we check for the ground.
    public LayerMask whatIsGround;//Defines exactly what the character will land on that stops the falling animation.
    public bool hello;

	// Use this for initialization
	void Start () {
        //I'm pretty sure this will get the Rigidbody component that is attached to Sonic_0. Then I can use it in my code.
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
    // Fixed update is called in sync with the physics engine.
	void FixedUpdate ()//Anything dependant only on physics interactions do here.
    {

        //Identify if character is on the 'ground' (Any collider object)
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        anim.SetBool("Ground", grounded);

        //Telling the Animator the current vertical speed.
        anim.SetFloat("vSpeed", rigidbody2D.velocity.y); //How fast moving up or down.

        float move = Input.GetAxis("Horizontal");
        

        anim.SetFloat("Speed", Mathf.Abs(move));//Sending the 'speed' to the animator.
        

        rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);

        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();

	}

    void Update()//Anything dependant on user input put here.
    {
        //If charactesr on the ground, and space is pressed, give them force applied up.
        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("Ground", grounded);
            rigidbody2D.AddForce(new Vector2(0, jumpForce));
        }

        bool running = Input.GetButton("Run"); //These two decide if the run button is pressed and update the animator.
        anim.SetBool("Running", running);

        //Identify if run button is being pressed and updating max speed value accordingly. I'll let the Animator handle the animation based on the speed value.
        if (running && grounded)
        {
            maxSpeed = 12f;
            
        }
        else if(!running && grounded) //Ha the && grounded part simulates momentum in the air. Kindof.
        {
            maxSpeed = 7f;
        }

        if (Input.GetKeyDown(KeyCode.O))
            {
            SceneManager.LoadScene("nextscene1");
            }
    }

    void Flip()
    {
        facingRight = !facingRight; //Alternating the facingRight bool when the flip function is called.
        Vector3 theScale = transform.localScale; //Not entirely sure what this flips exactly.
        theScale.x *= -1;
        transform.localScale = theScale;

    }

    void OnCollisionEnter2D (Collision2D other)
    {
        if (other.transform.tag == "MovingPlatform")
        {
            transform.parent = other.transform;
        }
    }


    void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.tag == "MovingPlatform")
        {
            transform.parent = null;
        }
    }

}
