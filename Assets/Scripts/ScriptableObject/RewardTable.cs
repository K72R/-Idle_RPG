using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RewardItemEntry
{
    public ItemData item;     // 포션/무기/방어구 가능
    [Range(0, 100)]
    public float dropChance;  // 확률 %
}

[CreateAssetMenu(fileName = "NewRewardTable", menuName = "RPG/Reward Table")]
public class RewardTable : ScriptableObject
{
    [Header("코인 보상")]
    public int minCoin;
    public int maxCoin;

    [Header("아이템 드랍 테이블 (확률 기반)")]
    public RewardItemEntry[] rewardItems;

    public int GetCoinReward()
    {
        return Random.Range(minCoin, maxCoin + 1);
    }

    public ItemData GetRandomItem()
    {
        float roll = Random.Range(0f, 100f);
        float sum = 0f;

        foreach (var entry in rewardItems)
        {
            sum += entry.dropChance;
            if (roll <= sum)
            {
                return entry.item;
            }
        }

        return null; // 아무 아이템도 안 떴음
    }
}
