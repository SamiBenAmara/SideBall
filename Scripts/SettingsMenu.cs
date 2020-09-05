using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
	// Particle system
	public ParticleSystem particlesystem;
    
	// Audio Devices
	public AudioMixer audioMixer;
	
	// Public Texts
	public Text highScoreText;
	public Text moneyText;
	
	public void SetVolume(float volume)
	{
		audioMixer.SetFloat("volume", volume);
	}
	
	
	/**** Functions ****/
	
	
	// Start functions
	void Start()
	{
		if (PlayerPrefs.GetInt("InfoButton") != 100)
		{
			PlayerPrefs.SetInt("Skin", 1);
			PlayerPrefs.SetInt("Money", 0);
			PlayerPrefs.SetFloat("HighScore", 0f);
		}
	}
	
	// Update function
	void Update()
	{
		float highscore = PlayerPrefs.GetFloat("HighScore");
		highScoreText.text = highscore.ToString("F2");
		
		int money = PlayerPrefs.GetInt("Money");
		moneyText.text = money.ToString();
	}
}
