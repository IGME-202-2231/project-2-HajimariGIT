using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class fleer : agent
{
    public GameObject target;
    public bool hit;
    public float boundWeight = 1f;
    public AgentManager maanger;




    // Start is called before the first frame update
    void Start()
    {

    }

    protected override void CalcSteeringForce()
    {

        PhysicsObject.ApplyForce(StayInBoundsV2(target) * 10f);

        PhysicsObject.ApplyForce(FleeAll(manager.agents));
     
      
      


    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
    }

  
}
