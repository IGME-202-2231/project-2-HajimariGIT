using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacles : MonoBehaviour
{
    // Start is called before the first frame update

    public Renderer sprite;
    public float radius;
    //to get radius
    public float Radius
    {
       
        get { return sprite.bounds.size.x / 2 + 0.3f; }
    }
    //sets radius
    private void Start()
    {
        radius = sprite.bounds.size.x / 2 + 0.3f;
    }

    //gizmo if needed
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
