using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    public PlayerMove movement; // calls on the PlayerMove component

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            movement.enabled = false; // disables movement on impact
            FindObjectOfType<GameManager>().EndGame();

        }
    }
}
