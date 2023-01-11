using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Perception : MonoBehaviour
{
    public string tagName = "";
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
            if (tagName == "" || collider.CompareTag(tagName))
            {
                // calculate angle from transform forward vector to direction of game object 
                Vector3 direction = (collider.transform.position - transform.position).normalized;
                float cos = Vector3.Dot(transform.forward, direction);
                float angle = Mathf.Acos(cos) * Mathf.Rad2Deg;
                if (angle <= maxAngle) results.Add(collider.gameObject);
            }
        }
        
        return results.ToArray();
    }
}
