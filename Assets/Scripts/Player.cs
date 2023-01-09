using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject prefab;
    [SerializeField, Range(1, 50), Tooltip("Speed Control")]public float speed = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Player: Start");
    }

    private void Awake()
    {
        Debug.Log("Player: Awake");
    }

    private void Update()
    {
        /*transform.position = new Vector3(2, 3, 2);
        transform.rotation = Quaternion.Euler(30, 30, 30);
        transform.localScale = Vector3.one * 5;*/

        Vector3 direction = Vector3.zero;

        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.W)) direction.x = +1;
        if (Input.GetKey(KeyCode.A)) direction.z = +1;
        if (Input.GetKey(KeyCode.S)) direction.x = -1;
        if (Input.GetKey(KeyCode.D)) direction.z = -1;

        transform.position += direction * speed * Time.deltaTime;

        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Pew!");
            // Make Gamesound
            Instantiate(prefab, transform.position, transform.rotation);
        }
    }
}
