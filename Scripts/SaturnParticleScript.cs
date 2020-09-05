using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaturnParticleScript : MonoBehaviour
{
    // Particle Systems
	public ParticleSystem particle;
	
	
	/**** Functions ****/
	
	
	// Start function
    void Start()
    {
        particle.GetComponent<ParticleSystem>();
		
		if (PlayerPrefs.GetInt("Skin") == 3)
		{
			particle.Play();
		}
		
		else
		{
			particle.Stop();
		}
    }
	
	// Update function
	void Update()
	{
		transform.Rotate(0f, 3f * Time.timeScale, 0f, Space.World);
		transform.position = new Vector3(GameObject.FindWithTag("Player").transform.position.x, 1f, -1f);
	}
}
