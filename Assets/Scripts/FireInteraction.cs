using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireInteraction : MonoBehaviour
{
    public AudioClip audioClip; // Reference to the extinguishing sound clip
    private AudioSource audioSource; // Reference to the AudioSource component

    void Start()
    {
        // Get the AudioSource component attached to the GameObject
        audioSource = GetComponent<AudioSource>();

        // Make sure the audio clip is assigned to the AudioSource
        if (audioClip !=null)
        {
            // Assign the audio clip to the AudioSource
            audioSource.clip = audioClip;
        }
    }

    void Update()
    {
        // Check if the player presses a specific key (e.g., "E" key)
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Check if the player is within range of the object
            // You can use additional checks here, like raycasting to determine if the player is close enough
            // For simplicity, let's assume the player just needs to be within a certain distance from the object
            float distance = Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position);
            if (distance < 3f) // Adjust the distance as needed
            {
                // Play the extinguishing sound
                audioSource.Play();

                // Remove the fire GameObject
                Destroy(gameObject);
            }
        }
    }
}