using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;



public class MainMenu : MonoBehaviour {

	public string startLevel;
	public string instructions;
	public string back;
	public string credits;

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










