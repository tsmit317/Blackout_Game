using UnityEngine;
using System.Collections;

public class BarrierMasterControlScript : MonoBehaviour {
	
	public Collider2D[] redBarriers, yellowBarriers, purpleBarriers;
	public Animator[] redAnims, yellowAnims, purpleAnims;
	public Animator[] redLeversAnim;
	public Animator[] yellowLeversAnim;
	public Animator[] purpleLeversAnim;

	private int currentActiveBarrierId; //determine which barrier is currently active
	//-1 means all are active and 0 none are active; 1 - red | 2 - yellow | 3 - purple
	private KeyCode[] barriersKeys = {
		KeyCode.Alpha1,
		KeyCode.Alpha2,
		KeyCode.Alpha3,
		KeyCode.Keypad1,
		KeyCode.Keypad2,
		KeyCode.Keypad3
	};
		
	void Start () {		
		currentActiveBarrierId = -1;
	}

	void Update () {
		if (Input.GetKeyDown (barriersKeys [0]) || Input.GetKeyDown (barriersKeys [3])) 
			EnableBarriers (1);
		
		if (Input.GetKeyDown (barriersKeys [1]) || Input.GetKeyDown (barriersKeys [4])) 
			EnableBarriers (2);

		if (Input.GetKeyDown (barriersKeys [2]) || Input.GetKeyDown (barriersKeys [5])) 
			EnableBarriers (3);		
	}

	void EnableAll(){
		foreach (Collider2D aBarrier in redBarriers)
			aBarrier.enabled = true;
		foreach (Collider2D aBarrier in yellowBarriers)
			aBarrier.enabled = true;
		foreach (Collider2D aBarrier in purpleBarriers)
			aBarrier.enabled = true;

		foreach (Animator anim in redAnims)
			anim.SetBool ("isOff",false);
		foreach (Animator anim in yellowAnims)
			anim.SetBool ("isOff",false);
		foreach (Animator anim in purpleAnims)
			anim.SetBool ("isOff",false);
		
		/*To change ALL LEVERS to ON position*/
		foreach (Animator anim in redLeversAnim)
			anim.SetBool ("isOff",false);
		foreach (Animator anim in yellowLeversAnim)
			anim.SetBool ("isOff",false);
		foreach (Animator anim in purpleLeversAnim)
			anim.SetBool ("isOff",false);
	}

	/*to enable only specific barriers(ie deactivate specific barriers by enable everything then disable specified)*/
	public void EnableBarriers(int barrierID){
		Debug.Log ("inside enable barriers");
		//only get called if deactivating a different barrier no point in deactivating what is already deactivated
		if (barrierID != currentActiveBarrierId) {
			Debug.Log ("barrierid = " + barrierID);
			//reactivating all barriers
			EnableAll();

			//deactivating barrier
			switch (barrierID) {
			case 1:
				//Debug.Log ("+red");
				foreach (Collider2D aBarrier in redBarriers)
					aBarrier.enabled = false;
				foreach (Animator anim in redAnims)
					anim.SetBool ("isOff",true);
				break;
			case 2:
				Debug.Log ("+yellow");
				foreach (Collider2D aBarrier in yellowBarriers)
					aBarrier.enabled = false;
				foreach (Animator anim in yellowAnims) {
					anim.SetBool ("isOff", true);
					Debug.Log ("inside yellow anim " + anim.GetBool("isOff"));
				}
				break;
			case 3:
				//Debug.Log ("+purple");
				foreach (Collider2D aBarrier in purpleBarriers)
					aBarrier.enabled = false;
				foreach (Animator anim in purpleAnims)
					anim.SetBool ("isOff",true);
				break;
			}
		}
	}

}