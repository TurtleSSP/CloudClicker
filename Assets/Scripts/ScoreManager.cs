using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text warningText;
    public TMP_Text scoreTxt;
    [SerializeField] TMP_Text up1LevelText;
    [SerializeField] TMP_Text up1PriceText;

    [SerializeField] GameObject rainDrop;

    [SerializeField] float up1Price;

    int up1Level = 0;
    public int currentScore = 0;
    public int scoreToAdd = 0;
    int clickAmount = 1;

    void Start()
    {
        InvokeRepeating("AddAutoScore", 0, 1);
        StartCoroutine(RainDown());
        up1LevelText.SetText("" + up1Level);
        up1PriceText.SetText("" + up1Price);
        scoreText.color = Color.yellow;
        warningText.color = Color.red;
        warningText.enabled = false;
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

    public void Upgrade1()
    {
        if(currentScore >= up1Price)
        {
            scoreToAdd++;
            up1Level++;
            currentScore = currentScore - (int)up1Price;
            up1Price = Mathf.Round(up1Price * 1.3f);

            scoreTxt.SetText("Score: " + currentScore);
            up1LevelText.SetText("" + up1Level);
            up1PriceText.SetText("" + up1Price);
            warningText.enabled = false;
        }
        else
        {
            warningText.SetText("Not Enough Raindrops!");
            warningText.enabled = true;
        }
    }
}
