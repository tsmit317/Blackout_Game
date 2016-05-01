using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class FadeScript : MonoBehaviour {

	public Texture2D ftbTexture;
	public float fadeSpeed;
	private int depth = -1000;
	private float alpha = 1.0f;
	//Fade direction: -1 = fade in/ 1 = fade out
	private int fDirection = -1;

	void OnGUI()
	{
		alpha += (fDirection * fadeSpeed * Time.deltaTime);
		alpha = Mathf.Clamp01 (alpha);
		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);
		GUI.depth = depth;
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), ftbTexture);
	}

	public float StartToFade (int direction)
	{
		fDirection = direction;
		return(fadeSpeed);
	}

	public void LoadingLevel()
	{
		StartToFade (-1);
	}

}
