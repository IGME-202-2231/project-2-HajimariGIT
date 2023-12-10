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

    protected Vector3 Seek(GameObject target)
    {
       

        return Seek(target.transform.position);
    }

    protected Vector3 SeekNearestAgent(List<agent> agents)
    {
        
        if (agents == null || agents.Count == 0)
        {
            Debug.Log("hi1");
            return Vector3.zero; 
        }

      
        agent nearestAgent = null;
        float shortestDistance = float.MaxValue;
        foreach (agent currentAgent in agents)
        {
          
            if (currentAgent == null)
            {
                continue;
            }

            float distance = Vector3.Distance(transform.position, currentAgent.transform.position);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                nearestAgent = currentAgent;
            }
        }

      
        if (nearestAgent != null)
        {
            Debug.Log("hi");
          
            return Seek(nearestAgent.gameObject);
        }
        else
        {
            Debug.Log("hi3");
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

    protected Vector3 Flee(GameObject target)
    {
       



        return Flee(target.transform.position);
    }

    protected Vector3 Flee(agent target)
    {
       


        return Flee(target.transform.position);
    }

    protected Vector3 FleeAll(List<agent> agents, float maxFleeDistance)
    {
        Vector3 totalFleeingForce = Vector3.zero;

        foreach (agent currentAgent in agents)
        {
         
            if (currentAgent == null)
            {
                continue;
            }

          
            float distance = Vector3.Distance(transform.position, currentAgent.transform.position);

      
            if (distance < maxFleeDistance)
            {
              
                totalFleeingForce += Flee(currentAgent);
            }
        }

        return totalFleeingForce;
    }

    protected Vector3 FleeAllStart(float maxFleeDistance)
    {
        return FleeAll(manager.agents, maxFleeDistance);
    }

    protected Vector3 Wander(float time, float radius)
    {
        Vector3 targetPos = CalcFuturePosition(time);
        float ranAngle = Random.Range(0, Mathf.PI * 2f);
        targetPos.x += Mathf.Cos(ranAngle) * radius;
        targetPos.y += Mathf.Sin(ranAngle) * radius;
        return Seek(targetPos);

    }

    public Vector3 CalcFuturePosition(float time)
    {
        return PhysicsObject.Velocity * time + transform.position;

        //totalForce = StayInBounds() * boundWeight 
        //totalForce+= Seperate 
        //take out of wander put here
    }


    protected Vector3 StayInBounds()
    {
      



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

    protected Vector3 StayInBoundsV2(GameObject one)
    {




        if (transform.position.y >= PhysicsObject.totalCamheight / 2 - 2.5 || transform.position.y <= -PhysicsObject.totalCamheight / 2 + 2.5
             || transform.position.x >= PhysicsObject.totalCamwidth / 2 - 2.3 || transform.position.x <= -PhysicsObject.totalCamwidth / 2 + 2.3)
        {
            return Seek(one);
        }
        else
        {
            return Vector3.zero;

        }




    }



    protected Vector3 Seperate()
    {
        Vector3 steeringforce = Vector3.zero;
        foreach (agent agent in manager.agents)
        {
            float dis = Vector3.Distance(transform.position, agent.transform.position);
            if (Mathf.Epsilon < dis)
                steeringforce += Flee(agent) * (seperateRange / dis);//0.3

        }

        return steeringforce;
    }



    protected Vector3 AvoidObstacles(float avoidTime)
    {
        Vector3 totalAvoidForce = Vector3.zero;
        foundObstacles.Clear();

        Vector3 futurePos = CalcFuturePosition(avoidTime);
        float avoidDist = Vector3.Distance(transform.position, futurePos) + PhysicsObject.Radius;

        foreach (obstacles obstacle in manager.obstacles)
        {
            Vector3 aToO = obstacle.transform.position - transform.position;
            float rightDot = Vector3.Dot(transform.right, aToO);
            float forwardDot = Vector3.Dot(PhysicsObject.Direction, aToO);

            if (forwardDot >= -obstacle.Radius && forwardDot <= avoidDist + obstacle.Radius
                && Mathf.Abs(rightDot) <= PhysicsObject.Radius + obstacle.Radius) 
            {
                foundObstacles.Add(obstacle.transform.position);

                Vector3 Force = transform.right * (forwardDot / avoidDist) * maxSpeed;

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
