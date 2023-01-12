using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

public class AutonomousAgent : Agent
{
    public Perception flockPerception;

    public float wanderDistance = 1;
    public float wanderRadius = 3;
    public float wanderDisplacement = 5;

    [Range(0, 3)] public float SeekWeight;
    [Range(0, 3)] public float FleeWeight;

    [Range(0, 3)] public float CohesionWeight;
    [Range(0, 3)] public float SeperationWeight;
    [Range(0, 3)] public float AlignmentWeight;

    [Range(0, 10)] public float SeperationRadius;

    public float wanderAngle { get; set; } = 0;

    // Update is called once per frame
    void Update()
    {
        var gameObjects = perception.GetGameObjects();
        foreach (var gameObject in gameObjects)
        {
            Debug.DrawLine(transform.position, gameObject.transform.position);
        }
        if (gameObjects.Length > 0)
        {
            movement.ApplyForce(Steering.Flee(this, gameObjects[0]) * FleeWeight);
            movement.ApplyForce(Steering.Seek(this, gameObjects[0]) * SeekWeight);
        }

        gameObjects = flockPerception.GetGameObjects();
        if (gameObjects.Length > 0)
        {
            foreach (var gameObject in gameObjects)
            {
                movement.ApplyForce(Steering.Cohesion(this, gameObjects) * CohesionWeight);
                movement.ApplyForce(Steering.Seperation(this, gameObjects, SeperationRadius) * SeperationWeight);
                movement.ApplyForce(Steering.Alignment(this, gameObjects, SeperationRadius) * AlignmentWeight);
            }
        }

        if (movement.acceleration.sqrMagnitude <= movement.maxForce * 0.1f)
        {
            movement.ApplyForce(Steering.Wander(this));
        }

        transform.position = Utilities.Wrap(transform.position, new Vector3(-10, -10, -10), new Vector3(10, 10, 10));
    }



}
