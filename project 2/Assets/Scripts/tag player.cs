using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tagplayer : agent
{
    // Start is called before the first frame update
    public float time = 1f;
    public float radius = 1f;
    public float boundWeight = 1f;

    float countTimer;

    public enum TagStates
    {
        NotIt,
        Counting,
        It

    }

    TagStates currentState;


    protected override void CalcSteeringForce()
    {
        /* PhysicsObject.ApplyForce(Seperate());
         PhysicsObject.ApplyForce(StayInBounds() *1 );
         PhysicsObject.ApplyForce(Wander(time,radius));*/

        switch(currentState)
        {
            case TagStates.NotIt:
                PhysicsObject.ApplyForce(Wander(time, radius));
                PhysicsObject.ApplyForce(StayInBounds() * boundWeight);
                PhysicsObject.ApplyForce(Seperate());
                break;


                case TagStates.Counting:
                 countTimer = Time.deltaTime;
                 if(countTimer >= manager.CountTime)
                 {
                    ++currentState;
                 }


                break;

                case TagStates.It:
                 


                break;
        }

        PhysicsObject.ApplyForce( StayInBounds() * boundWeight);



    }


    
}
