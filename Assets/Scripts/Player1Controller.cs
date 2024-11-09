using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : MonoBehaviour

{

    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();   
    }

    // Update is called once per frame
    private float speed = 20.0f;
    private float horizontalInput;
    private float forwardInput;
    private AudioSource playerAudio;
    public float xleft = 10.0f;
    public float xRight = -1.0f;
    public float zRange = 10.0f;
    public bool hasPowerup = false;
    public AudioClip shootSound;
    public GameObject projectilePrefab;
    public Transform projectileSpawnpoint;

    void Update()
    {
        forwardInput = Input.GetAxis("Vertical");
        // Moves the Ply1 forward basedf on virtical input
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        // Moves the Ply1 left and right based on horizontal input
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        // keep Ply1 in bounds left aand right

        if (transform.position.x < -xleft)
        {
            transform.position = new Vector3(-xleft, transform.position.y, transform.position.z);
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
        //horizontalInput = Input.GetAxis("Horizontal");
        //transform.Translate(Vector3.right * horizontalInput * Time.deltaTime);

        //// keep Ply1 in bounds up and down

        //if (transform.position.x < -xRange)
        //{
        //    transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        //}

        //if (transform.position.x > xRange)
        //{
        //    transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        //}
        //horizontalInput = Input.GetAxis("Vertical");
        //transform.Translate(Vector3.forward * forwardInput * Time.deltaTime);

        // shooting
        if (Input.GetKeyDown(KeyCode.Space))
        {

            Instantiate(projectilePrefab, projectileSpawnpoint.position, projectilePrefab.transform.rotation);
            playerAudio.PlayOneShot(shootSound, 1.0f);
           // Rigidbody2D rb = projectilePrefab.GetComponent<Rigidbody2D>();
            //if (rb != null)
            {
                //float projectileSpeed = 10f;
                //rb.velocity = transform.right * projectileSpeed;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
      if(other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
        }
    }


    IEnumerator PowerupCountdownRoutine()
    {
        speed = 40.0f;
        yield return new WaitForSeconds(10);
        hasPowerup = false;
        speed = 20.0f;
    }
}

