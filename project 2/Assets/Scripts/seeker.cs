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



    /// <summary>
    /// used to update and apply forces 
    /// no paramerters
    /// </summary>
    protected override void CalcSteeringForce()
    {
       // PhysicsObject.ApplyForce(Seek(target));
        //PhysicsObject.ApplyForce(StayInBoundsV2(target) * 10f);
       // PhysicsObject.ApplyForce(StayInBounds() * 1f);

        //if in normal state
        if(seekState == seekerState.defualtSeeker)
        {
            //seek the nearest target
            PhysicsObject.ApplyForce(SeekNear(manager.agents));
            //stay in bounds of camera
            PhysicsObject.ApplyForce(StayInBounds());
        }
     

        



    }
    /// <summary>
    /// gizmo method if needed
    /// no parameters
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta; 
    }
}
