using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{	
	void Start()
	{
		Time.timeScale = 1f;
	}
	
	public void PlayGame()
	{
		SceneManager.LoadScene("SampleScene");
		PlayerPrefs.SetInt("WallScore", 0);
		if (PlayerPrefs.GetInt("InfoButton") != 100) PlayerPrefs.SetInt("InfoButton", 1); 
	}
	
	public void WipeData()
	{
		PlayerPrefs.SetInt("InfoButton", 1);
	}
	
	public void QuitGame()
	{
		Debug.Log("QUIT!");
		Application.Quit();
	}
}
