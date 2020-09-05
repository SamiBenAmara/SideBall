using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningBlade : MonoBehaviour
{
	// GameObjects
	public GameObject Blade;
	public GameObject BigBlade;
	GameObject Blade_Clone_Right;
	GameObject Blade_Clone_Left;
	GameObject BigBlade_Clone;
	
	
	/**** Functions ****/
	
	
	// Start Function
	void Start()
	{
		SpawnBlade();
	}
	
	// Spawning Function
	void SpawnBlade()
	{	
		for (float i = 1f; i < 2f; i++)
		{
			Blade_Clone_Left = Instantiate(Blade, new Vector3(-3.2f, i, 0f), Quaternion.identity);
			Blade_Clone_Left.name = "Blade";
			Blade_Clone_Left.tag = "Blade";
		}
		
		for (float i = 1f; i < 2f; i++)
		{
			Blade_Clone_Right = Instantiate(Blade, new Vector3(3.2f, i, 0f), Quaternion.identity);
			Blade_Clone_Right.name = "Blade";
			Blade_Clone_Right.tag = "Blade";
		}
		
		for (float i = -1.5f; i < 2.5f; i++)
		{
			BigBlade = Instantiate(BigBlade, new Vector3(i, -3f, 0f), Quaternion.identity);
			BigBlade.name = "Blade";
			BigBlade.tag = "Blade";
		}
	}
}
