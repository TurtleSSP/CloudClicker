using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text up1LevelText;
    [SerializeField] TMP_Text up1PriceText;

    [SerializeField] GameObject rainDrop;

    [SerializeField] float up1Price;

    int up1Level = 0;
    int currentScore = 0;
    int scoreToAdd = 0;
    int clickAmount = 1;
    int up1Amount = 0;

    void Start()
    {
        InvokeRepeating("AddAutoScore", 0, 1);
        StartCoroutine(RainDown());
        up1LevelText.SetText("0");
        up1PriceText.SetText("30");
    }

    IEnumerator RainDown()
    {
        Debug.Log("started");
        while(true)
        {
            if(scoreToAdd > 0)
            {
                Debug.Log("raindrop!");
                yield return new WaitForSeconds(1/scoreToAdd);
                Instantiate(rainDrop);
            }
        }
    }

    void AddAutoScore()
    {
        currentScore = currentScore + scoreToAdd;
        scoreText.SetText("Score: " + currentScore);
    }

    public void AddScore()
    {
        currentScore = currentScore + clickAmount;
        scoreText.SetText("Score: " + currentScore);
        Instantiate(rainDrop);
    }

    public void Upgrade1()
    {
        if(currentScore >= up1Price)
        {
            up1Amount++;
            scoreToAdd++;
            up1Level++;
            currentScore = currentScore - (int)up1Price;
            up1Price = Mathf.Round(up1Price * 1.3f);
            scoreText.SetText("Score: " + currentScore);
            up1LevelText.SetText("" + up1Level);
            up1PriceText.SetText("" + up1Price);
        }
        else
        {
            Debug.Log("Not Enough Clicks");
        }
    }
}
