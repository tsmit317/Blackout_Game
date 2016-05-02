using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LogoScript : MonoBehaviour
{
	
	public float screenTime;
	public float fadetime;
	public string mainMenu;
	public Animator logo;
	public AudioSource logoSoundEffect;

	void Start()
	{
		StartCoroutine (TimeTillAnimIsDone ());
	}

	IEnumerator TimeTillAnimIsDone()
	{
		//stops anim until fade in is over
		logo.enabled = false;
		yield return new WaitForSeconds (1f);

		//Starts animation and audio and waits until they are done to stop audio
		logo.enabled = true;
		logoSoundEffect.Play ();
		yield return new WaitForSeconds (2.25f);

		//Stops audio when anim is done
		logoSoundEffect.Stop ();
		yield return new WaitForSeconds (screenTime);

		//Fades Screen
		float fadeTime = GameObject.Find ("GameManager").GetComponent<FadeScript> ().StartToFade (1);
		yield return new WaitForSeconds (fadeTime);
		SceneManager.LoadScene (mainMenu);
	}
}
