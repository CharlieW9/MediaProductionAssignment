using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour
{
    public Material highlightMaterial; // Assign your highlight material in the inspector
    private Material originalMaterial;
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        originalMaterial = rend.material;
    }

    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject == gameObject)
            {
                // Object is being looked at, apply highlight material
                rend.material = highlightMaterial;
            }
            else
            {
                // Object is not being looked at, revert to original material
                rend.material = originalMaterial;
            }
        }
    }
}
