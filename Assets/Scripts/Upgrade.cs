using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Upgrade : MonoBehaviour
{
    [SerializeField] ScoreManager scoreManager;

    [SerializeField] TMP_Text upgradeLevelTxt;
    [SerializeField] TMP_Text upgradePriceTxt;
    [SerializeField] TMP_Text warningTxt;

    [SerializeField] int autoUpgradeAmount;
    [SerializeField] int clickUpgradeAmount;
    [SerializeField] float priceIncrease;
    [SerializeField] float upgradePrice;

    int upgradeLevel = 0;

    private void Start()
    {
        upgradeLevelTxt.SetText(upgradeLevel.ToString());
        upgradePriceTxt.SetText(upgradePrice.ToString());
        warningTxt.enabled = false;
    }

    public void OnUpgrade()
    {
        if (scoreManager.currentScore >= upgradePrice)
        {
            upgradeLevel++;
            scoreManager.scoreToAdd += autoUpgradeAmount;
            scoreManager.clickAmount += clickUpgradeAmount;
            scoreManager.currentScore -= (int)upgradePrice;
            upgradePrice = Mathf.Round(upgradePrice * priceIncrease);

            upgradeLevelTxt.SetText(upgradeLevel.ToString());
            upgradePriceTxt.SetText(upgradePrice.ToString());
            scoreManager.scoreTxt.SetText("Score: " + scoreManager.currentScore);
            warningTxt.enabled = false;
        }
        else
        {
            warningTxt.enabled = true;
        }
    }
}
