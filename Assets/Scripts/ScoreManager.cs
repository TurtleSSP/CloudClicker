using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] GameObject rainDrop;
    [SerializeField] GameObject booster;
    [SerializeField] Canvas canvas;

    [SerializeField] int maxBoostSpawnTime = 80;
    [SerializeField] int minBoostSpawnTime = 10;

    public TMP_Text scoreTxt;

    public int currentScore = 0;
    public int scoreToAdd = 0;
    public int scoreBoost = 1;
    public int clickAmount = 1;

    void Start()
    {
        InvokeRepeating("AddAutoScore", 0, 1);
        StartCoroutine(RainDown());
        StartCoroutine(BoostSpawner());
    }

    IEnumerator RainDown()
    {
        while(true)
        {
            yield return new WaitForSeconds(0);
            if(scoreToAdd >= 1)
            {
                yield return new WaitForSeconds(1f/(scoreToAdd * scoreBoost));
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

    void AddAutoScore()
    {
        currentScore += scoreToAdd * scoreBoost;
        scoreTxt.SetText("Score: " + currentScore);
    }

    public void AddScore()
    {
        currentScore += clickAmount * scoreBoost;
        scoreTxt.SetText("Score: " + currentScore);
        Instantiate(rainDrop);
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
}
