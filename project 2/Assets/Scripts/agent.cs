using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class agent : MonoBehaviour
{
    [SerializeField] protected PhysicsObject PhysicsObject;
    public float MaxForce;
    public Vector3 myPos;
    public Vector3 currentVelocity;
    public float maxSpeed;
    public AgentManager manager;
    public float seperateRange = 1f;
    public float avoidTime = 1f;
    public float avoidDist = 0f;
    //  float boundWeight = 1;
    public List<Vector3> foundObstacles = new List<Vector3>();
    public float seekRadius = 5f;






    // Start is called before the first frame update
    void Start()
    {
        maxSpeed = PhysicsObject.max;
    }

    // Update is called once per frame
    protected void Update()
    {

        CalcSteeringForce();




    }




    protected abstract void CalcSteeringForce();


    /// <summary>
    /// seeks taregt
    /// </summary>
    /// <param name="targetPos"></param>
    /// <returns>
    /// seeking force </returns>
    protected Vector3 Seek(Vector3 targetPos)
    {
        // Calculate desired velocity
        Vector3 desiredVelocity = targetPos - transform.position;

        // Set desired = max speed
        desiredVelocity = desiredVelocity.normalized * PhysicsObject.maxSpeed;

        // Calculate seek steering force
        Vector3 seekingForce = desiredVelocity - PhysicsObject.Velocity;





        // Return seek steering force
        return seekingForce;
    }
    /// <summary>
    /// to start seek
    /// </summary>
    /// <param name="target"></param>
    /// <returns> vector 3</returns>
    protected Vector3 Seek(GameObject target)
    {
       

        return Seek(target.transform.position);
    }
    /// <summary>
    /// to seek nearest 
    /// </summary>
    /// <param name="agents"></param>
    /// <returns>retuns vector 3</returns>
    protected Vector3 SeekNear(List<agent> agents)
    {
       //set it to nothing
        agent near = null;
        //no range
        float shortest = float.MaxValue;
        foreach (agent agentNow in agents)
        {
          //calc distamce
            float distance = Vector3.Distance(transform.position, agentNow.transform.position);
            //if less then shorest 
            if (distance < shortest)
            {
                shortest = distance;
                near = agentNow;
            }
        }

      //if exists
        if (near != null)
        {
         
          //seek it
            return Seek(near.gameObject);
        }
        else
        {
         
            return Vector3.zero; 
        }
    }

    protected Vector3 Flee(Vector3 targetPos)
    {
        // Calculate desired velocity
        Vector3 desiredVelocity = transform.position - targetPos;

        // Set desired = max speed
        desiredVelocity = desiredVelocity.normalized * PhysicsObject.maxSpeed;

        // Calculate seek steering force
        Vector3 seekingForce = desiredVelocity - PhysicsObject.Velocity;

        // Return seek steering force
        return seekingForce;
    }
    /// <summary>
    /// to start flee
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns>
    protected Vector3 Flee(GameObject target)
    {
       



        return Flee(target.transform.position);
    }
    /// <summary>
    /// to start flee
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns>
    protected Vector3 Flee(agent target)
    {
       


        return Flee(target.transform.position);
    }
    /// <summary>
    /// flees all 
    /// </summary>
    /// <param name="agents"></param>
    /// <param name="max"></param>
    /// <returns>
    /// vector 3</returns>
    protected Vector3 FleeAll(List<agent> agents, float max)
    {
        Vector3 total = Vector3.zero;

        //for each agent
        foreach (agent now in agents)
        {
         //calc dis
            float distance = Vector3.Distance(transform.position, now.transform.position);

            //if less than value
            if (distance < max)
            {
              //flee
                total += Flee(now);
            }
        }

        return total;
    }

    //starts the call
    protected Vector3 FleeAllStart(float max)
    {
        return FleeAll(manager.agents, max);
    }

    /// <summary>
    /// wanders
    /// </summary>
    /// <param name="time"></param>
    /// <param name="radius"></param>
    /// <returns>Vector 3</returns>
    protected Vector3 Wander(float time, float radius)
    {
        Vector3 targetPos = CalcFuturePosition(time);
        float ranAngle = Random.Range(0, Mathf.PI * 2f);
        //random direction
        targetPos.x += Mathf.Cos(ranAngle) * radius;
        targetPos.y += Mathf.Sin(ranAngle) * radius;
        //sek that point
        return Seek(targetPos);

    }
    /// <summary>
    /// applys future pos
    /// </summary>
    /// <param name="time"></param>
    /// <returns></returns>
    public Vector3 CalcFuturePosition(float time)
    {
        return PhysicsObject.Velocity * time + transform.position;

        //totalForce = StayInBounds() * boundWeight 
        //totalForce+= Seperate 
        //take out of wander put here
    }
    /// <summary>
    /// keeps objects in camera
    /// </summary>
    /// <returns></returns>

    protected Vector3 StayInBounds()
    {
      


        //reverses to center if outside of camera
        if (transform.position.y >= PhysicsObject.totalCamheight / 2 - 2.5 || transform.position.y <= -PhysicsObject.totalCamheight / 2 + 2.5
             || transform.position.x >= PhysicsObject.totalCamwidth / 2 - 2.3 || transform.position.x <= -PhysicsObject.totalCamwidth / 2 + 2.3)
        {
            return Seek(Vector3.zero);
        }
        else
        {
            return Vector3.zero;

        }




    }

    /// <summary>
    /// stay in bounds but seek house
    /// </summary>
    /// <param name="one"></param>
    /// <returns>vector 3</returns>
    protected Vector3 StayInBoundsV2(GameObject one)
    {



        //outside of camera
        if (transform.position.y >= PhysicsObject.totalCamheight / 2 - 2.5 || transform.position.y <= -PhysicsObject.totalCamheight / 2 + 2.5
             || transform.position.x >= PhysicsObject.totalCamwidth / 2 - 2.3 || transform.position.x <= -PhysicsObject.totalCamwidth / 2 + 2.3)
        {
            //seeks house
            return Seek(one);
        }
        else
        {
            return Vector3.zero;

        }




    }


    /// <summary>
    /// seperates agents
    /// </summary>
    /// <returns> vector 3</returns>
    protected Vector3 Seperate()
    {
        //set
        Vector3 steeringforce = Vector3.zero;
        foreach (agent agent in manager.agents)
        {
            //calc dis
            float dis = Vector3.Distance(transform.position, agent.transform.position);
            //seperate 
            if (Mathf.Epsilon < dis)
                steeringforce += Flee(agent) * (seperateRange / dis);//0.3

        }

        return steeringforce;
    }


    /// <summary>
    /// aviod obstacle
    /// </summary>
    /// <param name="avoidTime"></param>
    /// <returns></returns>
    protected Vector3 AvoidObstacles(float avoidTime)
    {
        //set and clear
        Vector3 totalAvoidForce = Vector3.zero;
        foundObstacles.Clear();
        //calcs and finds distance 
        Vector3 futurePos = CalcFuturePosition(avoidTime);
        float avoidDist = Vector3.Distance(transform.position, futurePos) + PhysicsObject.Radius;

        //for each obstacle
        foreach (obstacles obstacle in manager.obstacles)
        {
            //subtract the positon
            Vector3 aToO = obstacle.transform.position - transform.position;
            //vector property 
            float rightDot = Vector3.Dot(transform.right, aToO);
            float forwardDot = Vector3.Dot(PhysicsObject.Direction, aToO);
            //checks if close
            if (forwardDot >= -obstacle.Radius && forwardDot <= avoidDist + obstacle.Radius
                && Mathf.Abs(rightDot) <= PhysicsObject.Radius + obstacle.Radius) 
            {
                foundObstacles.Add(obstacle.transform.position);

                Vector3 Force = transform.right * (forwardDot / avoidDist) * maxSpeed;
                //seperaate 

                if (rightDot < 0)
                {
                    totalAvoidForce += Force;
                }
                else
                {
                    totalAvoidForce -= Force;
                }
            }
        }

        return totalAvoidForce;
    }

  

 
}

   













