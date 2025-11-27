using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class StageSelectUI : MonoBehaviour
{
    public StageData[] stages;
    public TMP_Text selectedStageNameText;

    private StageData selectedStage;

    private void Start()
    {
        if (stages.Length > 0)
            SelectStage(0);
    }

    public void SelectStage(int index)
    {
        if (index < 0 || index >= stages.Length) return;

        selectedStage = stages[index];
        selectedStageNameText.text = selectedStage.stageName;
    }

    public void OnClickStart()
    {
        if (selectedStage == null) return;

        StageTransfer.selectedStage = selectedStage;

        SceneManager.LoadScene("IdleScene");
    }

    public static class StageTransfer
    {
        public static StageData selectedStage;
    }
}
