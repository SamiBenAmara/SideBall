using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyScript : MonoBehaviour
{
	// GameObjects
	public GameObject Money;
	public GameObject Enemy;
	public GameObject Moving_Enemy;
	public GameObject Ultimate_Moving_Enemy;
	public GameObject Shrinker;
	public GameObject HourGlass;
	public GameObject BumpWall;
	public GameObject DownWall;
	
	private List <GameObject> moneyList;
	private List <GameObject> enemyList;
	private List <GameObject> movingEnemyList;
	private List <GameObject> bumpWallList;
	private List <GameObject> downWallList;
	private List <GameObject> shrinkerList;
	private List <GameObject> hourGlassList;
	private List <GameObject> ultimateMovingEnemyList;
	
	// Local variables
	private float spawnTimePowerUp = 5f;
	private float spawnTimeMoney = 1f;
	private float spawnTimeEnemy = 1f;
	private float spawnTimeMovingEnemy = 60f;
	private float spawnTimeBumpWall = 7f;
	private float spawnTimeDownWall = 7f;
	private float x_spawnPos_money;
	private float x_spawnPos_enemy;
	private float enemiesTimer = 20f;
	private int whichEnemy = 0;
	private int enemySelector = 0;
	private int movingEnemySelector = 0;
	private int moneySelector = 0;
	private int ultimateMovingEnemySelector = 0;
	private int bumpWallSelector = 0;
	private int downWallSelector = 0;
	private int shrinkerSelector = 0;
	private int hourGlassSelector = 0;
	
	
	/**** Functions ****/
	
	
	// Start function
	void Start()
	{
		// Declare GameObject queues
		moneyList = new List <GameObject>();
		enemyList = new List <GameObject>();
		movingEnemyList = new List <GameObject>();
		ultimateMovingEnemyList = new List <GameObject>();
		bumpWallList = new List <GameObject>();
		downWallList = new List <GameObject>();
		shrinkerList = new List <GameObject>();
		hourGlassList = new List <GameObject>();
		
		// Choose random start times for powerups and enemies
		spawnTimePowerUp = Random.Range(5f, 15f);
		spawnTimeMoney = Random.Range(1f, 3f);
		spawnTimeEnemy = Random.Range(1f, 4f);
		spawnTimeMovingEnemy = Random.Range(2f, 6f);
		spawnTimeBumpWall = Random.Range(5f, 10f);
		spawnTimeDownWall = Random.Range(5f, 10f);
		
		// Decides whether the pink or yellow spikes will spawn
		// 0 = Yellow
		// 1 = Pink
		whichEnemy = Random.Range(0, 2);
		
		// Add 20 coins to the coin list
		for (int i = 0; i < 20; i++)
		{
			GameObject moneyClone = Instantiate(Money);
			moneyList.Add(moneyClone);
			moneyClone.SetActive(false);
			moneyClone.tag = "Money";
			moneyClone.name = "Money";
		}
		
		// Adds 20 yellow enemies to the yellow enemies list
		for (int i = 0; i < 20; i++)
		{
			GameObject enemyClone = Instantiate(Enemy);
			enemyList.Add(enemyClone);
			enemyClone.SetActive(false);
			enemyClone.tag = "Enemy";
			enemyClone.name = "Enemy";
		}
		
		// Adds 5 purple enemies to the purple enemy list
		for (int i = 0; i < 5; i++)
		{
			GameObject movingEnemyClone = Instantiate(Moving_Enemy);
			movingEnemyList.Add(movingEnemyClone);
			movingEnemyClone.SetActive(false);
			movingEnemyClone.tag = "Moving Enemy";
			movingEnemyClone.name = "Moving Enemy";
		}
		
		// Adds 5 Red enemies enemies to the red enemy list
		for (int i = 0; i < 5; i++)
		{
			GameObject ultimateMovingEnemyClone = Instantiate(Ultimate_Moving_Enemy);
			ultimateMovingEnemyList.Add(ultimateMovingEnemyClone);
			ultimateMovingEnemyClone.SetActive(false);
			ultimateMovingEnemyClone.tag = "Moving Enemy";
			ultimateMovingEnemyClone.name = "Moving Enemy";
		}
		
		// Adds 5 BumpWalls to the BumpWalls list
		for (int i = 0; i < 5; i++)
		{
			GameObject bumpWallClone = Instantiate(BumpWall);
			bumpWallList.Add(bumpWallClone);
			bumpWallClone.SetActive(false);
			bumpWallClone.tag = "BumpWall";
			bumpWallClone.name = "BumpWall";
		}
		
		// Adds 5 DownWalls to the DownWall list
		for (int i = 0; i < 5; i++)
		{
			GameObject downWallClone = Instantiate(DownWall);
			downWallList.Add(downWallClone);
			downWallClone.SetActive(false);
			downWallClone.tag = "DownWall";
			downWallClone.name = "DownWall";
		}
		
		// Adds 5 Shrinkers to the shrinker list
		for (int i = 0; i < 5; i++)
		{
			GameObject shrinkerClone = Instantiate(Shrinker);
			shrinkerList.Add(shrinkerClone);
			shrinkerClone.SetActive(false);
			shrinkerClone.tag = "Shrinker";
			shrinkerClone.name = "Shrinker";
		}
		
		// Adds 5 HourGlass' to the HourGlass list
		for (int i = 0; i < 5; i++)
		{
			GameObject hourGlassClone = Instantiate(HourGlass);
			hourGlassList.Add(hourGlassClone);
			hourGlassClone.SetActive(false);
			hourGlassClone.tag = "HourGlass";
			hourGlassClone.name = "HourGlass";
		}
	}
	
	// Update function for money spawning and keeping track of player position
	void Update()
	{
		if (PlayerPrefs.GetInt("InfoButton") == 100)
		{
			if (Time.timeScale == 0) return;
		
			spawnTimeMoney -= Time.deltaTime;
			spawnTimePowerUp -= Time.deltaTime;
			spawnTimeBumpWall -= Time.deltaTime;
			spawnTimeDownWall -= Time.deltaTime;
			
			if (whichEnemy == 0)
			{
				spawnTimeEnemy -= Time.deltaTime;
				enemiesTimer -= Time.deltaTime;
			}
			
			else if (whichEnemy == 1)
			{
				spawnTimeMovingEnemy -= Time.deltaTime;
				enemiesTimer -= Time.deltaTime;
			}
			
			else if (whichEnemy == 2)
			{
				int a = Random.Range(0, 2);
				int side;
				
				if (a == 0) side = 1;
				else side = -1;
				
				SpawnUltimateMovingEnemy(side);
				whichEnemy = 3;
			}
			
			else if (whichEnemy == 3) enemiesTimer -= Time.deltaTime;
			
			if (enemiesTimer <= 0f)
			{
				// This makes sure the previous enemy doesn't get chosen
				int prev = whichEnemy;
				do
				{
					whichEnemy = Random.Range(0, 3);
				} while (whichEnemy == prev);
				
				if (whichEnemy == 0 || whichEnemy == 1) enemiesTimer = 20f;
				
				else enemiesTimer = 10f;
			}
			
			if (spawnTimeBumpWall <= 0)
			{
				SpawnBumpWall();
				spawnTimeBumpWall = Random.Range(3f, 7f);
			}
			
			if (spawnTimeDownWall <= 0)
			{
				SpawnDownWall();
				spawnTimeDownWall = Random.Range(3f, 7f);
			}
			
			if (spawnTimeMoney <= 0)
			{
				SpawnMoney();
				spawnTimeMoney = Random.Range(0.5f, 1.0f);
			}
			
			if (spawnTimeEnemy <= 0)
			{
				SpawnEnemy();
				spawnTimeEnemy = Random.Range(0.9f, 1.2f);
			}
			
			if (spawnTimeMovingEnemy <= 0)
			{
				int side = Random.Range(0, 2);
				
				if (side == 0) SpawnMovingEnemy(-1);
				
				if (side == 1) SpawnMovingEnemy(1);
				
				spawnTimeMovingEnemy = Random.Range(0.75f, 1f);
			}
			
			if (spawnTimePowerUp <= 0)
			{
				int side = Random.Range(0, 2);
				
				if (side == 0)
				{
					SpawnShrinker();
					spawnTimePowerUp = Random.Range(8f, 13f);
				}
				
				if (side == 1)
				{
					SpawnHourGlass();
					spawnTimePowerUp = Random.Range(8f, 13f);
				}
			}
		}
	}
	
	
	// Spawn Enemy
	void SpawnEnemy()
	{
		int side = Random.Range(0, 4);
		
		if (side == 3)
		{
			if (!enemyList[enemySelector].activeInHierarchy)
			{ 
				enemyList[enemySelector].transform.localScale = new Vector3(0.06f, 0.06f, 0f);
				enemyList[enemySelector].transform.position = new Vector3(-0.6f, 9.5f, 0);
				enemyList[enemySelector].SetActive(true);
				enemySelector = (enemySelector + 1) % 20;
			}
			
			if (!enemyList[enemySelector].activeInHierarchy)
			{ 
				enemyList[enemySelector].transform.localScale = new Vector3(0.06f, 0.06f, 0f);
				enemyList[enemySelector].transform.position = new Vector3(0.6f, 9.5f, 0);
				enemyList[enemySelector].SetActive(true);
				enemySelector = (enemySelector + 1) % 20;
			}
		}
		
		else
		{
			if (side == 0) x_spawnPos_enemy = -0.6f;
		
			else if (side == 1) x_spawnPos_enemy = 0f;
		
			else if (side == 2) x_spawnPos_enemy = 0.6f;
		
			if (!enemyList[enemySelector].activeInHierarchy)
			{ 
				enemyList[enemySelector].transform.localScale = new Vector3(0.06f, 0.06f, 0f);
				enemyList[enemySelector].transform.position = new Vector3(x_spawnPos_enemy, 9.5f, 0);
				enemyList[enemySelector].SetActive(true);
				enemySelector = (enemySelector + 1) % 20;
			}
		}
	}
	
	// Spawn money function
	void SpawnMoney()
	{			
		x_spawnPos_money = Random.Range(-1.5f, 1.5f);
		
		if (!moneyList[moneySelector].activeInHierarchy)
		{ 
			moneyList[moneySelector].transform.localScale = new Vector3(0.05f, 0.05f, 0f);
			moneyList[moneySelector].transform.position = new Vector3(x_spawnPos_money, 9.5f, 0);
			moneyList[moneySelector].SetActive(true);
			moneySelector = (moneySelector + 1) % 20;
		}
	}
	
	// Spawn moving enemy
	void SpawnMovingEnemy(float side)
	{
		if (!movingEnemyList[movingEnemySelector].activeInHierarchy)
		{ 
			movingEnemyList[movingEnemySelector].transform.localScale = new Vector3(0.06f, 0.06f, 0f);
			movingEnemyList[movingEnemySelector].transform.position = new Vector3(side * 1.5f, 9.5f, 0);
			movingEnemyList[movingEnemySelector].SetActive(true);
			movingEnemySelector = (movingEnemySelector + 1) % 5;
		}
	}
	
	// Spawns Ultimate Enemy
	void SpawnUltimateMovingEnemy(float side)
	{
		if (!ultimateMovingEnemyList[ultimateMovingEnemySelector].activeInHierarchy)
		{ 
			ultimateMovingEnemyList[ultimateMovingEnemySelector].transform.localScale = new Vector3(0.06f, 0.06f, 0f);
			ultimateMovingEnemyList[ultimateMovingEnemySelector].transform.position = new Vector3(side * 1.5f, 8.5f, 0);
			ultimateMovingEnemyList[ultimateMovingEnemySelector].SetActive(true);
			ultimateMovingEnemySelector = (ultimateMovingEnemySelector + 1) % 5;
		}
	}
	
	// Spawn Shrinker
	void SpawnShrinker()
	{
		if (!shrinkerList[shrinkerSelector].activeInHierarchy)
		{ 
			shrinkerList[shrinkerSelector].transform.localScale = new Vector3(0.1f, 0.1f, 0f);
			shrinkerList[shrinkerSelector].transform.position = new Vector3(Random.Range(-1f, 1f), 8.5f, 0f);
			shrinkerList[shrinkerSelector].SetActive(true);
			shrinkerSelector = (shrinkerSelector + 1) % 5;
		}
	}
	
	// Spawn HourGlass
	void SpawnHourGlass()
	{
		if (!hourGlassList[hourGlassSelector].activeInHierarchy)
		{ 
			hourGlassList[hourGlassSelector].transform.localScale = new Vector3(0.1f, 0.1f, 0f);
			hourGlassList[hourGlassSelector].transform.position = new Vector3(Random.Range(-1f, 1f), 8.5f, 0f);
			hourGlassList[hourGlassSelector].SetActive(true);
			hourGlassSelector = (hourGlassSelector + 1) % 5;
		}
	}
	
	// Spawn Bump Wall
	void SpawnBumpWall()
	{
		if (!bumpWallList[bumpWallSelector].activeInHierarchy)
		{ 
			bumpWallList[bumpWallSelector].transform.localScale = new Vector3(0.15f, 0.15f, 0f);
			bumpWallList[bumpWallSelector].transform.position = new Vector3(Random.Range(-1f, 1f), 8.5f, 0f);
			bumpWallList[bumpWallSelector].SetActive(true);
			bumpWallSelector = (bumpWallSelector + 1) % 5;
		}
	}
	
	// Spawn Down Wall
	void SpawnDownWall()
	{
		if (!downWallList[downWallSelector].activeInHierarchy)
		{ 
			downWallList[downWallSelector].transform.localScale = new Vector3(0.15f, 0.15f, 0f);
			downWallList[downWallSelector].transform.position = new Vector3(Random.Range(-1f, 1f), 8.5f, 0f);
			downWallList[downWallSelector].SetActive(true);
			downWallSelector = (downWallSelector + 1) % 5;
		}
	}
}
