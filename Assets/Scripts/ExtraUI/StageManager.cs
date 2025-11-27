using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static StageSelectUI;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance;

    public StageData currentStage;
    public MonsterSpawner spawner;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        if (StageTransfer.selectedStage != null)
        {
            StartStage(StageTransfer.selectedStage);
        }
    }

    public void StartStage(StageData stage)
    {
        currentStage = stage;

        if (spawner != null)
        {
            StartCoroutine(spawner.SpawnStage(stage));
        }
        else
        {
            Debug.LogError("연결 확인하자");
        }
    }
}
