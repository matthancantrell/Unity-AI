using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody rb; // declares the player rigidbody as a modifiable value
    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;
    public float VOOSH;

    // Start is called before the first frame update
    void Start()
    {
        // prints to console
        Debug.Log("*** Starting Player Movement ***");

        //rb.AddForce(0, 200, 500); // x, y ,z parameters. one time force because of start method

    }

    // Update is called once per frame
    void FixedUpdate() // fixed update is better for physics in unity
    {
        // adding a forward force
        rb.AddForce(0, 0, forwardForce * Time.deltaTime); //Time.deltaTime provides compensation for high frame vs low frame systems

        if (Input.GetKey("d"))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(0, VOOSH * forwardForce, 0);
        }

        if (rb.position.y < -1)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
