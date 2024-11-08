using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    // Start is called before the first frame update

    private GameManager gameManager;
    public int pointValue;
    public bool isPlayer2;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        Destroy(other.gameObject);
        if (isPlayer2)
        {
            gameManager.UpdateScore2(pointValue);
        }

        else
        {
           gameManager.UpdateScore(pointValue);
        }

    }

}
