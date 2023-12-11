using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermanager : MonoBehaviour
{
    public GameObject Spawn; // Assign your prefab or GameObject in the Unity Editor
    public AgentManager manager;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button click
        {
            // Get the mouse position in the game world
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.nearClipPlane; // Set the distance from the camera

            // Convert the mouse position to a world point
            Vector3 fixedPos = Camera.main.ScreenToWorldPoint(mousePos);

            // Instantiate the object at the clicked position
            GameObject newObject = Instantiate(Spawn, fixedPos, Quaternion.identity);

            // Add the instantiated object to the manager's list
            manager.obstacles.Add(newObject.GetComponent<obstacles>());
        }
    }
}
