using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBooster : MonoBehaviour
{
    ScoreManager scoreManager;
    [SerializeField] int addAmount = 100;

    private void Awake()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    public void BoostScore()
    {
        scoreManager.AddBoostScore(addAmount);
        Destroy(gameObject);
    }
}
