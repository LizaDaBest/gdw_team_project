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
    public TextMeshProUGUI titleScreen;
    public Button restartButton;
    public GameObject Powerup;
    private float spawnRangeX = 10;
    private float spawnRangeZ = 10;
    public TextMeshProUGUI titleText;
    void Start()
    {
        titleText.gameObject.SetActive(true);
        Invoke("HideTitleText", 3f);
        Cursor.visible = false;
        Score1 = 4;
        Score2 = 4;
        StartCoroutine(SpawnPowerUp());
    }

    // RESETTING SCENE AFTER TITLE NEEDS FIXING, MAYBE...
    void HideTitleText()
    {
        titleText.gameObject.SetActive(false);
    }

   // void StartupGameAfterTitle()
   // {

      //  if (GameManager.HideTitleText(true))
      //  {
           // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
      //  }
   // }
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
        if (Input.GetKeyUp(KeyCode.Return))
        {
            RestartGame();
        }

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            // or if (Input.GetButtonUp("Cancel")) {
            Application.Quit();
        }

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator SpawnPowerUp()
    {
        float waitime = Random.Range(10.0f, 20.0f);
        yield return new WaitForSeconds(waitime);

        Vector3 SpawnRange = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0.5f, (Random.Range(-spawnRangeZ, spawnRangeZ)));

        Instantiate(Powerup, SpawnRange, Powerup.transform.rotation);

        StartCoroutine(SpawnPowerUp());


    }
}


