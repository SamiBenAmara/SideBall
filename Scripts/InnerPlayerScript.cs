using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerPlayerScript : MonoBehaviour
{
	// Sprite skins
	public Sprite innerSinkSkin;
	public Sprite innerEarthSkin;
	public Sprite innerOuterSkin;
	public Sprite secondDiskSkin;
	
	// Local variables
	int death = 0;
	float x_size = 0.09f;
	float y_size = 0.09f;
	int shrinkgrow = 0;
	float shrinkTimer = 5f;
	//float growTimer = 5f;
	int rotate;
	int side = 0;
	
	/**** Functions ****/
	
	
	// Start function
	void Start()
	{
		
		/**** Checking which skin the player is using ****/
		
		
		// Sink Skin
		if (PlayerPrefs.GetInt("Skin") == 4)
		{
			gameObject.GetComponent<Renderer>().enabled = true;
			this.GetComponent<SpriteRenderer>().sprite = innerSinkSkin;
			rotate = 0;
		}
		
		// Earth Skin
		else if (PlayerPrefs.GetInt("Skin") == 6)
		{
			gameObject.GetComponent<Renderer>().enabled = true;
			this.GetComponent<SpriteRenderer>().sprite = innerEarthSkin;
			rotate = 1;
			
			if (side == 1)
			{
				transform.Rotate(0, 0, Mathf.Lerp(0f, 360f, 0.5f));
			}
		}
		
		// Inner Outer Skin
		else if (PlayerPrefs.GetInt("Skin") == 7)
		{
			gameObject.GetComponent<Renderer>().enabled = true;
			this.GetComponent<SpriteRenderer>().sprite = innerOuterSkin;
			rotate = 2;
		}
		
		// Double Disk Skin
		else if (PlayerPrefs.GetInt("Skin") == 9)
		{
			gameObject.GetComponent<Renderer>().enabled = true;
			this.GetComponent<SpriteRenderer>().sprite = secondDiskSkin;
			rotate = 3;
		}
		
		else
		{
			gameObject.GetComponent<Renderer>().enabled = false;
		}
	}
	
	// Update function
    void Update()
    {
        transform.position = GameObject.FindWithTag("Player").transform.position;
		
		if (rotate == 2)
		{
			transform.Rotate(0f, 0f, -7f * Time.timeScale, Space.Self);
		}
		
		else if (rotate == 3)
		{
			transform.Rotate(-7f * Time.timeScale, 0f, 0f, Space.Self);
		}
		
		if (death == 1)
		{
			gameObject.transform.localScale = new Vector3(x_size, y_size, 0f);
			x_size -= 0.005f;
			y_size -= 0.005f;
			
			if (x_size <= 0)
			{
				death = 2;
				gameObject.GetComponent<Renderer>().enabled = false;
			}
		}
		
		if (shrinkgrow == 1)
		{
			gameObject.transform.localScale = new Vector3(0.05f, 0.05f, 0f);
			shrinkTimer -= Time.deltaTime;
			
			if (shrinkTimer <= 0)
			{
				shrinkTimer = 5f;
				shrinkgrow = 0;
				gameObject.transform.localScale = new Vector3(0.09f, 0.09f, 0f);
			}
		}
    }
	
	// OnEnable function
	void OnEnable()
	{
		DeathMovement.youDied += YouAreDead;
		EnemyMovementCollision.youDied += YouAreDead;
		MovingEnemyScript.youDied += YouAreDead;
		BottomDeathMovement.youDied += YouAreDead;
		ShrinkerScript.getSmaller += Shrink;
		CircleScript.otherDirection += Side;
	}
	
	// OnDisable function
	void OnDisable()
	{
		DeathMovement.youDied -= YouAreDead;
		EnemyMovementCollision.youDied -= YouAreDead;
		MovingEnemyScript.youDied -= YouAreDead;
		BottomDeathMovement.youDied -= YouAreDead;
		ShrinkerScript.getSmaller -= Shrink;
		CircleScript.otherDirection -= Side;
	}
	
	// You died function
	void YouAreDead()
	{
		death = 1;
	}
	
	// Shrink function
	void Shrink()
	{
		shrinkgrow = 1;
	}
	
	void Side()
	{
		transform.Rotate(0, 0, Mathf.Lerp(0f, 360f, 0.5f));
	}
	
	// Grow function
	//void Grow()
	//{
	//	shrinkgrow = 2;
	//}
	
	/*if (shrinkgrow == 2)
		{
			gameObject.transform.localScale = new Vector3(0.12f, 0.12f, 0f);
			growTimer -= Time.deltaTime;
			
			if (growTimer <= 0)
			{
				growTimer = 5f;
				shrinkgrow = 0;
				gameObject.transform.localScale = new Vector3(0.09f, 0.09f, 0f);
			}
		}*/
}
