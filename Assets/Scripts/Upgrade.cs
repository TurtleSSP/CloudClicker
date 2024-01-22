using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Upgrade : MonoBehaviour
{
    [SerializeField] ScoreManager scoreManager;

    [SerializeField] TMP_Text upgradeLevelTxt;
    [SerializeField] TMP_Text upgradePriceTxt;

    int upgradeLevel = 0;
    [SerializeField] int upgradeAmount;
    [SerializeField] float priceIncrease;
    [SerializeField] float upgradePrice;

    private void Start()
    {
        upgradeLevelTxt.SetText(upgradeLevel.ToString());
        upgradePriceTxt.SetText(upgradePrice.ToString());
    }

    void OnUpgrade()
    {
        if (scoreManager.currentScore >= upgradePrice)
        {
            upgradeLevel++;
            scoreManager.scoreToAdd += upgradeAmount;
            scoreManager.currentScore -= (int)upgradePrice;
            upgradePrice = Mathf.Round(upgradePrice * priceIncrease);

            upgradeLevelTxt.SetText(upgradeLevel.ToString());
            upgradePriceTxt.SetText(upgradePrice.ToString());
            scoreManager.scoreTxt.SetText(scoreManager.currentScore.ToString());
        }
    }
}
