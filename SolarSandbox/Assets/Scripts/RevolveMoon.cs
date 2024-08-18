using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolveMoon : MonoBehaviour
{
    private Transform earth; // Reference to the Earth object
    public float orbitPeriod = 27.3f * 86400f; // Moon's orbit period in seconds (27.3 days)

    // Start is called before the first frame update
    void Start()
    {
        earth = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        if (earth != null)
        {
            // Calculate the orbit speed in degrees per second
            float orbitSpeed = 360f / orbitPeriod;

            // Rotate the Earth (parent) to create the revolution effect
            transform.RotateAround(transform.parent.position, Vector3.up, orbitSpeed * Time.deltaTime);

            // Keep the Moon tidally locked by facing the Earth
            transform.LookAt(earth);
        }        
    }
}
