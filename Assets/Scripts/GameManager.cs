using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    // public List<GameObject> targets;
    public int Score1;
    public int Score2;
    //private float spawnRate = 1.0f;

    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI gameOverText2;
    void Start()
    {
        // StartCoroutine(SpawnTarget());
        // [System.Serializable];
        Score1 = 4;
        Score2 = 4;
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
        gameOverText.gameObject.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
