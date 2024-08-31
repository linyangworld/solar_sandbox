using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyDrag : MonoBehaviour
{
    private bool isDragging = false;
    private float zOffset; // Offset in the Z-axis from the camera to the object
    private Rigidbody rb;
    private Vector3 rbVelocity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("No Rigidbody attached to the CelestialBody");
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit; // ?? what is this
            
            if (Physics.Raycast(ray, out hit) && hit.transform == transform)
            {
                isDragging = true;
                rbVelocity = rb.velocity;
                rb.isKinematic = true;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false; 
            rb.isKinematic = false;
            rb.velocity = rbVelocity;
        }        

        if (isDragging)
        {
            zOffset = Camera.main.WorldToScreenPoint(transform.position).z; // ??
            FollowMouse();
        }     
    }

    void FollowMouse()
    {
        // Get the current mouse position in screen space
         Vector3 mouseScreenPosition = Input.mousePosition;

        // Convert the mouse position to world space, assuming a constant distance from the camera
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mouseScreenPosition.x, mouseScreenPosition.y, zOffset));

        // Update the object's position to the mouse's world position
        transform.position = mouseWorldPosition;
    }
}
