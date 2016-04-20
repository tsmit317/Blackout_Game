using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class CreditsScene : MonoBehaviour {

	public GameObject camera;
	public float scrollSpeed; 
	public int timeUntilMain;


	// Update is called once per frame
	void Update ()
	{
		camera.transform.Translate (Vector3.up * scrollSpeed * Time.deltaTime);


		StartCoroutine (timeToWait (timeUntilMain));

	}

	IEnumerator timeToWait(float time)
	{
		yield return new WaitForSeconds (time);
		SceneManager.LoadScene ("Main Menu");
	}
}
