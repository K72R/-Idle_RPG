using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IdleHUD : MonoBehaviour
{
    public TMP_Text gemText;
    public TMP_Text goldText;
    public TMP_Text atkText;
    public TMP_Text defText;

    private void Update()
    {
        if (CurrencyManager.Instance != null)
        {
            gemText.text = $"Gem: {CurrencyManager.Instance.gem}";
            goldText.text = $"Gold: {CurrencyManager.Instance.gold}";
        }

        if (PlayerStats.Instance != null)
        {
            atkText.text = $"ATK: {PlayerStats.Instance.attackPower}";
            defText.text = $"DEF: {PlayerStats.Instance.defensePower}";
        }
    }
}
