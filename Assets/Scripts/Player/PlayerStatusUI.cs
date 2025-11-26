using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatusUI : MonoBehaviour
{
    public Slider hpBar;
    public Slider mpBar;
    public Slider expBar;

    public TMP_Text goldText;
    public TMP_Text stageText;

    private void Update()
    {
        hpBar.value = (float)PlayerStats.Instance.currentHp / PlayerStats.Instance.maxHp;
        mpBar.value = (float)PlayerStats.Instance.currentMp / PlayerStats.Instance.maxMp;
        expBar.value = (float)PlayerStats.Instance.exp / PlayerStats.Instance.expToNext;

        goldText.text = CurrencyManager.Instance.gold.ToString();
        stageText.text = StageManager.Instance.currentStage != null ? StageManager.Instance.currentStage.stageName : "-";
    }
}
