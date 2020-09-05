using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemyScript : MonoBehaviour
{
    // Delegates and events
	public delegate void Death();
	public static event Death youDied;
	
	// Colliders
	public PolygonCollider2D movingEnemyCollider;
	
	// Local variables
	private int side;
	private float x_size = 0.06f;
	private float y_size = 0.06f;
	
	
	/**** Functions ****/
	
	
	// Update movement function
	void Update()
	{
		if (Time.timeScale == 0) return;
		
		if (transform.position.x == 1.5f) side = 1;
		
		else if (transform.position.x == -1.5f) side = 0;
		
		if (side == 0)
		{
			transform.Translate(0.01f * Time.timeScale, -0.06f * Time.timeScale, 0, Space.World);
			transform.Rotate(0, 0, -10f * Time.timeScale, Space.Self);
		}
		
		else if (side == 1)
		{
			transform.Translate(-0.01f * Time.timeScale, -0.06f * Time.timeScale, 0, Space.World);
			transform.Rotate(0, 0, 10f * Time.timeScale, Space.World);
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
