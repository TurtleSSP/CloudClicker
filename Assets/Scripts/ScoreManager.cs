using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    int currentScore = 0;
    int scoreToAdd = 0;
    int clickAmount = 1;

    void Start()
    {
        InvokeRepeating("AddAutoScore", 0, 1);
    }

    void AddAutoScore()
    {
        currentScore = currentScore + scoreToAdd;
        Debug.Log(currentScore);
    }

    public void AddScore()
    {
        currentScore = currentScore + clickAmount;
        Debug.Log(currentScore);
    }

    public void Upgrade1()
    {
        scoreToAdd++;
    }
}
