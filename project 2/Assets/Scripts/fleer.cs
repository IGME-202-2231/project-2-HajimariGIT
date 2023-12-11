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
    public float dis = 5f;

    public enum fleerState
    {
        defaultFlee
    }

    public fleerState fleeState = new fleerState();




    // Start is called before the first frame update
    void Start()
    {

    }

    protected override void CalcSteeringForce()
    {
        if(fleeState == fleerState.defaultFlee)
        {
            PhysicsObject.ApplyForce(StayInBoundsV2(target) * 10f);

            PhysicsObject.ApplyForce(FleeAllStart(dis));
        }
       
     
      
      


    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
    }

  
}
