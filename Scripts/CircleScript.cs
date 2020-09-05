using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// PLAYERPREF DESCRIPTIONS:
/*
 * PLAYERPREF: "Rotation" --> 1 = Switch from left and right, 2 = Always Rotate
 * PLAYERPREF: "Skin" -->
 * 1 = SideBallLogoSkin
 * 2 = MoonSkin
 * 3 = SaturnSkin
 * 4 = SinkSkin
 * 5 = RainbowSkin
 * 6 = EarthSkin
 * 7 = SpinningOuterInnerSkin
 * 8 = SpiralSkin
 * 9 = DoubleDiskSkin
 * 10 = FireSkin
 */
 
 /* RotatePlayer variable -->
  * 0 = No Rotations
  * 1 = Changing from left to right
  * 2 = Rotating around the z axis (counterclockwise)
  * 3 = Rotating around the z axis (clockwise)
  * 4 = Rotating around the y axis
  */

public class CircleScript : MonoBehaviour
{	
	// Delegates and events
	public delegate void Direction();
	public static event Direction otherDirection;
	
	// SpriteRenderers
	public SpriteRenderer playerSpriteRenderer;
	
	// Sprites
	public Sprite SideBallLogoSkin;
	public Sprite MoonSkin;
	public Sprite SaturnSkin;
	public Sprite SinkSkinOuter;
	public Sprite SinkSkinInner;
	public Sprite RainbowSkin;
	public Sprite EarthSkinOuter;
	public Sprite EarthSkinInner;
	public Sprite SpinningOuterSkin;
	public Sprite SpinningInnerSkin;
	public Sprite SpinningCenterSkin;
	public Sprite SpiralSkin;
	public Sprite DoubleDiskSkin;
	public Sprite DoubleDiskSecondSkin;
	public Sprite FireSkin;

	// Public text UI elements
	public Text moneyText;
	public Text timerText;
	
	// Death Texts
	public Text moneyTextDeath;
	public Text bestTimeTextDeath;
	public Text timerTextDeath;
	
	// Colliders
	public CircleCollider2D playerCircleCollider2D;
	
	// Public Variables
	public float sideSpeed;
	public float sideSpeedFactor;
	public int money = 0;
	public int highscore = 0;
	public int score;
	
	// Local Variables
	private int side = 0;
	private int shrink = 0;
	private float shrinkTimer = 5f;
	private int direction = 1;
	private int hourglass = 0;
	private float hourglasstimer = 2.5f;
	private int death = 0;
	private float x_size = 0.09f;
	private float y_size = 0.09f;
	private float scoreTimer = 0f;
	private int rotatePlayer = 0;
	
