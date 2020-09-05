using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireParticleScript : MonoBehaviour
{
	// Particle System
	public ParticleSystem particle;
   
   
	/**** Functions ****/
	
	
	// Start function
    void Start()
    {
        particle = GetComponent<ParticleSystem>();
		
		if (PlayerPrefs.GetInt("Skin") == 10)
		{
			particle.Play();
		}
		
		else
		{
			particle.Stop();
		}
    }
}
