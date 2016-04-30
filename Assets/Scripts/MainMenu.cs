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
	public float fadeTime;

	void Start()
	{
		

		if (!GameManager.Instance.hasFlashedOnce)
		{
			
			StartCoroutine (TitleFlashing ());
			GameManager.Instance.hasFlashedOnce = true;

		} 
		else 
		{
			buttons.SetActive (true);
			soundManager.SetActive (true);
			titleAnim.SetBool ("FirstTimeMainMenu", false);
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

		SceneManager.LoadScene (startLevel);
	}

	public void Continue()
	{
		SaveLoad.Instance.Load ();
		//Loads scene. Loads before copying data otherwise data would not carried over to the level. 
		SceneManager.LoadScene (SaveLoad.Instance.LocalData.SceneIndex);
	}

	public void Instructions()
	{
		SceneManager.LoadScene (instructions);
	}

	public void Credits()
	{

		SceneManager.LoadScene (credits);
	}

	public void BackToMain()
	{
		SceneManager.LoadScene (back);
	}

	public void QuitGame()
	{
		Application.Quit ();
	}
}










