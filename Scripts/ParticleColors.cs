using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleColors : MonoBehaviour
{	
	// Public spriterenderers
	public SpriteRenderer right;
	public SpriteRenderer left;
	
	// Local variables
	private float colorTimer = 10f;
	private int R = 0;
	private int G = 0;
	private int B = 0;
	private int prev;
	private int color;
	private int switchcolor;
	
	
	/**** Functions ****/
	

	// Start function
	void Start()
	{
		//particle = GetComponent<ParticleSystem>();
		
		switchcolor = Random.Range(0, 6);
		prev = switchcolor;
			
		// Red
		if (switchcolor == 0)
		{
			R = 255;
			G = 0;
			B = 0;
		}
			
		// Light Blue
		if (switchcolor == 1)
		{
			R = 0;
			G = 225;
			B = 255;
		}
			
		// Green
		if (switchcolor == 2)
		{
			R = 7;
			G = 255;
			B = 0;
		}
			
		// Yellow
		if (switchcolor == 3)
		{
			R = 253;
			G = 255;
			B = 0;
		}
			
		// Purple
		if (switchcolor == 4)
		{
			R = 230;
			G = 0;
			B = 255;
		}
		
		// Orange
		if (switchcolor == 5)
		{
			R = 255;
			G = 134;
			B = 0;
		}
			
		PlayerPrefs.SetInt("R", R);
		PlayerPrefs.SetInt("G", G);
		PlayerPrefs.SetInt("B", B);
		// Takes in 4 arguements towards changing ball color, RGB and alpha
		Color32 newColor = new Color32((byte)R, (byte)G, (byte)B, (byte)255f);
	
		right.color = newColor;
		left.color = newColor;
	}
	
    // Update function
    void Update()
    {
        colorTimer -= Time.deltaTime;
		// Change colour randomly every ten seconds
		if (colorTimer <= 0f) Color();
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
			
		// Light Blue
		if (switchcolor == 1)
		{
			R = 0;
			G = 225;
			B = 255;
		}
			
		// Green
		if (switchcolor == 2)
		{
			R = 7;
			G = 255;
			B = 0;
		}
		
		// Yellow
		if (switchcolor == 3)
		{
			R = 253;
			G = 255;
			B = 0;
		}
			
		// Purple
		if (switchcolor == 4)
		{
			R = 230;
			G = 0;
			B = 255;
		}
			
		// Orange
		if (switchcolor == 5)
		{
			R = 255;
			G = 134;
			B = 0;
		}
			
		PlayerPrefs.SetInt("R", R);
		PlayerPrefs.SetInt("G", G);
		PlayerPrefs.SetInt("B", B);
		// Takes in 4 arguements towards changing ball color, RGB and alpha
		Color32 newColor = new Color32((byte)R, (byte)G, (byte)B, (byte)255f);
	
		right.color = newColor;
		left.color = newColor;
			
		colorTimer = 10f;
	}
}
