using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIvoiceOver : MonoBehaviour
{
    public AudioClip soundEffect;
    public float volume = 1.0f;

    private AudioSource audioSource;
    private bool hasPlayed = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = soundEffect;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider entering the trigger zone is the player
        if (other.CompareTag("Player") && !hasPlayed)
        {
            // Play the sound effect
            audioSource.PlayOneShot(soundEffect, volume);
            hasPlayed = true;
        }
    }

    // If you want to play the sound when the player exits the trigger zone,
    // you can use OnTriggerExit method similarly.
}