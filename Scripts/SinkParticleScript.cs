using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkParticleScript : MonoBehaviour
{
    // Particle Systems
	public ParticleSystem particle;
	
	
	/**** Functions ****/
	
	
	// Start function
    void Start()
    {
        particle.GetComponent<ParticleSystem>();
		
		if (PlayerPrefs.GetInt("Skin") == 4)
		{
			particle.Play();
		}
		
		else
		{
			particle.Stop();
		}
    }
}
