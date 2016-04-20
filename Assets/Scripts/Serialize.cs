using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;


/* Class contains all of the variables needed for saving and moving scene to scene */
[Serializable]
public class GameData 
{
	public float LastCheckpointX, LastCheckpointY;
	public int Health;
	public int SceneIndex;
}