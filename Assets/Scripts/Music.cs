using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioClip musicClip;
    public float volume = 1.0f;
    public float fadeInDuration = 1.0f; // Duration for the music fade-in
    public float fadeOutDuration = 1.0f; // Duration for the music fade-out

    private AudioSource audioSource;
    private bool isPlayerInside = false;
    private bool isFadingOut = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = musicClip;
        audioSource.volume = 0; // Start with zero volume
    }

    private void Update()
    {
        if (isPlayerInside)
        {
            // Fade in the music
            if (audioSource.volume < volume)
            {
                float fadeSpeed = volume / fadeInDuration;
                audioSource.volume += fadeSpeed * Time.deltaTime;
                audioSource.volume = Mathf.Min(audioSource.volume, volume);
            }
        }
        else if (isFadingOut && audioSource.isPlaying && audioSource.volume > 0)
        {
            // Fade out the music
            float fadeSpeed = volume / fadeOutDuration;
            audioSource.volume -= fadeSpeed * Time.deltaTime;
            audioSource.volume = Mathf.Max(audioSource.volume, 0);

            // If volume reaches 0, stop the music and reset flags
            if (audioSource.volume <= 0)
            {
                audioSource.Stop();
                isFadingOut = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = true;
            if (!audioSource.isPlaying)
            {
                // Start playing the music if it's not already playing
                audioSource.Play();
            }
            isFadingOut = false; // Cancel any ongoing fade-out
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = false;
            isFadingOut = true; // Start fading out the music
        }
    }
}