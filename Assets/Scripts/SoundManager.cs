using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour {
	public static SoundManager instance = null; 

	public AudioSource sourceEffect;
	public AudioSource mainMenuBackGround;
	public AudioSource level01Background;
	public AudioSource level02Background;
	public AudioSource creditsBackground;

	public AudioClip[] audioClips;

	void Start () {

	}

	void Awake ()
	{
		if (instance == null)
		{
			instance = this;
		}
		else if (instance != null || instance != this)
		{	
			Destroy (this.gameObject);
		}

		DontDestroyOnLoad (gameObject);
	}

	void Update()
	{
		levelCheck ();
	}

	/*	Checks scene name and if the correct music is already playing
		If not, stops all other audio sources and plays correct source*/
	public void levelCheck()
	{
		if (SceneManager.GetActiveScene().name == "Main Menu" && !mainMenuBackGround.isPlaying) 
		{
			creditsBackground.Stop ();
			level01Background.Stop ();
			level02Background.Stop ();
			mainMenuBackGround.Play ();
		} 
		else if (SceneManager.GetActiveScene ().name == "Level01" && !level01Background.isPlaying) 
		{
			creditsBackground.Stop ();	
			level02Background.Stop ();
			mainMenuBackGround.Stop ();
			level01Background.Play ();
		} 
		else if (SceneManager.GetActiveScene ().name == "Level02" && !level02Background.isPlaying) 
		{	
			creditsBackground.Stop ();
			mainMenuBackGround.Stop ();
			level01Background.Stop ();
			level02Background.Play ();
		}
		else if (SceneManager.GetActiveScene ().name == "Credits" && !creditsBackground.isPlaying) 
		{	
			mainMenuBackGround.Stop ();
			level01Background.Stop ();
			level02Background.Stop ();
			creditsBackground.Play ();

		}
	}
	public void playSoundEffect(int index){
		sourceEffect.clip = audioClips[index];
		sourceEffect.Play ();
	}

	/*void Update(){
		if (Input.GetKey (KeyCode.Q))
			playSoundEffect (0);
	}*/


}
