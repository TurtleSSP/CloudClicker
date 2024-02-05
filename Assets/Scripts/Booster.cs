using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Booster : MonoBehaviour
{
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] int boostAmount = 2;
    [SerializeField] int boostTime = 10;
    bool boostActive = false;

    IEnumerator Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        yield return new WaitForSeconds(boostTime*2);
        if (boostActive)
        {
            gameObject.transform.localScale = new Vector3(0, 0, 0);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Boost()
    {
        StartCoroutine(scoreManager.BoostTime(gameObject, boostAmount, boostTime, boostActive));
        gameObject.transform.localScale = new Vector3(0, 0, 0);
    }
}
