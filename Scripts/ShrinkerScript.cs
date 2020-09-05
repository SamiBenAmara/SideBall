using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkerScript : MonoBehaviour
{
	// Delegates and Events
	public delegate void Shrink();
	public static event Shrink getSmaller;
	
	// Colliders
	public CircleCollider2D shrinkCollider;
	
	// Public variables
	public float speed;
	
	// Local variables
	private float x_size = 0.1f;
	private float y_size = 0.1f;
	private int death = 0;
	
	
	/**** Functions ****/
	
	
	// Update movement function
	void Update()
	{
		if (gameObject.activeInHierarchy)
		{
			transform.Translate(0, -speed * Time.timeScale, 0, Space.Self);
			transform.Rotate(0, 5f * Time.timeScale, 0, Space.World);
			
			if (death == 1 || transform.position.y < -2)
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
					death = 0;
					shrinkCollider.enabled = true;
				}
			}
		}
	}
	
	// Collision function
	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.tag == "Player" || death == 0)
		{
			shrinkCollider.enabled = false;
			death = 1;
			getSmaller();
		}
	}
}
