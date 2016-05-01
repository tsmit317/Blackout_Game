using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LogoScript : MonoBehaviour {
	public float screenTime;
	public float fadetime;
	public string mainMenu;
	public TextEditor text;

	void Start()
	{
		StartCoroutine (TimeTillAnimIsDone ());
	}

	IEnumerator TimeTillAnimIsDone()
	{
		

		yield return new WaitForSeconds (screenTime);
		float fadeTime = GameObject.Find ("GameManager").GetComponent<FadeScript> ().StartToFade (1);
		yield return new WaitForSeconds (fadeTime);
		SceneManager.LoadScene (mainMenu);
	}
}
