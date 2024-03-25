using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Material unEarthlyRed; // Reference to the burnt forest skybox material
    public Material defaultSkyboxMaterial; // Reference to the default skybox material (for the lush forest)

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            RenderSettings.skybox = unEarthlyRed; // Change the skybox material to the burnt forest material
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            RenderSettings.skybox = defaultSkyboxMaterial; // Change the skybox material back to the default material when exiting the trigger volume
        }
    }
}