using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTextPopup : MonoBehaviour
{   
    public GameObject ui;
    private bool uiVisible = false; // Flag to track whether the UI is currently visible
    private bool uiDismissed = false; // Flag to track whether the UI has been dismissed

    void Start()
    {
        HideUI();
    }

    void Update()
    {
        // Check if the player presses the "E" key
        if (Input.GetKeyDown(KeyCode.E) && uiVisible && !uiDismissed)
        {
            HideUI(); // Hide the UI if it's currently visible
            uiDismissed = true; // Update the flag to indicate that the UI has been dismissed
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !uiDismissed)
        {
            ShowUI();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player") && !uiDismissed)
        {
            HideUI(); // Hide the UI if the player leaves the box collider without pressing "E"
        }
    }

    public void HideUI()
    {
        ui.SetActive(false);
        uiVisible = false; // Update the flag to indicate that the UI is no longer visible
    }

    public void ShowUI()
    {
        ui.SetActive(true);
        uiVisible = true; // Update the flag to indicate that the UI is now visible
    }
}