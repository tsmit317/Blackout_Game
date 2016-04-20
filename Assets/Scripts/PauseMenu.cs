using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public string mainMenu;

	public bool isGamePaused;

	public GameObject pauseMenuCanvas;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () 
	{
		if (isGamePaused) 
		{
			pauseMenuCanvas.SetActive (true);
			Time.timeScale = 0f;
		} 
		else 
		{
			pauseMenuCanvas.SetActive (false);
			Time.timeScale = 1f;
		}

		if (Input.GetKeyDown (KeyCode.P)) 
		{
			isGamePaused =! isGamePaused;

		}
	}

	public void Save()
	{
		SaveLoad.Instance.Save ();
	}

	public void Resume()
	{
		isGamePaused = false;
	}

	public void Quit()
	{
		SceneManager.LoadScene (mainMenu);
	}
}




