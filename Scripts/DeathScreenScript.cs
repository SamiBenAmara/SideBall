using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenScript : MonoBehaviour
{
	// Local variables
	private float x_size = 0f;
	private float y_size = 0f;
	private float deathTimer = 0.5f;
	private int death = 0;
	
	
	/**** Functions ****/

	
	// Start function
	void Start()
	{
		gameObject.GetComponent<Renderer>().enabled = false;
	}
	
	// Update function
	void Update()
	{	
		if (death == 1)
		{
			deathTimer -= Time.deltaTime;
		}
		
		if (deathTimer <= 0)
		{
			death = 2;
			gameObject.GetComponent<Renderer>().enabled = true;
			x_size += 1f;
			y_size += 1f;
			gameObject.transform.localScale = new Vector3(x_size, y_size, 1f);
			
			if (x_size >= 3.5f)
			{
				deathTimer = 0.5f;
				death = 0;
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
	}
	
	// OnDisable function
	void OnDisable()
	{
		DeathMovement.youDied -= YouAreDead;
		EnemyMovementCollision.youDied -= YouAreDead;
		MovingEnemyScript.youDied -= YouAreDead;
		BottomDeathMovement.youDied -= YouAreDead;
	}
	
	// You died function
	void YouAreDead()
	{
		death = 1;
	}
}
