using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HourglassScript : MonoBehaviour
{
	// Delegates and events
	public delegate void Slow();
	public static event Slow slowDown;
	
	// Public variables
	public float speed;
	
	// Colliders
	public CircleCollider2D timerCollider;
	
	// Local variables
	private int collected = 0;
	private float x_size = 0.1f;
	private float y_size = 0.1f;
	
	
	/**** Functions ****/
	
	
	// Update movement function
	void Update()
	{
		if (gameObject.activeInHierarchy)
		{
			if (transform.position.y > -3)
			{
				transform.Translate(0, -speed * Time.timeScale, 0);
				transform.Rotate(0, 5f * Time.timeScale, 0, Space.Self);
			}
			
			if (transform.position.y < -2 || collected == 1)
			{
				gameObject.transform.localScale = new Vector3(x_size, y_size, 0f);
				x_size -= 0.005f;
				y_size -= 0.005f;
				
				if (x_size <= 0)
				{
					gameObject.SetActive(false);
					gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0f);
					x_size = 0.1f;
					y_size = 0.1f;
					collected = 0;
					timerCollider.enabled = true;
				}
			}
		}
	}
	
	// Collision function
	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.tag == "Player" && collected == 0)
		{
			timerCollider.enabled = false;
			collected = 1;
			slowDown();
		}
	}
}