	// Picks an initial value for side
	void Start()
	{
		// Setting Skins
		if (PlayerPrefs.GetInt("Skin") == 1)
		{
			this.GetComponent<SpriteRenderer>().sprite = SideBallLogoSkin;
			rotatePlayer = 1;
			Color32 newColor = new Color32((byte)255f, (byte)255f, (byte)255f, (byte)255f);
			playerSpriteRenderer.color = newColor;
		}
		
		if (PlayerPrefs.GetInt("Skin") == 2)
		{
			this.GetComponent<SpriteRenderer>().sprite = MoonSkin;
			rotatePlayer = 2;
			Color32 newColor = new Color32((byte)255f, (byte)255f, (byte)255f, (byte)255f);
			playerSpriteRenderer.color = newColor;
		}
		
		if (PlayerPrefs.GetInt("Skin") == 3)
		{
			this.GetComponent<SpriteRenderer>().sprite = SaturnSkin;
			rotatePlayer = 0;
			Color32 newColor = new Color32((byte)0f, (byte)255f, (byte)0f, (byte)255f);
			playerSpriteRenderer.color = newColor;
		}
		
		if (PlayerPrefs.GetInt("Skin") == 4)
		{
			this.GetComponent<SpriteRenderer>().sprite = SinkSkinOuter;
			rotatePlayer = 0;
			Color32 newColor = new Color32((byte)255f, (byte)255f, (byte)255f, (byte)255f);
			playerSpriteRenderer.color = newColor;
		}
		
		if (PlayerPrefs.GetInt("Skin") == 5)
		{
			this.GetComponent<SpriteRenderer>().sprite = RainbowSkin;
			rotatePlayer = 3;
			Color32 newColor = new Color32((byte)255f, (byte)255f, (byte)255f, (byte)255f);
			playerSpriteRenderer.color = newColor;
		}
		
		if (PlayerPrefs.GetInt("Skin") == 6)
		{
			this.GetComponent<SpriteRenderer>().sprite = EarthSkinOuter;
			rotatePlayer = 3;
			Color32 newColor = new Color32((byte)255f, (byte)255f, (byte)255f, (byte)255f);
			playerSpriteRenderer.color = newColor;
		}
		
		if (PlayerPrefs.GetInt("Skin") == 7)
		{
			this.GetComponent<SpriteRenderer>().sprite = SpinningOuterSkin;
			rotatePlayer = 2;
			Color32 newColor = new Color32((byte)255f, (byte)255f, (byte)255f, (byte)255f);
			playerSpriteRenderer.color = newColor;
		}
		
		if (PlayerPrefs.GetInt("Skin") == 8)
		{
			this.GetComponent<SpriteRenderer>().sprite = SpiralSkin;
			rotatePlayer = 2;
			Color32 newColor = new Color32((byte)154f, (byte)0f, (byte)255f, (byte)255f);
			playerSpriteRenderer.color = newColor;
		}
		
		if (PlayerPrefs.GetInt("Skin") == 9)
		{
			this.GetComponent<SpriteRenderer>().sprite = DoubleDiskSkin;
			rotatePlayer = 4;
			Color32 newColor = new Color32((byte)255f, (byte)255f, (byte)255f, (byte)255f);
			playerSpriteRenderer.color = newColor;
		}
		
		if (PlayerPrefs.GetInt("Skin") == 10)
		{
			this.GetComponent<SpriteRenderer>().sprite = FireSkin;
			rotatePlayer = 3;
			Color32 newColor = new Color32((byte)255f, (byte)255f, (byte)255f, (byte)255f);
			playerSpriteRenderer.color = newColor;
		}
		
		//PlayerPrefs.SetInt("WallScore", 0);
		Time.timeScale = 1f;
		//gameObject.GetComponent<Renderer>().enabled = true;
		gameObject.transform.localScale = new Vector3(0.09f, 0.09f, 0f);
		moneyText.text = PlayerPrefs.GetInt("Money").ToString();
		moneyTextDeath.text = PlayerPrefs.GetInt("Money").ToString();
		playerCircleCollider2D.enabled = true;
		
		side = Random.Range(0, 2);
		
		if (side == 0)
		{
			sideSpeed = -sideSpeed;
			
			if (PlayerPrefs.GetInt("Skin") == 1)
			{
				transform.Rotate(0, 0, Mathf.Lerp(0f, 360f, 0.5f));
			}
			
			if (PlayerPrefs.GetInt("Skin") == 6)
			{
				otherDirection();
			}
			
			direction = 0;
		}
		
		//load = 0;	
	}
	
	// Updates the velocity directions and color for the circle
    void Update()
    {	
		transform.Translate(sideSpeed * Time.timeScale, 0, 0, Space.World);
		transform.position = new Vector3(transform.position.x, 1f, transform.position.z);
		
		// Rotate the player on the z axis (counterclockwise)
		if (rotatePlayer == 2)
		{
			transform.Rotate(0f, 0f, 5f * Time.timeScale, Space.Self);
		}
		
		// Rotate the player on the z axis (clockwise)
		else if (rotatePlayer == 3)
		{
			if (PlayerPrefs.GetInt("Skin") == 5 || PlayerPrefs.GetInt("Skin") == 10)
			{
				transform.Rotate(0f, 0f, -3f * Time.timeScale, Space.Self);
			}
			
			else
			{
				transform.Rotate(0f, 0f, -5f * Time.timeScale, Space.Self);
			}
		}
		
		// Rotate the player on the y axis
		else if (rotatePlayer == 4)
		{
			transform.Rotate(0f, 3f * Time.timeScale, 0f, Space.Self);
		}
		
		timerText.text = scoreTimer.ToString("F2");
		timerTextDeath.text = scoreTimer.ToString("F2");
		
		if (death == 0)
		{
			scoreTimer += Time.deltaTime;
			timerText.text = scoreTimer.ToString("F2");
		}
		
		if (Input.GetMouseButton(0) && Time.timeScale != 0f)
		{
			transform.Translate(sideSpeedFactor * sideSpeed, 0, 0, Space.World);
		}			
		
		// Check if the game has been paused 
		if (Time.timeScale == 0) return;
		
		// Shrink when shrink power up is collected
		if (shrink == 1)
		{
			gameObject.transform.localScale = new Vector3(0.05f, 0.05f, 0f);
			shrinkTimer -= Time.deltaTime;
			
			if (shrinkTimer <= 0)
			{
				shrinkTimer = 5f;
				shrink = 0;
				gameObject.transform.localScale = new Vector3(0.09f, 0.09f, 0f);
			}
		}
		
		// Slow down time when hourglass is collected
		if (hourglass == 1 && death != 1)
		{
			Time.timeScale = 0.5f;
			hourglasstimer -= Time.deltaTime;
			
			if (hourglasstimer <= 0)
			{
				Time.timeScale = 1f;
				hourglasstimer = 2.5f;
				hourglass = 0;
			}
		}
		
		// HighScore function
		if (scoreTimer > PlayerPrefs.GetFloat("HighScore"))
		{
			PlayerPrefs.SetFloat("HighScore", scoreTimer);
			bestTimeTextDeath.text = PlayerPrefs.GetFloat("HighScore").ToString("F2");
		}
		
		// Shrink size animation when you die
		if (death == 1)
		{
			gameObject.transform.localScale = new Vector3(x_size, y_size, 0f);
			x_size -= 0.005f;
			y_size -= 0.005f;
			
			if (x_size <= 0)
			{
				PlayerPrefs.SetInt("WallScore", 0);
				death = 2;
				//gameObject.GetComponent<Renderer>().enabled = false;
				transform.position = new Vector3(-50f, 0f, 0f);
			}
		}
    }
	
