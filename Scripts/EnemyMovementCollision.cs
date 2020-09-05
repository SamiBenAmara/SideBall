using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementCollision : MonoBehaviour
{
	// Delegates and events
	public delegate void Death();
	public static event Death youDied;
	
	// Colliders
	public PolygonCollider2D enemyCollider;
	
	// Local variables
	private float x_size = 0.06f;
	private float y_size = 0.06f;
	
	
	/**** Functions ****/
	
	
	// Controls the Enemy's speed
	void Update()
	{	
		if (Time.timeScale == 0) return;
		
		if (transform.position.y > -3)
		{
			transform.Translate(0, -0.04f * Time.timeScale, 0, Space.World);
			transform.Rotate(0, 0, 10f * Time.timeScale, Space.Self);
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
			enemyCollider.enabled = false;
			youDied();		
		}
	}
}
