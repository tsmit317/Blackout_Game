using UnityEngine;
using System.Collections;

public class CheckpointScript : MonoBehaviour {
	private bool isActivated;
	private Animator checkpointAnim;

	void Start () {
		isActivated = false;
		checkpointAnim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		checkpointAnim.SetBool ("Activated", isActivated);
	}

	void OnTriggerEnter2D(Collider2D collider){		
		if (collider.tag == "Player"){
			if (!isActivated)//Plays checkpoint sound if it's not activated yet.
			{
				SoundManager.instance.playSoundEffect (3);
			}
			collider.SendMessage ("SetCheckpointPosition", gameObject.transform.position);
			isActivated = true;
		}			
	}

}
