using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftSideScript : MonoBehaviour
{		
	// GameObjects 
	public GameObject Left_Wall;
	
	private GameObject Left_Clone_1;
	
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
			GameObject Left_Clone = Instantiate(Left_Wall);
            wall_list.Add(Left_Clone);
            Left_Clone.SetActive(false);
			Left_Clone.tag = "Left_Wall";
			Left_Clone.name = "Left_Wall";
        }
		
		for (float i = 2; i < 9; i += 0.5f)
		{
			Left_Clone_1 = Instantiate(Left_Wall, new Vector3(-2.15f, i, 0), Quaternion.identity);
			Left_Clone_1.tag = "Left_Wall";
			Left_Clone_1.name = "Left_Wall";
			Left_Clone_1.SetActive(true);
		
			Destroy(Left_Clone_1, spawnDelete);
		}

		playerPref = PlayerPrefs.GetInt("InfoButton");
	}
	
	// Update for y position of the object and spawner
	void Update()
	{
		if (Time.timeScale == 0) return;
		
		if (spawnRangeEnd <= 0.4f) overtime -= Time.deltaTime;
		
		spawnTime -= Time.deltaTime;
		overtime -= Time.deltaTime;
		
		if (spawnTime <= 0)
		{
			SpawnObjectLeft();
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
	void SpawnObjectLeft()
	{	
		if (!wall_list[wallSelector].activeInHierarchy)
		{ 
			wall_list[wallSelector].transform.localScale = new Vector3(0.09f, 0.09f, 0f);
			wall_list[wallSelector].transform.position = new Vector3(-2.15f, 8.5f, 0);
			wall_list[wallSelector].SetActive(true);
			wallSelector = (wallSelector + 1) % 50;
		}
	}
}
