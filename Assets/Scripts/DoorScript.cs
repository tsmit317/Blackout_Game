using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class DoorScript : MonoBehaviour {

	private BoxCollider2D doorBox;
	private Animator doorAnim;
	private bool canActivate;

	void Start () {
		doorBox = GetComponent<BoxCollider2D> ();
		doorAnim = GetComponent<Animator> ();

		canActivate = false;
	}

	void Update(){
		if (canActivate && Input.GetKeyDown (KeyCode.E)) {
			EnterDoor ();				
		}
	}

	public void EnterDoor(){
		
		StartCoroutine (FadeOut ());
	}

	void OnTriggerEnter2D(Collider2D other){
		Debug.Log ("ENTER DOOR BOX");
		if (other.gameObject.CompareTag ("Player")) {
			canActivate = true;     
			StartCoroutine("animateOpening");
		}
	}

	void OnTriggerExit2D(Collider2D other){
		Debug.Log ("EXIT DOOR BOX");
		if (other.gameObject.CompareTag ("Player")) {
			canActivate = false;
			StartCoroutine("animateClosing");
		}
	}

	IEnumerator animateOpening()
	{
		doorAnim.SetBool ("opening", true);
		yield return new WaitForSeconds(0.25f);
		doorAnim.SetBool ("isOpen", true);

	}

	IEnumerator animateClosing()
	{
		doorAnim.SetBool ("opening", false);
		yield return new WaitForSeconds(0.25f);
		doorAnim.SetBool ("isOpen", false);

	}

	//Taylor: Fades out scene
	IEnumerator FadeOut()
	{
		float fadeTime = GameObject.Find ("GameManager").GetComponent<FadeScript> ().StartToFade (1);

		yield return new WaitForSeconds (fadeTime);

		if (SceneManager.GetActiveScene ().buildIndex == 2) 
		{
			SceneManager.LoadScene ("Level02");
		} 
		else if (SceneManager.GetActiveScene ().buildIndex == 3) 
		{
			SceneManager.LoadScene ("Credits");
		}
	}
}
