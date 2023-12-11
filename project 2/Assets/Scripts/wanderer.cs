using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class wanderer : agent
{
   // Start is called before the first frame update
    public float time = 1f;
    public float radius = 1f;
    public float boundWeight = 2f;
    float avoidWeight = 1f;
    float wanderWeight=1.4f;
    float avoidTime = 1f;

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

        if(state == State.wander)
        {
            PhysicsObject.ApplyForce(Wander(time, radius) * wanderWeight);
            PhysicsObject.ApplyForce(StayInBounds() * boundWeight);
            PhysicsObject.ApplyForce(AvoidObstacles(1f) * 5f);
            PhysicsObject.ApplyForce(Seperate());
        }
       else if(state == State.hunt)
        {
            PhysicsObject.ApplyForce(AvoidObstacles(1f) * 5f);
            PhysicsObject.ApplyForce(SeekNearestAgent(manager.humans));
        }

      

         
    }

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
