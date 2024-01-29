using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour
{
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] int boostAmount = 2;
    [SerializeField] int boostTime = 10;

    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    public void Boost()
    {
        StartCoroutine(BoostTime());
    }

    IEnumerator BoostTime()
    {
        scoreManager.scoreBoost = boostAmount;
        yield return new WaitForSeconds(boostTime);
        scoreManager.scoreBoost = 1;
        Destroy(gameObject);
    }
}
