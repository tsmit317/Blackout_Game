using UnityEngine;
using System.Collections;

public class HealthBarManager : MonoBehaviour {
	public GameObject[] hearts;
	public int numberOfHearts;

	private PlayerController thePlayer;
	public Rigidbody2D playerBody;

	void Start () {
		numberOfHearts = hearts.Length;
		thePlayer = GetComponent<PlayerController> ();
	}

	void OnCollisionEnter2D(Collision2D coll){
		if(coll.gameObject.tag == "Danger"){
			GameObject temp = coll.gameObject;
//			StartCoroutine ("haltMovement");
			/*
			if(temp.transform.position.x > thePlayer.transform.position.x)
				playerBody.AddRelativeForce(new Vector2(-500,500));
			else
				playerBody.AddForce(new Vector2(5000,500));*/
			numberOfHearts--;
			hearts [numberOfHearts].SetActive (false);
		}

		if (numberOfHearts == 0){
			thePlayer.SendMessage ("SetDeath", true);
			Reset ();
		}
	}

	private void Reset(){
		numberOfHearts = hearts.Length;
		foreach(GameObject go in hearts)
			go.SetActive (true);
	}

	private void SetupScene(int resumeNumberOfHearts){
		numberOfHearts = resumeNumberOfHearts;
		for(int i=0; i<hearts.Length; i++){
			if (i < resumeNumberOfHearts)
				hearts [i].SetActive (true);
			else
				hearts [i].SetActive (false);
		}
	}
	
	IEnumerator haltMovement(){
		thePlayer.movementEnabled = false;
		yield return new WaitForSeconds (1f);
		thePlayer.movementEnabled = true;
	}

	void SendKnockBackMessage(Vector3 hazardObjPos){
		/*StartCoroutine ("haltMovement");
		Vector3 heading = transform.position - hazardObjPos;
		heading /= (heading.magnitude);
		Vector2 directionConverted = new Vector2 (heading.x, heading.y);
		thePlayer.SendMessage ("RecieveKnockBackMessage", directionConverted);*/
		//playerBody.AddForce (new Vector2 (100*(hazardObjPos.x - thePlayer.transform.position.x), 0));
	}

	public int getNumberOfActiveHearts(){
		return numberOfHearts;
	}
}
