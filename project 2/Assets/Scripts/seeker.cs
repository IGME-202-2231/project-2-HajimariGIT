using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seeker : agent
{
    public GameObject target;
    Vector3 position;




    // Start is called before the first frame update
    void Start()
    {
        
    }




    protected override void CalcSteeringForce()
    {
        PhysicsObject.ApplyForce(Seek(target));

      

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta; 
    }
}
