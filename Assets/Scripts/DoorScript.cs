using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class DoorScript : MonoBehaviour {
	//Since we have the GameManager there is no need to 

	public void EnterDoor(){



		//For reusability - checks the current levels build index
		if(SceneManager.GetActiveScene ().buildIndex == 2) 
		{
			SceneManager.LoadScene ("Level02");
		} 
		else if (SceneManager.GetActiveScene ().buildIndex == 3) 
		{
			SceneManager.LoadScene ("Level03");
		}
	}
}
