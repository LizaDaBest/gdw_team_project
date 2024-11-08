using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour

{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private float speed = 20.0f;
    private float horizontalInput;
    private float forwardInput;
    public float xleft = 10.0f;
    public float xRight = -1.0f;
    public float zRange = 10.0f;


    public GameObject projectilePrefab;
    public Transform projectileSpawnpoint;

    void Update()
    {
        forwardInput = Input.GetAxis("Vertical 2");
        // Moves the Ply2 forward basedf on virtical input
        transform.Translate(Vector3.back * Time.deltaTime * speed * forwardInput);
        // Moves the Ply2 left and right based on horizontal input
        horizontalInput = Input.GetAxis("Horizontal 2");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        // keep Ply2 in bounds left aand right

        if (transform.position.x < xleft)
        {
            transform.position = new Vector3(xleft, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRight)
        {
            transform.position = new Vector3(xRight, transform.position.y, transform.position.z);
        }

        if (transform.position.z < -zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        }

        if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }

        //xDirection = Input.GetAxis("Horizontal");
        //transform.Translate(Vector3.right * xDirection * Time.deltaTime);

        //// keep Ply2 in bounds up and down

        //if (transform.position.x < -xRange)
        //{
        //    transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        //}

        //if (transform.position.x > xRange)
        //{
        //    transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        //}
        //zDirection = Input.GetAxis("Vertical");
        //transform.Translate(Vector3.forward * zDirection * Time.deltaTime);

        // shooting
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {

            Instantiate(projectilePrefab, projectileSpawnpoint.position, projectilePrefab.transform.rotation);
            //Rigidbody2D rb = projectilePrefab.GetComponent<Rigidbody2D>();
            //if (rb != null)
            //{
              //  float projectileSpeed = 10f;
                //rb.velocity = transform.right * projectileSpeed;
            //}
        }
    }
}