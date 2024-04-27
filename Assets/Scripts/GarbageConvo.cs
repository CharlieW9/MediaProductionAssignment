using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class GarbageConvo : MonoBehaviour
{
    [SerializeField] private NPCConversation myConversation;
    private Collider triggerCollider; // Reference to the collider component
    private bool conversationStarted = false; // Flag to track if conversation has started

    private void Start()
    {
        triggerCollider = GetComponent<Collider>(); // Get the collider component
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && !conversationStarted) // Check if conversation is not already started
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                ConversationManager.Instance.StartConversation(myConversation);
                Cursor.lockState = CursorLockMode.None;

                // Disable the collider so the trigger can't activate again
                triggerCollider.enabled = false;

                // Set the flag to true, indicating that the conversation has started
                conversationStarted = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; // Hide the cursor
    }
}