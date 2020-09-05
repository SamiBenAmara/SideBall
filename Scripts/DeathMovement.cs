using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMovement : MonoBehaviour
{
    // Delegates and events
	public delegate void TouchDeath();
	public static event TouchDeath youDied;
	
	
	/**** Functions ****/
	
	
	// Update function
	void Update()
	{
		if (Time.timeScale == 0)
		{
			return;
		}
		
		transform.Rotate(0, 0, 10f * Time.timeScale, Space.Self);
	}
	
	// Collision function
	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			youDied();
		}
	}
}
