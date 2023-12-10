using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermanager : MonoBehaviour
{
    public GameObject objectToSpawn; // Assign your prefab or GameObject in the Unity Editor
    public AgentManager manager;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button click
        {
            // Get the mouse position in the game world
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = Camera.main.nearClipPlane; // Set the distance from the camera

            // Convert the mouse position to a world point
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            // Instantiate the object at the clicked position
            GameObject newObject = Instantiate(objectToSpawn, worldPosition, Quaternion.identity);

            // Add the instantiated object to the manager's list
            manager.obstacles.Add(newObject.GetComponent<obstacles>());
        }
    }
}
