using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class InterstitialAdsScript : MonoBehaviour 
{ 
   	string gameId = "1234567";
   	bool testmode = true;

   	void Start ()
   	{
   		Advertisement.Initialize (gameId, testmode);
   	}

   	void Update()
   	{
   		if (Time.timeScale != 0) showAd();
   	}

   	void showAd()
   	{
   		Advertisement.Show ();
   	}
}