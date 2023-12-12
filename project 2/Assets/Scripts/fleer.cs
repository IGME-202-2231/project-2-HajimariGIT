using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class fleer : agent
{
    public GameObject target;
    public bool hit;
    public float boundWeight = 1f;
    public AgentManager maanger;
    public float dis = 2f;
    public bool isfleer = true;

    
    public enum fleerState
    {
        defaultFlee
    }

    public fleerState fleeState = new fleerState();




    // Start is called before the first frame update
    void Start()
    {

    }

    /// <summary>
    /// used to update and apply forces 
    /// no paramerters
    /// </summary>
    protected override void CalcSteeringForce()
    {
        //if default state
        if(fleeState == fleerState.defaultFlee)
        {
            //flee all
            PhysicsObject.ApplyForce(FleeAllStart(dis));
            //stay in bounds but search a house
            PhysicsObject.ApplyForce(StayInBoundsV2(target) * 2.5f);

           
        }
       
     
      
      


    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
    }

  
}
