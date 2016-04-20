using UnityEngine;
using System.Collections;

public class Lever : MonoBehaviour {

	Animator anim;
	public MovingPlatform platform;
    public HealthBarManager healthBar;//Referencing the Object that the "HealthBarManager" component is in.
    public int healthCost;//health "cost" for when activating lever

    private bool isTriggered;
    /*
    This 'isTriggered' bool is a Flag. the 'OnTriggerStay2D' funciton is inconsistent for detecting
    user inputs. 
    It's better to detect all user key strokes from things like GetKeyDown() within the Update method
    where it checks every single frame. I think OnTriggerStay2D only checks for things within every
    second or so, so it's fine for things like detecting if the 'Player' is within the trigger area and
    flagging it with a bool or something, but not much else. You can use that bool in other places.
    */

    // Use this for initialization
    void Start () 
	{
		anim = GetComponent<Animator>();
        isTriggered = false;//Setting the triggered flag to default off. Wont be a problem unless the player
                            //starts within the Box Collider 2D trigger area.
	}
	
	// Inside update is where we check for user inputs, and in this case set the platform values appropraitely.
	void Update () 
	{
        if(isTriggered)
        {
            if (Input.GetKeyDown(KeyCode.E) && platform.platformSpeed == 0)
            {
                Debug.Log("Turnin it on.");
                anim.SetBool("flipDown", true);
                platform.platformSpeed = platform.userSetSpeed;
                healthBar.hurtPlayer(healthCost);//ACTIVATING LEVER DAMAGES PLAYER
            }
            else if (Input.GetKeyDown(KeyCode.E) && platform.platformSpeed > 0)
            {
                Debug.Log("Turnin it off.");
                anim.SetBool("flipDown", false);
                platform.platformSpeed = 0;
                healthBar.hurtPlayer(healthCost);
            }
        }

    }

    /*
    OnTriggereEnter2D and OnTriggerExit2D are used to "Flag" if the 2DCollider area is triggered, 
    so the "isTriggered" bool can be used within the Update method which checks every frame. 
    Mainly because we have to check user input every single frame or we might miss it (That was happening b4). 
    Both these two methods & Stay miss user input pretty often. Unless you have frame perfect tech skill.
    They are however good at picking up on collisions.
    */

    void OnTriggerEnter2D(Collider2D other) //Flagging method.
    {
        if (other.gameObject.tag == "Player")
            isTriggered = true;        
    }

    void OnTriggerExit2D(Collider2D other) //UnFlagging method.
    {
        if (other.gameObject.tag == "Player")
        {
            isTriggered = false;
        }
    }

    /* This method is commented out because the if statements within are now done in the update method.
       //Mainly because if they're done here it misses user input pretty often.
	void OnTriggerStay2D(Collider2D other)
	{
        Debug.Log("Im triggered");

		if (Input.GetKeyDown(KeyCode.E) && platform.platformSpeed == 0f) 
			{
            Debug.Log("Turnin it on.");
				anim.SetBool ("flipDown", true);
				platform.platformSpeed = platform.userSetSpeed;
			}
		else if (Input.GetKeyDown(KeyCode.E) && platform.platformSpeed > 0f) 
			{
            Debug.Log("Turnin it off.");
				anim.SetBool ("flipDown", false);
				platform.platformSpeed = 0f;
			}
	}
    */
}
