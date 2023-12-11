using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seeker : agent
{
    public GameObject target; 
    Vector3 position;
    public int test;

    public enum seekerState
    {
        defualtSeeker
    }
    seekerState seekState = new seekerState();




    // Start is called before the first frame update 
    void Start()
    {
         seekState = seekerState.defualtSeeker;
    }




    protected override void CalcSteeringForce()
    {
       // PhysicsObject.ApplyForce(Seek(target));
        //PhysicsObject.ApplyForce(StayInBoundsV2(target) * 10f);
       // PhysicsObject.ApplyForce(StayInBounds() * 1f);

        if(seekState == seekerState.defualtSeeker)
        {
            PhysicsObject.ApplyForce(SeekNearestAgent(manager.agents));
        }
     

        



    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta; 
    }
}
