using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public Vector3 velocity { get; set; } = Vector3.zero;
    public Vector3 acceleration { get; set; } = Vector3.zero;

    public void ApplyForce(Vector3 force)
    {
        acceleration += force;
    }

    void LateUpdate()
    {
        velocity += acceleration * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;

        acceleration = Vector3.zero;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
