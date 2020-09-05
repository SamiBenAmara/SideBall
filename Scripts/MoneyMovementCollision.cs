using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyMovementCollision : MonoBehaviour
{
    // Delegates and Events
	public delegate void MoneyCounter();
	public static event MoneyCounter Counter;
	
	// Colliders
	public CircleCollider2D moneyCollider;
	
	// Local variables
	private float moneySpeed = 0.06f;
	private float x_size = 0.05f;
	private float y_size = 0.05f;
	private int collected = 0;
	
	
	/**** Functions ****/

	
	// Money Movement function and event receiver
	void Update()
	{
		if (Time.timeScale == 0) return;
		
		if (transform.position.y > -3)
		{
			transform.Translate(0, -moneySpeed * Time.timeScale, 0, Space.World);
			transform.Rotate(0, 5f * Time.timeScale, 0, Space.Self);
		}
		
		if (collected == 1) transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, 7f, 0f), 2f * Time.deltaTime);
		
		if ((transform.position.y > 2 && collected == 1) || (transform.position.y < -2))
		{
			gameObject.transform.localScale = new Vector3(x_size, y_size, 0f);
			x_size -= 0.005f;
			y_size -= 0.005f;
			
			if (x_size <= 0)
			{
				gameObject.SetActive(false);
				gameObject.transform.localScale = new Vector3(0.05f, 0.05f, 0f);
				x_size = 0.05f;
				y_size = 0.05f;
				moneyCollider.enabled = true;
				collected = 0;
			}
		}
	}
	
	// Collision function
	void OnCollisionEnter2D (Collision2D col)
	{	
		if (col.gameObject.tag == "Player" && collected == 0)
		{
			moneyCollider.enabled = false;
			Counter();
			collected = 1;
		}
	}
}
