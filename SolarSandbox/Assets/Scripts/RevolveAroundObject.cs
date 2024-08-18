using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolveAroundObject : MonoBehaviour
{
    public Transform objectToBeRevolved; // The object to revolve around
    public float radius = 10f; // Orbital radius
    public float period = 5f; // Orbital period in seconds
    private float angularSpeed; // Calculated angular speed

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (objectToBeRevolved != null)
        {
            // Calculate angular speed based on the period
            angularSpeed = 360f / period;    

            // Calculate the current angle based on time
            float angle = angularSpeed * Time.time % 360f;

            // Calculate the position based on the angle and radius
            Vector3 offset = new Vector3(Mathf.Sin(Mathf.Deg2Rad * angle), 0, Mathf.Cos(Mathf.Deg2Rad * angle)) * radius;

           // Set the position of Object A relative to Object B
            transform.position = objectToBeRevolved.position + offset;
        }
    }
}
