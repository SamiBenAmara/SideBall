using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentrePlayerScript : MonoBehaviour
{
	// Local variables
	int death = 0;
	float x_size = 0.09f;
	float y_size = 0.09f;
	int shrinkgrow = 0;
	float shrinkTimer = 5f;
	
	
	/**** Functions ****/
	
	
	// Start function
	void Start()
	{
		if (PlayerPrefs.GetInt("Skin") == 7)
		{
			gameObject.GetComponent<Renderer>().enabled = true;
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
	}
	
	// OnDisable function
	void OnDisable()
	{
		DeathMovement.youDied -= YouAreDead;
		EnemyMovementCollision.youDied -= YouAreDead;
		MovingEnemyScript.youDied -= YouAreDead;
		BottomDeathMovement.youDied -= YouAreDead;
		ShrinkerScript.getSmaller -= Shrink;
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
}
