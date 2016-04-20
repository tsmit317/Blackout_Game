using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {

	public GameObject platform;
	public Transform currentPoint;
	public Transform[] platformPoints; // Array of for points to travel along
	public int selectedPoint; // Point to start at.
	public float platformSpeed; // Variable used in movement (update). Ignore in Scene
	public float userSetSpeed; // What we set in the scene. I cant set platformSpeed to private since it's being used in class Switch.

	// Use this for initialization
	void Start () 
	{
		currentPoint = platformPoints [selectedPoint];
	}

	// Update is called once per frame
	void Update () 
	{
		platform.transform.position = Vector3.MoveTowards (platform.transform.position, currentPoint.position, Time.deltaTime * platformSpeed);
			if (platform.transform.position == currentPoint.position) 
			{
				selectedPoint++;

				if (selectedPoint == platformPoints.Length) 
				{
					selectedPoint = 0;
				}

				currentPoint = platformPoints [selectedPoint];
			}
	}

		
}
