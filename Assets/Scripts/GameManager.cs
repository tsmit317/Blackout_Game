using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
	public static GameManager Instance = null;

	//Contains all the variables we need to store for saving and moving scene to scene
	//Gives additional level of securtiy so cant write wrong variables into saved varibales.
	public GameData localData = new GameData();

	void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}

		if (Instance != this) 
		{
			Destroy (gameObject);
		}
	}

	void Start()
	{
		localData = SaveLoad.Instance.savedData;
	}
}
