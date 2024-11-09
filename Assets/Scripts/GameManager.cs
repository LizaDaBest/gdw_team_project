using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    // public List<GameObject> targets;
    public int Score1;
    public int Score2;
    //private float spawnRate = 1.0f;

    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI gameOverText2;
    public Button restartButton;
    public GameObject Powerup;
    private float spawnRangeX = 10;
    private float spawnRangeZ = 10;
    void Start()
    {
        // StartCoroutine(SpawnTarget());
        // [System.Serializable];
        Score1 = 4;
        Score2 = 4;
        StartCoroutine(SpawnPowerUp());
    }

    //IEnumerator SpawnTarget()
    //{
    //    while (true)
    //    {
    //        yield return new WaitForSeconds(spawnRate);
    //        int index = Random.Range(0, targets.Count);
    //        Instantiate(targets[index]);
    //        UpdateScore(-1);
    //    }
    //}

    public void UpdateScore(int scoreToAdd)
    {
        Score1 += scoreToAdd;
        if (Score1 == 0)
        {
            gameOverText2.gameObject.SetActive(true);
        }
    }

    public void UpdateScore2(int scoreToAdd)
    {
        Score2 += scoreToAdd;
        if (Score2 == 0)
        {
            gameOverText.gameObject.SetActive(true);
        }
    }

    public void GameOver()
    {
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
      if(Input.GetKeyUp(KeyCode.Alpha1))
        {
          RestartGame();
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator SpawnPowerUp ()
    {
        float waitime = Random.Range(10.0f, 20.0f);
        yield return new WaitForSeconds(waitime);

        Vector3 SpawnRange = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0.5f, (Random.Range(-spawnRangeZ, spawnRangeZ)));

        Instantiate(Powerup, SpawnRange, Powerup.transform.rotation);
     
        StartCoroutine(SpawnPowerUp());


    }
}


