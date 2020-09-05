using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightCloneCollision : MonoBehaviour
{
    // Delegate and Event
	public delegate void RightCollide();
	public static event RightCollide hitRightWall;
	
	// Colliders
	public CircleCollider2D rightCollider;
	
	// Local variables
	private int death = 0;
	private float x_size = 0.08f;
	private float y_size = 0.08f;
	private float sizeup = 0f;
	
	
	/**** Functions ****/
	
	
	// Update function
	void Update()
	{
		if (Time.timeScale == 0) return;
		
		if (transform.position.y > 8)
		{
			Color32 newColor = new Color32((byte)PlayerPrefs.GetInt("R"), (byte)PlayerPrefs.GetInt("G"), (byte)PlayerPrefs.GetInt("B"), (byte)255f);
			gameObject.GetComponent<SpriteRenderer>().color = newColor;
		}
		
		if (transform.position.y > -3) transform.Translate(0, -0.06f * Time.timeScale, 0);
		
		if (death == 1)
		{
			sizeup = 2f;
			gameObject.transform.localScale = new Vector3(x_size, y_size, 0f);
			x_size -= 0.0075f;
			y_size -= 0.0075f;
			
			if (x_size <= 0) 
			{
				death = 0;
				Color32 newColor = new Color32((byte)PlayerPrefs.GetInt("R"), (byte)PlayerPrefs.GetInt("G"), (byte)PlayerPrefs.GetInt("B"), (byte)0f);
				gameObject.GetComponent<SpriteRenderer>().color = newColor;
			}
		}
		
		if (sizeup == 0)
		{
			gameObject.transform.localScale = new Vector3(x_size, y_size, 0f);
			x_size -= 0.00075f;
			y_size -= 0.00075f;
			
			if (x_size <= 0.070f) sizeup = 1;
		}
		
		else if (sizeup == 1)
		{
			gameObject.transform.localScale = new Vector3(x_size, y_size, 0f);
			x_size += 0.00075f;
			y_size += 0.00075f;
			
			if (x_size >= 0.080f) sizeup = 0;
		}
		
		if (transform.position.y < -3)
		{
			gameObject.SetActive(false);
			gameObject.transform.localScale = new Vector3(0.09f, 0.09f, 0f);
			rightCollider.enabled = true;
			sizeup = 0f;		
		}
	}
	
	// Collision Script for the cloned right wall
	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			hitRightWall();
			rightCollider.enabled = false;
			death = 1;
		}
	}
}
