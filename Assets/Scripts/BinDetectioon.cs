using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BinDetectioon : MonoBehaviour
{
    // Audio clip to play when the player throws an object through the trigger zone
    public AudioClip triggerSound;

    // UI Text element to display the popup message
    public Text textObject;

    // Time in seconds to display the text before it disappears
    public float displayDuration = 3f;

    // Time in seconds to display the "Well done" message before it disappears
    public float wellDoneDisplayDuration = 3f;

    // Total number of objects the player needs to throw into the trigger
    public int totalObjects = 10;

    private int objectsCount = 0;
    private AudioSource audioSource;
    private HashSet<GameObject> triggeredObjects = new HashSet<GameObject>();

    private void Start()
    {
        // Get the AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // If AudioSource is not found, add one to this GameObject
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Assign the audio clip to the AudioSource
        audioSource.clip = triggerSound;

        // Hide the text initially
        HideText();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Throwable") && !triggeredObjects.Contains(other.gameObject))
        {
            // Play the trigger sound
            if (audioSource != null && triggerSound != null)
            {
                audioSource.PlayOneShot(triggerSound);
            }

            // Increment the count of thrown objects
            objectsCount++;

            // Add the object to the triggered objects collection
            triggeredObjects.Add(other.gameObject);

            // Update the text with the current count
            UpdateText();

            // Check if all objects have been thrown into the trigger
            if (objectsCount >= totalObjects)
            {
                // All objects thrown, display "Well done" message
                DisplayWellDoneMessage();
            }
            else
            {
                // Show the text popup
                ShowText();

                // Start a coroutine to hide the text after a delay
                StartCoroutine(HideTextAfterDelay());
            }
        }
    }

    private IEnumerator HideTextAfterDelay()
    {
        // Wait for the specified duration
        yield return new WaitForSeconds(displayDuration);

        // Hide the text
        HideText();
    }

    private IEnumerator HideWellDoneAfterDelay()
    {
        // Wait for the specified duration
        yield return new WaitForSeconds(wellDoneDisplayDuration);

        // Hide the "Well done" message
        HideText();
    }

    private void UpdateText()
    {
        // Update the text to display the current count and total count
        textObject.text = objectsCount + " out of " + totalObjects;
    }

    private void ShowText()
    {
        // Show the text object
        textObject.gameObject.SetActive(true);
    }

    private void HideText()
    {
        // Hide the text object
        textObject.gameObject.SetActive(false);
    }

    private void DisplayWellDoneMessage()
    {
        // Display "Well done" message
        textObject.text = "Well done, Please return to Daisy!";
        ShowText();

        // Start a coroutine to hide the "Well done" message after a delay
        StartCoroutine(HideWellDoneAfterDelay());
    }
}