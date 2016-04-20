using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveLoad : MonoBehaviour {
	
	public static SaveLoad Instance = null; 
	public GameData savedData = new GameData (); 
	public bool LoadingScene = false;
	private bool guiSet = false;

	void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad (gameObject);
		} 
		else if (Instance != this) 
		{
			Destroy (gameObject);
		}
	}

	public GameData LocalData;


	/*	Saves game
		Creates directory if it doesn't exist
		Creates a new BinaryFormatter - Serializes and deserializes an object in binary format
		Creates a FileStream object and creates a file - Provides stream for writing and reading  
		Sets LocalData to the GameManager Instance localData - Basically references the current player data
		Serializes file and sets it to LocalData 
		Closes file
		Checks to see if file contains anything, if so displays message	*/
	public void Save()
	{
		if(!Directory.Exists("SavedGames"))
		{
			Directory.CreateDirectory("SavedGames");
		}

		BinaryFormatter bFormatter = new BinaryFormatter ();
		FileStream fileToBeSaved = File.Create ( "SavedGames/saved.binary");
		LocalData = GameManager.Instance.localData;
		bFormatter.Serialize (fileToBeSaved, LocalData);
		fileToBeSaved.Close ();

		if (fileToBeSaved != null) 
		{
			StartCoroutine (ShowMessage());
		}
	}


	/*	Used to display message showing the game was saved. 
		Shows message for 4 seconds before deactivating
		Doens't work properly as Time.timeScale is set to 0 when Pause Menu is activated
		Will have to think of another way to display message, or might just leave it. Idk..*/ 
	IEnumerator ShowMessage () 
	{
		guiSet = true;
		yield return new WaitForSeconds(4f);
		guiSet = false;

	}


	/*	Creates GUI displaying "Game Saved". Used to show the Save Game button worked.
		Displays when guiSet is true. */
	void OnGUI() 
	{
		if (guiSet)
		{
			GUI.Label (new Rect (10, 10, 100, 20), "Game Saved");
		}
	}


	/*	Loads previously saved game
		Sets LoadingScene to true so start in MovementScript will know it is not a new game
		Creates a new BinaryFormatter - Serializes and deserializes an object in binary format
		Opens file to a FileStream object - Provides stream for writing and reading 
		Deserializes file and sets it to LocalData */
	public void Load()
	{
		LoadingScene = true;
		BinaryFormatter bFormatter = new BinaryFormatter ();

		FileStream fileToBeSaved = File.Open ( "SavedGames/saved.binary", FileMode.Open);

		LocalData = (GameData)bFormatter.Deserialize (fileToBeSaved);

		fileToBeSaved.Close ();
	}
}

















