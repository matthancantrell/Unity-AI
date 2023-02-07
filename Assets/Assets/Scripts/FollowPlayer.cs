using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public Transform playerObject;
    public Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        transform.position = playerObject.position + offset;
    }
}
