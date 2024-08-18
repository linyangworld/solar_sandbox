using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateItself : MonoBehaviour
{
    public float period = 1f;

    private float rotationSpeed = 0;

    // Start is called before the first frame update
    void Start()
    {
        rotationSpeed = 360f / period;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
