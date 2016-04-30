using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class FadeScript : MonoBehaviour {

	public Image Fade;
	public float fadeSpeed;
	public bool isSceneStart = true;

	void Awake()
	{
		Fade.rectTransform.localScale = new Vector2(Screen.width, Screen.height);
	}

	void Update()
	{
		if (isSceneStart && SceneManager.GetActiveScene ().buildIndex != 0)
		{
			StartScene ();
		}
	}


	void FadeSceneToClear()
	{
		Fade.color = Color.Lerp(Fade.color, Color.clear, fadeSpeed * Time.deltaTime);
	}


	void FadeSceneToBlack()
	{
		Fade.color = Color.Lerp(Fade.color, Color.black, fadeSpeed * Time.deltaTime);
	}


	public void StartScene()
	{
		FadeSceneToClear();

		if (Fade.color.a <= 0.05f)
		{
			Fade.color = Color.clear;
			Fade.enabled = false;

			isSceneStart = false;
		}
	}

	public void Flash()
	{
		isSceneStart = false;
		Fade.color = Color.white;
	}

	public void EndScene(int SceneNumber)
	{
		Fade.enabled = true;

		FadeSceneToBlack();

		if (Fade.color.a >= 0.97f) 
		{
			SceneManager.LoadScene (SceneNumber);
		}
	}
}
