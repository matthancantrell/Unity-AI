using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentSpawner : MonoBehaviour
{
    public Agent[] agents;
    public LayerMask layerMask;
    int index = 0;

    void Update()
    {
        if (Input.GetKey(KeyCode.Tab)) index = (++index % agents.Length);

        if (Input.GetMouseButtonDown(0))
        {
/*            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, 100, layerMask))
            {
                Instantiate(agent01, hitInfo.point, Quaternion.identity);
            }*/
        }
/*        if (Physics.Raycast(ray out RaycastHit hitInfo, 100, layerMask))
        {
            Instantiate(agents[index], hitInfo.point, Quaternion.AngleAxis(Random.Range(0, 360)), );
        }*/
    }
}
