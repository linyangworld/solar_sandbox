using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragRadius : MonoBehaviour
{
    public float dragSpeed = 0.1f; // Speed at which the drag affects the radius
    private Vector3 lastMousePosition; // Store the last mouse position

    private bool isDragging = false; // State to check if the user is dragging

    private Transform objectToBeRevolved; 

    // Start is called before the first frame update
    void Start()
    {
        objectToBeRevolved = GetComponent<RevolveAroundObject>().objectToBeRevolved;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the user started dragging 
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.transform == transform)
            {
                Debug.Log("Clicked!");
                isDragging = true; // Start dragging
                lastMousePosition = Input.mousePosition; // Record the starting mouse position
            }
        }

        // Check if the user released the mouse button (stop dragging)
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false; // Stop dragging
        }    

        // If dragging, update position relative to the oject to be revolved
        if (isDragging)
        {
            Vector3 currentMousePosition = Input.mousePosition;
            float distanceChange = (currentMousePosition - lastMousePosition).x * dragSpeed;
            lastMousePosition = currentMousePosition;

            // Update position by changing its distance from the oject to be revolved
            Vector3 direction = (transform.position - objectToBeRevolved.position).normalized;
            transform.position += direction * distanceChange;
            GetComponent<RevolveAroundObject>().radius = Vector3.Distance(transform.position, objectToBeRevolved.position);
        }
    }
}
