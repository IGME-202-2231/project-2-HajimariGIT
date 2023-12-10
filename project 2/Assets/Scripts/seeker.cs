using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seeker : agent
{
    public GameObject target; 
    Vector3 position;
    public int test;

     


    // Start is called before the first frame update 
    void Start()
    {
        
    }




    protected override void CalcSteeringForce()
    {
       // PhysicsObject.ApplyForce(Seek(target));
        //PhysicsObject.ApplyForce(StayInBoundsV2(target) * 10f);
       // PhysicsObject.ApplyForce(StayInBounds() * 1f);

        PhysicsObject.ApplyForce(SeekNearestAgent(manager.agents));

        



    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta; 
    }
}
