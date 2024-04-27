using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeFire : MonoBehaviour

{
    public ParticleSystem smokeParticleSystem; // Reference to the ParticleSystem component for the smoke particle effect

    void Update()
    {
        // Check if the player presses a specific key (e.g., "E" key)
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Check if the particle system is assigned
            if (smokeParticleSystem != null)
            {
                // Instantiate the smoke particle effect at the current position
                ParticleSystem instantiatedSmoke = Instantiate(smokeParticleSystem, transform.position, Quaternion.identity);
                
                // Rotate the instantiated particle system to match the original rotation
                instantiatedSmoke.transform.rotation = smokeParticleSystem.transform.rotation;
            }
            else
            {
                Debug.LogWarning("Smoke ParticleSystem is not assigned.");
            }
        }
    }
}