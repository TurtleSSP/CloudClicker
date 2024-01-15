using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    int currentScore = 0;
    int scoreToAdd = 0;
    int clickAmount = 1;

    [SerializeField] TMP_Text scoreText;

    void Start()
    {
        InvokeRepeating("AddAutoScore", 0, 1);
    }

    void Update()
    {
        scoreText.SetText("Score: " + currentScore);
    }

    void AddAutoScore()
    {
        currentScore = currentScore + scoreToAdd;
        Debug.Log(currentScore);
    }

    public void AddScore()
    {
        currentScore = currentScore + clickAmount;
    }

    public void Upgrade1()
    {
        scoreToAdd++;
        Debug.Log(currentScore);
    }
}
