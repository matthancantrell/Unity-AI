using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject prefab;
    [SerializeField, Range(1, 50), Tooltip("Speed Control")]public float speed = 0.0f;
    [Range(0, 360)]public float rotationRate = 180;
    public Transform bulletSpawnLocation;

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
        direction.z = Input.GetAxis("Vertical");

        Vector3 rotation = Vector3.zero;
        rotation.y = Input.GetAxis("Horizontal");

        Quaternion rotate = Quaternion.Euler(rotation * rotationRate * Time.deltaTime);
        transform.rotation = transform.rotation * rotate;
        transform.Translate(direction * speed * Time.deltaTime);

        //transform.position += direction * speed * Time.deltaTime;

        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Pew!");
            // Make Gamesound
            Instantiate(prefab, bulletSpawnLocation.position, bulletSpawnLocation.rotation);
        }
    }
}
