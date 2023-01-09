using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perception : MonoBehaviour
{
    [Range(1, 40)]public float distance = 1.0f;
    [Range(0, 180)]public float maxAngle = 45.0f;

    public GameObject[] GetGameObjects()
    {
        List<GameObject> results = new List<GameObject>();

        // Returns an Array of Colliders
        Collider[] colliders = Physics.OverlapSphere(transform.position, distance);

        foreach (Collider collider in colliders)
        {
            if (collider.gameObject == gameObject) continue;

            results.Add(collider.gameObject);
        }

        return results.ToArray();
    }
}
