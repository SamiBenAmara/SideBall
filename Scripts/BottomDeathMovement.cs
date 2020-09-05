using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomDeathMovement : MonoBehaviour
{
	// Delegates and events
	public delegate void TouchDeath();
	public static event TouchDeath youDied;
	
	// Local variables
	float moveuptimer = 0.6f;
	float movedowntimer = 0.6f;
	int move = 0;
	
	
	/**** Functions ****/
	
	
	// Update function
	void Update()
	{
		if (PlayerPrefs.GetInt("InfoButton") == 100)
		{
			if (Time.timeScale == 0)
			{
				return;
			}
			
			transform.Rotate(0, 0, 12f * Time.timeScale, Space.Self);
			transform.Translate(0f, 0.0021f * Time.timeScale, 0f, Space.World); 
			
			if (move == 1)
			{
				transform.Translate(0f, 0.02f * Time.timeScale, 0f, Space.World);
				moveuptimer -= Time.deltaTime;
				
				if (moveuptimer <= 0)
				{
					move = 0;
					moveuptimer = 0.6f;
				}
			}
			
			else if (move == 2)
			{
				transform.Translate(0f, -0.04f * Time.timeScale, 0f, Space.World);
				movedowntimer -= Time.deltaTime;
				
				if (movedowntimer <= 0)
				{
					move = 0;
					movedowntimer = 0.6f;
				}
			}
		}
	}
	
	// Collision function
	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			youDied();
		}
	}
	
	void OnEnable()
	{
		BumpWallScript.Up += MoveUp;
		DownWallScript.Down += MoveDown;
	}
	
	void OnDisable()
	{
		BumpWallScript.Up -= MoveUp;
		DownWallScript.Down -= MoveDown;
	}
	
	// Move the bottom spikes up
	void MoveUp()
	{
		move = 1;
	}
	
	// Move the bottom spikes down
	void MoveDown()
	{
		move = 2;
	}
}
