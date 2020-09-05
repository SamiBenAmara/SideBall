using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleColorShop : MonoBehaviour
{
	// Particle system
	public ParticleSystem particle;
	
	// Public variables
	public int shop;
	
	// Local variables
	private float colorTimer = 0.75f;
	private float R = 0;
	private float G = 0;
	private float B = 0;
	private int prev;
	private int color;
	private int switchcolor;
	
	
	/**** Functions ****/
	

	// Start function
	void Start()
	{
		particle = GetComponent<ParticleSystem>();
		
		switchcolor = Random.Range(0, 6);
		prev = switchcolor;
			
		// Red
		if (switchcolor == 0)
		{
			R = 255;
			G = 0;
			B = 0;
		}
			
		// 
		if (switchcolor == 1)
		{
			R = 0;
			G = 225;
			B = 255;
		}
			
		if (switchcolor == 2)
		{
			R = 7;
			G = 255;
			B = 0;
		}
			
		if (switchcolor == 3)
		{
			R = 253;
			G = 255;
			B = 0;
		}
			
		if (switchcolor == 4)
		{
			R = 230;
			G = 0;
			B = 255;
		}
			
		if (switchcolor == 5)
		{
			R = 255;
			G = 134;
			B = 0;
		}
			
		if (PlayerPrefs.GetInt("Shop") == 1)
		{
			particle.Play();
		}
		
		else if (PlayerPrefs.GetInt("Shop") == 2)
		{
			if (PlayerPrefs.GetInt("Skin") == 5)
			{
				particle.Play();
			}	
			
			else
			{
				particle.Stop();
			}
		}
			
		else
		{
			particle.Stop();
		}
	
			
		// Takes in 4 arguements towards changing ball color, RGB and alpha
		Color32 newColor = new Color32((byte)R, (byte)G, (byte)B, (byte)255f);
			
		particle.startColor = new Color32((byte)R, (byte)G, (byte)B, (byte)255f);;
		
		colorTimer = 0.75f;
	}
	
    // Update function
    void Update()
    {
        colorTimer -= Time.deltaTime;
		
		// Change colour randomly every 0.75 seconds
		if (colorTimer <= 0)
		{	
			Color();
		}
    }
	
	// Colour function
	void Color()
	{
		// Making sure consecutive colours aren't the same
		do
		{
			switchcolor = Random.Range(0, 6);
		} while (prev == switchcolor);
			
		prev = switchcolor;
			
		// Red
		if (switchcolor == 0)
		{
			R = 255;
			G = 0;
			B = 0;
		}
			
		// 
		if (switchcolor == 1)
		{
			R = 0;
			G = 225;
			B = 255;
		}
			
		if (switchcolor == 2)
		{
			R = 7;
			G = 255;
			B = 0;
		}
		
		if (switchcolor == 3)
		{
			R = 253;
			G = 255;
			B = 0;
		}
			
		if (switchcolor == 4)
		{
			R = 230;
			G = 0;
			B = 255;
		}
			
		if (switchcolor == 5)
		{
			R = 255;
			G = 134;
			B = 0;
		}
			
			
		// Takes in 4 arguements towards changing ball color, RGB and alpha
		Color32 newColor = new Color32((byte)R, (byte)G, (byte)B, (byte)255f);
			
		particle.startColor = new Color32((byte)R, (byte)G, (byte)B, (byte)255f);;
			
		colorTimer = 0.75f;
	}
}
