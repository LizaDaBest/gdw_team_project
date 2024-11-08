using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour

{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private float speed = 20.0f;
    public float xRange = 10.0f;
    public float zRange = 10.0f;


    public GameObject projectilePrefab;

    void Update()
    {
        float xDirection = Input.GetAxis("Horizontal");
        float zDirection = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(xDirection, 0.0f, zDirection);

        transform.position = moveDirection * speed;

        // keep Ply2 in bounds left aand right

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.z < -zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        }

        if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }
        xDirection = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * xDirection * Time.deltaTime);

        // keep Ply2 in bounds up and down

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        zDirection = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * zDirection * Time.deltaTime);

        // shooting
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {

            Instantiate(projectilePrefab, transform.position, transform.rotation);
            Rigidbody2D rb = projectilePrefab.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                float projectileSpeed = 10f;
                rb.velocity = transform.right * projectileSpeed;
            }
        }
    }
}