using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StageSelectUI : MonoBehaviour
{
    public StageData[] stages;
    public Transform buttonParent;
    public GameObject buttonPrefab;

    private void Start()
    {
        foreach (var stage in stages)
        {
            GameObject btn = Instantiate(buttonPrefab, buttonParent);
            btn.GetComponentInChildren<TMPro.TMP_Text>().text = stage.stageName;

            btn.GetComponent<Button>().onClick.AddListener(() =>
            {
                StageManager.Instance.StartStage(stage);
                gameObject.SetActive(false);
            });
        }
    }
}
