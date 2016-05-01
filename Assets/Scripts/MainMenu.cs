using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;




public class MainMenu : MonoBehaviour {



	public GameObject buttons;
	public GameObject soundManager;
	public Animator titleAnim;
	public string startLevel;
	public string instructions;
	public string back;
	public string credits;
	private int functionCase;

	void Start()
	{
		//Fades in for Main and Instructions.
		GameObject.Find ("GameManager").GetComponent<FadeScript> ().LoadingLevel();

		//Determines if it needs to flash. 
		if (!GameManager.Instance.hasFlashedOnce)
		{
			StartCoroutine (TitleFlashing ());
			GameManager.Instance.hasFlashedOnce = true;
		} 
		else 
		{
			titleAnim.SetBool ("FirstTimeMainMenu", false);
			buttons.SetActive (true);
			soundManager.SetActive (true);
		}
	}

	IEnumerator TitleFlashing () 
	{
		Debug.Log ("Ger");
		soundManager.SetActive (false);
		buttons.SetActive (false);
		titleAnim.SetBool("FirstTimeMainMenu",true);
		yield return new WaitForSeconds(3.2f);
		titleAnim.SetBool ("FirstTimeMainMenu", false);

		soundManager.SetActive (true);
		buttons.SetActive (true);
	}



	public void NewGame()
	{
		functionCase = 0;
		StartCoroutine (FadeOut ());
	}

	public void Continue()
	{
		functionCase = 1;
		StartCoroutine (FadeOut ());
	}

	public void Instructions()
	{
		functionCase = 2;
		StartCoroutine (FadeOut ());
	}

	public void Credits()
	{
		functionCase = 3;
		StartCoroutine (FadeOut ());
	}

	public void BackToMain()
	{
		functionCase = 4;
		StartCoroutine (FadeOut ());
	}

	public void QuitGame()
	{
		functionCase = 5;
		StartCoroutine (FadeOut ());
	}

	//Fades out after buttons. 
	IEnumerator FadeOut()
	{
		float fadeTime = GameObject.Find ("GameManager").GetComponent<FadeScript> ().StartToFade (1);
		yield return new WaitForSeconds (fadeTime);

		switch (functionCase)
		{
			case 0:
				SceneManager.LoadScene (startLevel);
				break;
			case 1:
				SaveLoad.Instance.Load ();
				//Loads scene. Loads before copying data otherwise data would not carried over to the level. 
				SceneManager.LoadScene (SaveLoad.Instance.LocalData.SceneIndex);
				break;
			case 2:
				SceneManager.LoadScene (instructions);
				break;
			case 3:
				SceneManager.LoadScene (credits);
				break;
			case 4: 
				SceneManager.LoadScene (back);
				break;
			case 5:
				Application.Quit ();
				break;
		}
			
	}
}










