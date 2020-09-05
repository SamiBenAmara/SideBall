using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreMenuScript : MonoBehaviour
{
	// Sprites
	public Sprite checkMarkSprite;
	
	// Public Texts
	public Text money;
	public Text time;
	
	// Timer Texts
	public Text MoonSkinText;
	public Text SaturnSkinText;
	public Text SinkSkinText;
	public Text RainbowSkinText;
	public Text EarthText;
	public Text OuterInnerText;
	public Text SpiralText; 
	public Text DoubleDiskText;
	public Text FireText;
	
	// Buttons
	public GameObject SideBallLogoSkinButton;
	public GameObject MoonSkinButton;
	public GameObject SaturnSkinButton;
	public GameObject SinkSkinButton;
	public GameObject RainbowSkinButton;
	public GameObject EarthSkinButton;
	public GameObject SpinningOuterInnerSkinButton;
	public GameObject SpiralSkinButton;
	public GameObject DoubleDiskSkinButton;
	public GameObject FireSkinButton;
	public GameObject SkinsButton;
	public GameObject BackButton;
	
	
	/**** Functions ****/
	
	
	// Start function
	void Start()
	{
		// Check the Moon Skin Button sprites
		if (PlayerPrefs.GetInt("purchasedMoonSkin") == 1)
		{
			MoonSkinText.enabled = false;
			MoonSkinButton.GetComponent<Image>().sprite = checkMarkSprite;
		}
		
		// Check the Saturn Skin Button sprites
		if (PlayerPrefs.GetInt("purchasedSaturnSkin") == 1)
		{
			SaturnSkinText.enabled = false;
			SaturnSkinButton.GetComponent<Image>().sprite = checkMarkSprite;
		}
		
		// Check the Sink Skin Button sprites
		if (PlayerPrefs.GetInt("purchasedSinkSkin") == 1)
		{
			SinkSkinText.enabled = false;
			SinkSkinButton.GetComponent<Image>().sprite = checkMarkSprite;
		}
		
		// Check the Rainbow Skin Button sprites
		if (PlayerPrefs.GetInt("purchasedRainbowSkin") == 1)
		{
			RainbowSkinText.enabled = false;
			RainbowSkinButton.GetComponent<Image>().sprite = checkMarkSprite;
		}
		
		// Check the Earth Skin Button sprites
		if (PlayerPrefs.GetFloat("HighScore") >= 30.0)
		{
			EarthText.enabled = false;
			EarthSkinButton.GetComponent<Image>().sprite = checkMarkSprite;
		}
		
		// Check the Inner Outer Skin Button sprites
		if (PlayerPrefs.GetFloat("HighScore") >= 60.0)
		{
			OuterInnerText.enabled = false;
			SpinningOuterInnerSkinButton.GetComponent<Image>().sprite = checkMarkSprite;
		}
		
		// Check the Spiral Skin Button sprites
		if (PlayerPrefs.GetFloat("HighScore") >= 90.0)
		{
			SpiralText.enabled = false;
			SpiralSkinButton.GetComponent<Image>().sprite = checkMarkSprite;
		}
		
		// Check the Moon Skin Button sprites
		if (PlayerPrefs.GetFloat("HighScore") >= 120.0)
		{
			DoubleDiskText.enabled = false;
			DoubleDiskSkinButton.GetComponent<Image>().sprite = checkMarkSprite;
		}
		
		// Check the Moon Skin Button sprites
		if (PlayerPrefs.GetFloat("HighScore") >= 150.0)
		{
			FireText.enabled = false;
			FireSkinButton.GetComponent<Image>().sprite = checkMarkSprite;
		}
	}
	
	// Update function
	void Update()
	{
		// Update the counters on the different panels
		money.text = PlayerPrefs.GetInt("Money").ToString();
		time.text = PlayerPrefs.GetFloat("HighScore").ToString("F2");
		
		
		/**** Updating Button States in the Shop ****/
		
		
		// SideBall Logo Skin Button(Don't need to check whether this was purchased or not because it's the default skin
		if (PlayerPrefs.GetInt("Skin") == 1) SideBallLogoSkinButton.SetActive(false);
		
		else SideBallLogoSkinButton.SetActive(true);
		
		// Moon Skin Button
		if (PlayerPrefs.GetInt("purchasedMoonSkin") == 1)
		{
			if (PlayerPrefs.GetInt("Skin") == 2) MoonSkinButton.SetActive(false);
			
			else MoonSkinButton.SetActive(true);
		}
		
		// Saturn Skin Button
		if (PlayerPrefs.GetInt("purchasedSaturnSkin") == 1)
		{
			if (PlayerPrefs.GetInt("Skin") == 3)
			{	
				SaturnSkinButton.SetActive(false);
			}
			
			else
			{
				SaturnSkinButton.SetActive(true);
			}
		}
		
		// Sink Skin Button
		if (PlayerPrefs.GetInt("purchasedSinkSkin") == 1)
		{
			if (PlayerPrefs.GetInt("Skin") == 4)
			{	
				SinkSkinButton.SetActive(false);
			}
			
			else
			{
				SinkSkinButton.SetActive(true);
			}
		}
		
		// Rainbow Skin Button
		if (PlayerPrefs.GetInt("purchasedRainbowSkin") == 1)
		{
			if (PlayerPrefs.GetInt("Skin") == 5)
			{	
				RainbowSkinButton.SetActive(false);
			}
			
			else
			{
				RainbowSkinButton.SetActive(true);
			}
		}
		
		// Earth Skin Button
		if (PlayerPrefs.GetInt("Skin") == 6)
		{	
			EarthSkinButton.SetActive(false);
		}
		
		else
		{
			EarthSkinButton.SetActive(true);
		}
		
		// Outer Inner Skin Button
		if (PlayerPrefs.GetInt("Skin") == 7)
		{	
			SpinningOuterInnerSkinButton.SetActive(false);
		}
		
		else
		{
			SpinningOuterInnerSkinButton.SetActive(true);
		}
		
		// Spiral Skin Button
		if (PlayerPrefs.GetInt("Skin") == 8)
		{	
			SpiralSkinButton.SetActive(false);
		}
		
		else
		{
			SpiralSkinButton.SetActive(true);
		}
		
		// Double Disk Skin Button
		if (PlayerPrefs.GetInt("Skin") == 9)
		{	
			DoubleDiskSkinButton.SetActive(false);
		}
		
		else
		{
			DoubleDiskSkinButton.SetActive(true);
		}
		
		// Fire Skin Button
		if (PlayerPrefs.GetInt("Skin") == 10)
		{	
			FireSkinButton.SetActive(false);
		}
		
		else
		{
			FireSkinButton.SetActive(true);
		}
	}
	
	
	/**** Purchase Functions ****/
	
	
	// SideBall Logo Button
	public void sideBallLogoButton()
	{
		PlayerPrefs.SetInt("Skin", 1);
	}
	
	// Moon Skin Purchase Function
	public void purchasedMoonSkinButton()
	{
		if (PlayerPrefs.GetInt("purchasedMoonSkin") == 0)
		{
			if (PlayerPrefs.GetInt("Money") >= 100)
			{
				PlayerPrefs.SetInt("purchasedMoonSkin", 1);
				int money = PlayerPrefs.GetInt("Money");
				money -= 100;
				PlayerPrefs.SetInt("Money", money);
				MoonSkinText.enabled = false;
				MoonSkinButton.GetComponent<Image>().sprite = checkMarkSprite;
			}
		}
		
		else 
		{
			PlayerPrefs.SetInt("Skin", 2);
			MoonSkinButton.SetActive(false);
		}
	}
	
	// Saturn Skin Purchase Function
	public void purchasedSaturnSkinButton()
	{
		if (PlayerPrefs.GetInt("purchasedSaturnSkin") == 0)
		{
			if (PlayerPrefs.GetInt("Money") >= 500)
			{
				PlayerPrefs.SetInt("purchasedSaturnSkin", 1);
				int money = PlayerPrefs.GetInt("Money");
				money -= 500;
				PlayerPrefs.SetInt("Money", money);
				SaturnSkinText.enabled = false;
				SaturnSkinButton.GetComponent<Image>().sprite = checkMarkSprite;
			}
		}
		
		else 
		{
			PlayerPrefs.SetInt("Skin", 3);
			SaturnSkinButton.SetActive(false);
		}
	}
	
	// Sink Skin Purchase Function
	public void purchasedSinkSkinButton()
	{
		if (PlayerPrefs.GetInt("purchasedSinkSkin") == 0)
		{
			if (PlayerPrefs.GetInt("Money") >= 1000)
			{
				PlayerPrefs.SetInt("purchasedSinkSkin", 1);
				int money = PlayerPrefs.GetInt("Money");
				money -= 1000;
				PlayerPrefs.SetInt("Money", money);
				SinkSkinText.enabled = false;
				SinkSkinButton.GetComponent<Image>().sprite = checkMarkSprite;
			}
		}
		
		else 
		{
			PlayerPrefs.SetInt("Skin", 4);
			SinkSkinButton.SetActive(false);
		}
	}
	
	// Rainbow Skin Purchase Function
	public void purchasedRainbowSkinButton()
	{
		if (PlayerPrefs.GetInt("purchasedRainbowSkin") == 0)
		{
			if (PlayerPrefs.GetInt("Money") >= 5000)
			{
				PlayerPrefs.SetInt("purchasedRainbowSkin", 1);
				int money = PlayerPrefs.GetInt("Money");
				money -= 5000;
				PlayerPrefs.SetInt("Money", money);
				RainbowSkinText.enabled = false;
				RainbowSkinButton.GetComponent<Image>().sprite = checkMarkSprite;
			}
		}
		
		else 
		{
			PlayerPrefs.SetInt("Skin", 5);
			RainbowSkinButton.SetActive(false);
		}
	}
	
	
	/**** Time Unlock Functions ****/
	
	
	// Earth Skin Button function
	public void unlockEarthSkinButton()
	{
		if (PlayerPrefs.GetFloat("HighScore") >= 30.0)
		{
			PlayerPrefs.SetInt("Skin", 6);
		}
	}
	
	// Outer Inner Skin Button function
	public void unlockOuterInnerSkinButton()
	{
		if (PlayerPrefs.GetFloat("HighScore") >= 60.0)
		{
			PlayerPrefs.SetInt("Skin", 7);
		}
	}
	
	// Spiral Skin Button function
	public void unlockSpiralSkinButton()
	{
		if (PlayerPrefs.GetFloat("HighScore") >= 90.0)
		{
			PlayerPrefs.SetInt("Skin", 8);
		}
	}
	
	// Double Disk Skin Button function
	public void unlockDoubleDiskSkinButton()
	{
		if (PlayerPrefs.GetFloat("HighScore") >= 120.0)
		{
			PlayerPrefs.SetInt("Skin", 9);
		}
	}
	
	// Fire Skin Button function
	public void unlockFireSkinButton()
	{
		if (PlayerPrefs.GetFloat("HighScore") >= 150.0)
		{
			PlayerPrefs.SetInt("Skin", 10);
		}
	}
	
	
	/**** Skins Panel ****/
	
	
	// SkinsButton function
	public void SkinsButtonFunction()
	{
		PlayerPrefs.SetInt("Shop", 1);
	}
	
	// BackButton function
	public void BackButtonFunction()
	{
		PlayerPrefs.SetInt("Shop", 2);
	}
}
