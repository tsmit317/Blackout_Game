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
		SoundManager.instance.playSoundEffect (3);
		if (collider.tag == "Player"){
			collider.SendMessage ("SetCheckpointPosition", gameObject.transform.position);
			isActivated = true;
		}			
	}

}
