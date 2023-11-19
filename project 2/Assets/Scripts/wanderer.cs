using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class wanderer : agent
{
    // Start is called before the first frame update
    public float time = 1f;
    public float radius = 1f;
    public float boundWeight = 1f;


    protected override void CalcSteeringForce()
    {
       /* PhysicsObject.ApplyForce(Seperate());
        PhysicsObject.ApplyForce(StayInBounds() *1 );
        PhysicsObject.ApplyForce(Wander(time,radius));*/

        PhysicsObject.ApplyForce(Wander(time, radius));
        PhysicsObject.ApplyForce(StayInBounds() * boundWeight);
        PhysicsObject.ApplyForce(Seperate());


    }



}
