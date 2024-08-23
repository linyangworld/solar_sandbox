using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelestrialBody : MonoBehaviour
{
    public Vector3 InitialVelocity;

    private Rigidbody rb;
    private const float G = 1f;

    private static List<CelestrialBody> allBodies = new List<CelestrialBody>(); // ?? How to use List<>


    void Awake() // This method is called once when the script instance is being loaded, which happens before the game starts and before any Start() methods are called. 
    {
        rb = GetComponent<Rigidbody>();

        if (rb == null)
        {
            Debug.LogError("No Rigidbody attached to the CelestialBody");
            return;
        }

        allBodies.Add(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (rb != null)
        {
            rb.velocity = InitialVelocity; //?? how do you know there is a velocity property
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() //?? how do you know this is the existing function 
    {
        if (rb != null && !rb.isKinematic)
        {
            foreach (var otherBody in allBodies)
            {
                if (otherBody != this && otherBody.rb != null)
                {
                    ApplyGravity(otherBody);
                }
            }
        } 
    }

    private void ApplyGravity(CelestrialBody otherBody)
    {
        Rigidbody otherRb = otherBody.rb;

        // Calculate the direction and distance to the other body
        Vector3 direction = otherRb.position - rb.position;
        float distance = direction.magnitude; // ?? Vector3.sqrMagnitude

        // Avoid division by zero or applying forces at extremely close distances
        if (distance == 0f)
        {
            return;
        }

        direction.Normalize();

        float forceMagnitude = (G * rb.mass * otherRb.mass) / (distance * distance);

        Vector3 force = direction * forceMagnitude;
        rb.AddForce(force);

        // Debug.DrawLine(rb.position, force);
    }

    void OnDestroy()
    {
        // Remove the celestial body from the list when it is destroyed
        allBodies.Remove(this);
    }
}
