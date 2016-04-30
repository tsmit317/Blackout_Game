using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;




public class MainMenu : MonoBehaviour {


	//	public GameObject title;
	//public CanvasGroup buttons;
	//	public GameObject soundManager;

	public string startLevel;
	public string instructions;
	public string back;
	public string credits;
	public float fadeTime;

	void Start()
	{


		//		if (!GameManager.Instance.hasFlashedOnce)
		//		{
		//			//buttons.alpha = 0f;
		//			StartCoroutine (ShowMessage ());
		//			GameManager.Instance.hasFlashedOnce = true;
		//		} 
		//		else 
		//		{
		//			soundManager.SetActive (true);
		//			//buttons.alpha = 1f;
		//			title.SetActive (true);
		//		}
	}
	//	IEnumerator ShowMessage () 
	//	{
	//		soundManager.SetActive (false);
	//		title.SetActive (false);
	//		yield return new WaitForSeconds(.2f);
	//		title.SetActive (true);
	//		yield return new WaitForSeconds (.05f);
	//		title.SetActive (false);
	//		yield return new WaitForSeconds(.7f);
	//		title.SetActive (true);
	//		yield return new WaitForSeconds(.06f);
	//		title.SetActive (false);
	//		yield return new WaitForSeconds(.5f);
	//		title.SetActive (true);
	//		yield return new WaitForSeconds(.1f);
	//		title.SetActive (false);
	//		yield return new WaitForSeconds(.4f);
	//		title.SetActive (true);
	//		yield return new WaitForSeconds(.2f);
	//		title.SetActive (false);
	//		yield return new WaitForSeconds(.2f);
	//		title.SetActive (true);
	//		yield return new WaitForSeconds(.1f);
	//		title.SetActive (false);
	//		yield return new WaitForSeconds(.1f);
	//		title.SetActive (true);
	//		yield return new WaitForSeconds(.08f);
	//		title.SetActive (false);
	//		yield return new WaitForSeconds(.08f);
	//		title.SetActive (true);
	//		yield return new WaitForSeconds(.05f);
	//		title.SetActive (false);
	//
	//		yield return new WaitForSeconds(.5f);
	//		title.SetActive (true);
	////		while (buttons.alpha < 1) 
	////		{
	////			buttons.alpha += Time.deltaTime * fadeTime;
	////		}
	//		soundManager.SetActive (true);
	//	}



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










