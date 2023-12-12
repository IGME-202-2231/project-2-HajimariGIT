using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermanager : MonoBehaviour
{
    public GameObject Spawn; 
    public AgentManager manager;

    void Update()
    {

        //if left click
        if (Input.GetMouseButtonDown(0)) 
        {
           //take the mouse
            Vector3 mousePos = Input.mousePosition;
            //make the image overlap
            mousePos.z = Camera.main.nearClipPlane;
            //sets to world
            Vector3 fixedPos = Camera.main.ScreenToWorldPoint(mousePos);

           //creates
            GameObject newObject = Instantiate(Spawn, fixedPos, Quaternion.identity);

         //makes obstacle
            manager.obstacles.Add(newObject.GetComponent<obstacles>());
        }
    }
}
