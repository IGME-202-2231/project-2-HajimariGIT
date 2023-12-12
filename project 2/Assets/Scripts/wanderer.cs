using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class wanderer : agent
{
   // Start is called before the first frame update
    public float time = 1f;
    public float radius = 1f;
    public float boundWeight = 5f;
    float avoidWeight = 1f;
    float wanderWeight=1.4f;
    float avoidTime = 1f;
    public bool isWander = true;

    public enum State 
    {
        wander,
        hunt
    }

    public State state = State.wander;

   

    protected override void CalcSteeringForce()
    { 
       /* PhysicsObject.ApplyForce(Seperate());
        PhysicsObject.ApplyForce(StayInBounds() *1 );
        PhysicsObject.ApplyForce(Wander(time,radius));*/

        //if in wander state
        if(state == State.wander)
        {
            //wander
            PhysicsObject.ApplyForce(Wander(time, radius) * wanderWeight);
            //stay in bounds of camer
            PhysicsObject.ApplyForce(StayInBounds() * boundWeight);
            //aviod obstacle
            PhysicsObject.ApplyForce(AvoidObstacles(1f) * 5.5f);
            //seperate 
            PhysicsObject.ApplyForce(Seperate());
        }
        //if in hunt
       else if(state == State.hunt)
        {
            //aviod obstacles more
            PhysicsObject.ApplyForce(AvoidObstacles(1f) * 10f);
            //seek human that is near
            PhysicsObject.ApplyForce(SeekNear(manager.humans));
        }

      

         
    }


    /// <summary>
    /// needed for gizmo and obstacles
    /// </summary>
    private void OnDrawGizmos()
    {
        //
        //  Draw safe space box 
        //
        Vector3 futurePos = CalcFuturePosition(avoidTime);

        float dist = Vector3.Distance(transform.position, futurePos) + PhysicsObject.radius;

        Vector3 boxSize = new Vector3(PhysicsObject.Radius * 2f, dist, PhysicsObject.Radius * 2f);

        Vector3 boxCenter = Vector3.zero;
        boxCenter.y += dist / 2f;

        Gizmos.color = Color.green;

        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.DrawWireCube(boxCenter, boxSize);
        Gizmos.matrix = Matrix4x4.identity;


        //
        //  Draw lines to found obstacles
        //
        Gizmos.color = Color.red;

         foreach (Vector3 pos in foundObstacles)
         {
             Gizmos.DrawLine(transform.position, pos);
         }
    }


    public void SwitchState(State newState)
    {
        state = newState;
       
    }

}
