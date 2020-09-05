using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownWallScript : MonoBehaviour
{
	// Delegates and Events
	public delegate void Move();
	public static event Move Down;
	
	// Colliders
	public PolygonCollider2D downArrowCollider;
	
	// Local variables
	int death = 0;
	float x_size = 0.15f;
	float y_size = 0.15f;
	int collected = 0;
	
	
	/**** Functions ****/


    // Update function
    void Update()
    {
        if (gameObject.activeInHierarchy)
		{
			if (transform.position.y > -3)
			{
				transform.Translate(0f, -0.025f * Time.timeScale, 0f);
				transform.Rotate(0f, 5f * Time.timeScale, 0f);
			}
			
			if (death == 1 || transform.position.y < -2)
			{
				gameObject.transform.localScale = new Vector3(x_size, y_size, 0f);
				x_size -= 0.01f;
				y_size -= 0.01f;
				
				if (x_size <= 0)
				{
					gameObject.SetActive(false);
					gameObject.transform.localScale = new Vector3(0.15f, 0.15f, 0f);
					x_size = 0.15f;
					y_size = 0.15f;
					death = 0;
					downArrowCollider.enabled = true;
					collected = 0;
				}
			}
		}
    }
	
	// Collision detection
	void OnCollisionEnter2D (Collision2D col)
	{	
		if (col.gameObject.tag == "Player" && collected == 0)
		{
			downArrowCollider.enabled = false;
			Down();
			death = 1;
			collected = 1;
		}
	}
}
