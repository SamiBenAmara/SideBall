using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/* InfoButton stages:
 * InfoButton = 1 -> Game just started, display tapHoldText
 * InfoButton = 2 -> Display stayWithinWallsText
 * InfoButton = 3 -> Activate DownArrow and UpArrow, bottom spikes, and arrowText
 * InfoButton = 4 -> Activate powerups and powerUpText
 * InfoButton = 5 -> Activate spikes and spikeText
 */

public class PauseMenu : MonoBehaviour
{		
	// Public variable that checks if game is paused // 
	public static bool GameIsPaused = false;
	
	// GameObjects //
	public GameObject pauseMenuUI;
	public GameObject deathMenuUI;
	public GameObject retryButton;
	public GameObject homeButton;
	public GameObject infoPanel;

	// Tutorial GameObjects 
	public GameObject tutorialButton;

	// General text objects // 
	public Text BestTimeText;
	public Text BestTime;
	public Text TimeScoreText;
	public Text TimeScore;
	public Text Coins;
	
	// Tutorial text objects //
	public Text tapHoldText;
	public Text stayWithinWallsText;
	public Text finalText;

	// Images // 
	public Image CoinImage;
	
	// Local variables // 
	private float deathTimer = 0.125f;
	private float buttonTimer = 0.5f;
	private float textTimer = 0.25f;
	private float numberTimer = 0.375f;
	private int death = 0;
	
	
	/**** Functions ****/
		
	
	// Start function
	void Start()
	{		
		tapHoldText.enabled = false;
		stayWithinWallsText.enabled = false;
		finalText.enabled = false;
		tutorialButton.SetActive(false);

		BestTimeText.GetComponent<Text>().enabled = false;
		BestTime.GetComponent<Text>().enabled = false;
		TimeScoreText.GetComponent<Text>().enabled = false;
		TimeScore.GetComponent<Text>().enabled = false;
		Coins.GetComponent<Text>().enabled = false;
		
		CoinImage.enabled = false;
		
		retryButton.SetActive(false);
		homeButton.SetActive(false);

		if (PlayerPrefs.GetInt("InfoButton") == 1)
		{
			Debug.Log("InfoButton Works");
			//InfoButton();
			//infoPanel.SetActive(true);
			PlayerPrefs.SetInt("Skin", 1);
			PlayerPrefs.SetInt("Money", 0);
			PlayerPrefs.SetFloat("HighScore", 0f);
			tapHoldText.enabled = true;
			tutorialButton.SetActive(true);
		}
	}
	
	// Update functions checks if game has been paused or not
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (!GameIsPaused) Pause();
			
			else Resume();
		}
		
		if (death == 1)
		{	
			deathTimer -= Time.deltaTime;
			buttonTimer -= Time.deltaTime;
			textTimer -= Time.deltaTime;
			numberTimer -= Time.deltaTime;
			
			if (deathTimer <= 0) deathMenuUI.SetActive(true);
			
			if (textTimer <= 0)
			{
				BestTimeText.GetComponent<Text>().enabled = true;
				TimeScoreText.GetComponent<Text>().enabled = true;
				CoinImage.enabled = true;
			}
			
			if (numberTimer <= 0)
			{
				BestTime.GetComponent<Text>().enabled = true;
				TimeScore.GetComponent<Text>().enabled = true;
				Coins.GetComponent<Text>().enabled = true;
			}
			
			if (buttonTimer <= 0)
			{
				retryButton.SetActive(true);
				homeButton.SetActive(true);
			}
		}
	}
	
	// Resume function 
	public void Resume()
	{
		pauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		GameIsPaused = false;
	}
	
	// Pause function
	public void Pause()
	{
		pauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
		GameIsPaused = true;
	}
	
	// Loading menu function
	public void LoadMenu()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene("MenuScene");
	}
	
	// Quit Game Button
	public void QuitGame()
	{
		Debug.Log("I QUIT");
		Application.Quit();
	}
	
	// Enabling function
	void OnEnable()
	{
		DeathMovement.youDied += YouAreDead;
		BottomDeathMovement.youDied += YouAreDead;
		EnemyMovementCollision.youDied += YouAreDead;
		MovingEnemyScript.youDied += YouAreDead;
		UltimateMovingEnemy.youDied += YouAreDead;
	}
	
	// Disabling function
	void OnDisable()
	{
		DeathMovement.youDied -= YouAreDead;
		BottomDeathMovement.youDied -= YouAreDead;
		EnemyMovementCollision.youDied -= YouAreDead;
		MovingEnemyScript.youDied -= YouAreDead;
		UltimateMovingEnemy.youDied -= YouAreDead;
	}
	
	// You died function
	void YouAreDead()
	{
		Time.timeScale = 0.25f;
		death = 1;
	}
	
	// Retry function
	public void Retry()
	{
		death = 0;
		retryButton.SetActive(false);
		homeButton.SetActive(false);
		SceneManager.LoadScene("SampleScene");
	}
	
	// Home button function
	public void Home() 
	{
		SceneManager.LoadScene("MenuScene");
	}
	
	// InfoButton function
	public void InfoButton()
	{
		Time.timeScale = 0f;
	}
	
	// Reset timeScale
	public void ResetTimeScale()
	{
		Time.timeScale = 1f;
	}

	public void NextButton()
	{
		int increment = PlayerPrefs.GetInt("InfoButton");
		increment++;
		PlayerPrefs.SetInt("InfoButton", increment);

		if (PlayerPrefs.GetInt("InfoButton") == 2)
		{
			tapHoldText.enabled = false;
			stayWithinWallsText.enabled = true;
		}

		else if (PlayerPrefs.GetInt("InfoButton") == 3)
		{
			stayWithinWallsText.enabled = false;
			finalText.enabled = true;
			Time.timeScale = 0f;
		}	

		else if (PlayerPrefs.GetInt("InfoButton") == 4)
		{
			tutorialButton.SetActive(false);
			PlayerPrefs.SetInt("InfoButton", 100);
			SceneManager.LoadScene("SampleScene");
		}	
	}
}