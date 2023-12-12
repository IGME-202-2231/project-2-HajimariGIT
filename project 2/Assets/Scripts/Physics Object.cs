using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObject : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 Direction;
    public  Vector3 Velocity;
    public  Vector3 Position;
    public Vector3 Acelleration = Vector3.zero;
    public float mass;
    public float maxSpeed;
    public float totalCamheight;
    int test;
    public float totalCamwidth;
    public bool useGravity;
    public bool useFriction;
    public float gravity;
    public float friction;
    public float radius = 1f;
    [SerializeField] SpriteRenderer renderer;

     public float Radius
    {
        //added a buffer to make it bigger 
        get { return renderer.bounds.size.x / 2 + 0.3f; }
    }
   

    public float velocity
    {

        get { return velocity; }
    }

    public float max
    {

        get { return maxSpeed; }
    }

    public Vector3 center
    {
        get { return renderer.bounds.center; }
    }



    // starts game and sets the screen 
    void Start()
    {
        Position = transform.position;
        totalCamheight = 2f * Camera.main.orthographicSize;
        totalCamwidth = totalCamheight * Camera.main.aspect;
        gravity = .98f;
        //adjust to acell
        maxSpeed = 6f;
    }

    // Update is called once per frame
    void Update()
    {
        // if statements to check gravity and frictio
        if (useGravity)
        {
            ApplyGrav(Vector3.down * gravity);
        }
        if(useFriction)
        {
            ApplyFriction(friction);
        }
        Velocity += Acelleration * Time.deltaTime;
        Velocity = Vector3.ClampMagnitude(Velocity, maxSpeed);
        Position += Velocity * Time.deltaTime;
        Direction = Velocity.normalized;

        if (Velocity != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.back, Velocity);
        }
        transform.position = Position;
        Acelleration = Vector3.zero;



        /*if (Position.y > totalCamheight / 2f)
        {
            Velocity.y *= -1f;
        }
        else if (Position.y < -totalCamheight / 2f)
        {
            Velocity.y *= -1f;
        }

        if (Position.x > totalCamwidth / 2f)
        {
            Velocity.x *= -1f;
        }
        else if (Position.x < -totalCamwidth / 2f)
        {
            Velocity.x *= -1f;
        }*/







    }


    // applies force 
    public void ApplyForce(Vector3 force)
    {
        Acelleration += force / mass;
    }
    // applies gravity
    public void ApplyGrav(Vector3 force)
    {
        Acelleration += force;
    }
    //applies friction
    void ApplyFriction(float coeff)
    {
        Vector3 friction = Velocity * -1;
        friction.Normalize();
        friction = friction * coeff;
        ApplyForce(friction);
    }



}
