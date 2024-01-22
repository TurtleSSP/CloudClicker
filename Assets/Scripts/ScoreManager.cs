using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreTxt;

    [SerializeField] GameObject rainDrop;

    public int currentScore = 0;
    public int scoreToAdd = 0;
    int clickAmount = 1;

    void Start()
    {
        InvokeRepeating("AddAutoScore", 0, 1);
        StartCoroutine(RainDown());
    }

    IEnumerator RainDown()
    {
        Debug.Log("started");
        while(true)
        {
            yield return new WaitForSeconds(0);
            if(scoreToAdd >= 1)
            {
                Debug.Log("raindrop!" + scoreToAdd);
                yield return new WaitForSeconds(1f/scoreToAdd);
                Instantiate(rainDrop);
            }
        }
    }

    void AddAutoScore()
    {
        currentScore = currentScore + scoreToAdd;
        scoreTxt.SetText("Score: " + currentScore);
    }

    public void AddScore()
    {
        currentScore = currentScore + clickAmount;
        scoreTxt.SetText("Score: " + currentScore);
        Instantiate(rainDrop);
    }
}
