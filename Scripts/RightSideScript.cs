using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightSideScript : MonoBehaviour
{	
	// GameObjects 
	public GameObject Right_Wall;
	
	private GameObject Right_Clone_1;
	
	private List <GameObject> wall_list;

	// Local Variables
	private float spawnTime = 0;
	private float spawnDelete = 4f;
	private float overtime = 20f;
	private int wallSelector = 0;
	private float spawnRangeEnd = 0.1f;
	private float spawnRangeBeg = 0.05f;
	private int playerPref;
	
	
	/**** Functions ****/
	
	
	// Start Function
	void Start()
	{
		wall_list = new List <GameObject>();
		
        for (int i = 0; i < 50; i++)
		{
			GameObject Right_Clone = Instantiate(Right_Wall);
            wall_list.Add(Right_Clone);
            Right_Clone.SetActive(false);
			Right_Clone.tag = "Right_Wall";
			Right_Clone.name = "Right_Wall";
        }
		
		for (float i = 2; i < 9; i += 0.5f)
		{
			Right_Clone_1 = Instantiate(Right_Wall, new Vector3(2.15f, i, 0), Quaternion.identity);
			Right_Clone_1.tag = "Right_Wall";
			Right_Clone_1.name = "Right_Wall";
			Right_Clone_1.SetActive(true);
		
			Destroy(Right_Clone_1, spawnDelete);
		}

		playerPref = PlayerPrefs.GetInt("InfoButton");
	}
	
	// Update function for y position of Circle and spawning walls
	void Update()
	{
		if (Time.timeScale == 0) return;
		
		if (spawnRangeEnd <= 0.4f) overtime -= Time.deltaTime;
		
		spawnTime -= Time.deltaTime;
		overtime -= Time.deltaTime;
		
		if (spawnTime <= 0)
		{
			SpawnObjectRight();
			spawnTime = Random.Range(spawnRangeBeg, spawnRangeEnd);
		}
		
		if (playerPref == 100)
		{
			if (overtime <= 0)
			{	
				spawnRangeBeg += 0.05f;
				spawnRangeEnd += 0.1f;
				overtime = 20f;
			}
		}
	}
	
		// Left_Wall spawner
	void SpawnObjectRight()
	{	
		if (!wall_list[wallSelector].activeInHierarchy)
		{ 
			wall_list[wallSelector].transform.localScale = new Vector3(0.09f, 0.09f, 0f);
			wall_list[wallSelector].transform.position = new Vector3(2.15f, 8.5f, 0);
			wall_list[wallSelector].SetActive(true);
			wallSelector = (wallSelector + 1) % 50;
		}
	}
}
