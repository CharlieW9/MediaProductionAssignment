using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FtoInteract : MonoBehaviour
{
    // Reference to the UI text object
    public GameObject interactionText;

    // Start is called before the first frame update
    void Start()
    {
        // Disable the interaction text at the start
        interactionText.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the collider entering the trigger is the player
        if (other.CompareTag("Player"))
        {
            // Enable the interaction text
            interactionText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Check if the collider exiting the trigger is the player
        if (other.CompareTag("Player"))
        {
            // Disable the interaction text
            interactionText.SetActive(false);
        }
    }
}