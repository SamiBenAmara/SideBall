using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreImageScript : MonoBehaviour
{
	// Public variables
	public int direction;
	public int orientation;
	
	// Local variables
	float speed;
	//float turnTimer = 0.5f;
	
	
	/**** Functions ****/
	
	
	// Start function
	void Start()
	{
		speed = Random.Range(1f, 3f);
	}
	
	// Orientation: 0 means z rotation, 1 means y rotation, 2 means x rotation, 3 means switch from left to right and vice versa, 4 for Saturn
	// Particle system
	
	// Update function
	void Update()
	{
		if (orientation == 0)
		{
			if (direction == 1)
			{
				transform.Rotate(0f, 0f, speed, Space.World);
			}
			
			if (direction == -1)
			{
				transform.Rotate(0f, 0f, -speed, Space.World);
			}
		}
		
		if (orientation == 1)
		{
			if (direction == 1)
			{
				transform.Rotate(0f, speed, 0f, Space.World);
			}
			
			if (direction == -1)
			{
				transform.Rotate(0f, -speed, 0f, Space.World);
			}
		}
		
		if (orientation == 2)
		{
			if (direction == 1)
			{
				transform.Rotate(speed, 0f, 0f, Space.World);
			}
			
			if (direction == -1)
			{
				transform.Rotate(-speed, 0f, 0f, Space.World);
			}
		}
		
		if (orientation == 4)
		{
			if (direction == 1)
			{
				transform.Rotate(0f, speed, 0f, Space.Self);
			}
			
			if (direction == -1)
			{
				transform.Rotate(0f, -speed, 0f, Space.Self);
			}
		}
	}
}
