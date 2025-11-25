using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance;
    private void Awake() => Instance = this;

    public MonsterSpawner spawner;
    public StageData currentStage;

    public void StartStage(StageData data)
    {
        currentStage = data;
        StartCoroutine(spawner.SpawnStage(data));
    }

    public void CompleteStage()
    {
        int gold = currentStage.rewardTable.GetCoinReward();
        CurrencyManager.Instance.AddGold(gold);

        ItemData reward = currentStage.rewardTable.GetRandomItem();
        if (reward != null)
            InventoryManager.Instance.AddItem(reward);
    }
}
