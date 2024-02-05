using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] GameObject rainDrop;
    [SerializeField] GameObject booster;
    [SerializeField] GameObject cloud;
    [SerializeField] Canvas canvas;

    [SerializeField] Animator clickAnim;

    [SerializeField] int maxBoostSpawnTime = 80;
    [SerializeField] int minBoostSpawnTime = 10;

    [SerializeField] int maxCloudSpawnTime = 60;
    [SerializeField] int minCloudSpawnTime = 15;

    public TMP_Text scoreTxt;

    public float scorePerSecond = 1;
    public int currentScore = 0;
    public int scoreToAdd = 0;
    public int scoreBoost = 1;
    public int clickAmount = 1;

    void Start()
    {
        StartCoroutine(AutoScore());
        StartCoroutine(RainDown());
        StartCoroutine(BoostSpawner());
        StartCoroutine(CloudSpawner());
    }

    IEnumerator AutoScore()
    {
        while(true)
        {
            currentScore += scoreToAdd * scoreBoost;
            scoreTxt.SetText("Raindrops: " + currentScore);
            yield return new WaitForSeconds(scorePerSecond);
        }

    }

    IEnumerator RainDown()
    {
        while(true)
        {
            yield return new WaitForSeconds(0);
            if(scoreToAdd >= 1)
            {
                yield return new WaitForSeconds(scorePerSecond/(scoreToAdd * scoreBoost));
                Instantiate(rainDrop);
            }
        }
    }

    IEnumerator BoostSpawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minBoostSpawnTime, maxBoostSpawnTime));
            int x = Random.Range(-50, 50) * (16 / 9);
            int y = Random.Range(-50, 50);
            GameObject obj = Instantiate(booster, canvas.transform);
            obj.GetComponent<RectTransform>().position = new Vector3(x, y, canvas.transform.position.z);
        }
    }

    IEnumerator CloudSpawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minCloudSpawnTime, maxCloudSpawnTime));
            int x = Random.Range(-50, 50) * (16 / 9);
            int y = Random.Range(-50, 50);
            GameObject obj = Instantiate(cloud, canvas.transform);
            obj.GetComponent<RectTransform>().position = new Vector3(x, y, canvas.transform.position.z);
        }
    }

    public void AddScore()
    {
        currentScore += clickAmount * scoreBoost;
        scoreTxt.SetText("Raindrops: " + currentScore);
        Instantiate(rainDrop);
        clickAnim.SetTrigger("Click");
    }

    public IEnumerator BoostTime(GameObject booster, int amount, int time, bool active)
    {
        active = true;
        scoreBoost = amount;
        yield return new WaitForSeconds(time);
        scoreBoost = 1;
        active = false;
        Destroy(booster);
    }

    public void AddBoostScore(int addScore)
    {
        currentScore += addScore;
        scoreTxt.SetText("Raindrops: " + currentScore);
    }
}
