using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class fleer : agent
{
    public GameObject target;
    public bool hit;




    // Start is called before the first frame update
    void Start()
    {

    }


   /* protected void Update()
    {
        
        base.Update();
        float x = GetComponent<PhysicsObject>().center.x - target.GetComponent<PhysicsObject>().center.x;
        float y = GetComponent<PhysicsObject>().center.y - target.GetComponent<PhysicsObject>().center.y;
        float total = Mathf.Sqrt(x * x + y * y);

        if (total < GetComponent<PhysicsObject>().Radius + target.GetComponent<PhysicsObject>().Radius)
        {
            Vector3 random = new Vector3(Random.Range(-4, 4), Random.Range(-9, 9), 0);
            transform.position = random;
        }






    }*/





    protected override void CalcSteeringForce()
    {

        PhysicsObject.ApplyForce(Flee(target));
      


    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
    }

  
}
