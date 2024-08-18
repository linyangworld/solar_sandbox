using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDetector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 0 is for the left mouse button
        {
            // Create a ray from the camera to the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Perform a raycast to detect if the ray hits the Earth
            if (Physics.Raycast(ray, out hit))
            {
                // Check if the hit object is the Earth
                if (hit.transform == transform)
                {
                    Debug.Log("Clicked!");
                }
            }
        }
    }
}