	// Function that adds the event of the player hitting the and right walls
	void OnEnable()
	{
		LeftCloneCollision.hitLeftWall += ChangeSideLeft;
		RightCloneCollision.hitRightWall += ChangeSideRight;
		MoneyMovementCollision.Counter += MoneyCounter;
		DeathMovement.youDied += YouAreDead;
		EnemyMovementCollision.youDied += YouAreDead;
		MovingEnemyScript.youDied += YouAreDead;
		BottomDeathMovement.youDied += YouAreDead;
		UltimateMovingEnemy.youDied += YouAreDead;
		ShrinkerScript.getSmaller += Shrink;
		HourglassScript.slowDown += HourGlass;
	}
	
	// Disable function that counters enable function
	void OnDisable()
	{
		LeftCloneCollision.hitLeftWall -= ChangeSideLeft;
		RightCloneCollision.hitRightWall -= ChangeSideRight;
		MoneyMovementCollision.Counter -= MoneyCounter;
		DeathMovement.youDied -= YouAreDead;
		EnemyMovementCollision.youDied -= YouAreDead;
		MovingEnemyScript.youDied -= YouAreDead;
		BottomDeathMovement.youDied -= YouAreDead;
		UltimateMovingEnemy.youDied -= YouAreDead;
		ShrinkerScript.getSmaller -= Shrink;
		HourglassScript.slowDown -= HourGlass;
	}
	
	// Changes ball direction and adds to the score when the ball hits the left wall
	void ChangeSideLeft()
	{
		if (direction == 0)
		{
			sideSpeed = -sideSpeed;
			
			// Default skin rotation
			if (rotatePlayer == 1) transform.Rotate(0, 0, Mathf.Lerp(0f, 360f, 0.5f));
			
			// Earth Skin Rotation
			if (PlayerPrefs.GetInt("Skin") == 6) otherDirection();
			
			direction = 1;
			side = 1;
		}
	}
	
	// Changes the ball direction and adds to the socre when the ball hits the right wall
	void ChangeSideRight()
	{
		if (direction == 1)
		{
			sideSpeed = -sideSpeed;
			
			// Default skin rotation
			if (rotatePlayer == 1) transform.Rotate(0, 0, Mathf.Lerp(0f, 360f, 0.5f));
			
			// Earth Skin Rotation
			if (PlayerPrefs.GetInt("Skin") == 6) otherDirection();
			
			direction = 0;
			side = 0;
		}
	}
	
	// Adds money
	void MoneyCounter()
	{
		int moneyCounter = PlayerPrefs.GetInt("Money");
		moneyCounter++;
		PlayerPrefs.SetInt("Money", moneyCounter);
		moneyText.text = moneyCounter.ToString();
		moneyTextDeath.text = moneyCounter.ToString();
	}
	
	// You died function
	void YouAreDead()
	{	
		Time.timeScale = 1f;
		death = 1;
		bestTimeTextDeath.text = PlayerPrefs.GetFloat("HighScore").ToString("F2");
		//SaveSystem.SavePlayer(this);	
	}
	
	// Shrink the ball
	void Shrink()
	{
		shrink = 1;
		shrinkTimer = 5f;
	}
	
	// Slows down time
	void HourGlass()
	{
		hourglass = 1;
	}
	
	// Load Progress function
	//public void LoadPlayer()
	//{
	//	SaveData data = SaveSystem.LoadPlayer();
		//money = data.money;
	//}
	
	// WallScore function
	//if (score >= PlayerPrefs.GetInt("WallScore"))
	//{
	//	PlayerPrefs.SetInt("WallScore", score);
	//}
	
	// Load the saved data
	//if (load == 0)
	//{
	//	LoadPlayer();
	//	moneyText.text = money.ToString();
	//	load = 1;
	//}
	
	// Grow when grow power up collected
	/*if (shrink == 2)
	{
		gameObject.transform.localScale = new Vector3(0.12f, 0.12f, 0f);
		growTimer -= Time.deltaTime;
		
		if (growTimer <= 0)
		{
			growTimer = 5f;
			shrink = 0;
			gameObject.transform.localScale = new Vector3(0.09f, 0.09f, 0f);
		}
	}
	
	// Grows the ball
	//void Grow()
	//{
	//	shrink = 2;
		//growTimer = 5f;
	//}*/
}