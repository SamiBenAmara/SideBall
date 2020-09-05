using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateMovingEnemy : MonoBehaviour
{
    // Delegates and events
	public delegate void Death();
	public static event Death youDied;
	
	// Colliders
	public PolygonCollider2D movingEnemyCollider;
	
	private float speed = 0.01f;
	private int side;
	private int phase1 = 0;
	private int phase2 = 0;
	private float x_size = 0.06f;
	private float y_size = 0.06f;
	
	
	/**** Functions ****/
	
	
	// Update movement function
	void Update()
	{
		if (Time.timeScale == 0)
		{
			return;
		}
		
		if (transform.position.x == 1.5f)
		{
			side = 1;
		}
		
		if (transform.position.x == -1.5f)
		{
			side = 0;
		}
		
		if (side == 0)
		{
			if (phase1 == 0)
			{
				transform.Translate(0f, (-speed - 0.03f) * Time.timeScale, 0f, Space.World);
				transform.Rotate(0f, 0f, -10f, Space.Self);
				
				if (transform.position.y <= 4.5f)
				{
					phase1++;
				}
			}
			
			if (phase1 == 1)
			{
				transform.Translate(speed * Time.timeScale, 0f, 0f, Space.World);
				transform.Translate(0f, -speed * Time.timeScale, 0f, Space.World);
				transform.Rotate(0f, 0f, -10f, Space.Self);
				
				if (transform.position.x >= 1.5f)
				{
					phase1++;
				}
			}
			
			if (phase1 == 2)
			{
				transform.Translate(0f, (-speed - 0.03f) * Time.timeScale, 0f, Space.World);
				transform.Rotate(0f, 0f, 10f, Space.Self);
			}
		}
		
		else if (side == 1)
		{
			if (phase2 == 0)
			{
				transform.Translate(0f, (-speed - 0.03f) * Time.timeScale, 0f, Space.World);
				transform.Rotate(0f, 0f, 10f, Space.Self);
				
				if (transform.position.y <= 4.5f)
				{
					phase2++;
				}
			}
			
			if (phase2 == 1)
			{
				transform.Translate(-speed * Time.timeScale, 0f, 0f, Space.World);
				transform.Translate(0f, -speed * Time.timeScale, 0f, Space.World);
				transform.Rotate(0f, 0f, 10f, Space.Self);
				
				if (transform.position.x <= -1.5f)
				{
					phase2++;
				}
			}
			
			if (phase2 == 2)
			{
				transform.Translate(0f, (-speed - 0.03f) * Time.timeScale, 0f, Space.World);
				transform.Rotate(0f, 0f, -10f, Space.Self);
			}
		}
		
		if (transform.position.y < -2)
		{
			gameObject.transform.localScale = new Vector3(x_size, y_size, 0f);
			x_size -= 0.01f;
			y_size -= 0.01f;
			
			if (x_size <= 0)
			{
				gameObject.SetActive(false);
				gameObject.transform.localScale = new Vector3(0.06f, 0.06f, 0f);
				x_size = 0.06f;
				y_size = 0.06f;
			}
		}
	}
	
	// Collision function
	void OnCollisionEnter2D (Collision2D col)
	{	
		if (col.gameObject.tag == "Player")
		{
			movingEnemyCollider.enabled = false;
			youDied();	
		}
	}
}
