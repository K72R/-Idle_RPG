using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public UpgradeConfig upgradeConfig;

    [Header("강화 및 융합에 사용할 아이템")]
    public ItemData enhanceScrollItem;
    public ItemData fusionScrollItem;

    public bool TryEnhance(ItemData baseItem, out ItemData result)
    {
        result = baseItem;

        var rule = System.Array.Find(upgradeConfig.enhanceRules, r => r.baseItem == baseItem);
        if(rule == null)
        {
            return false;
        }

        int count = GetItemCount(enhanceScrollItem);
        if(count < rule.requiredEnhanceScrollCount)
        {
            return false;
        }

        ConsumeItem(enhanceScrollItem, rule.requiredEnhanceScrollCount);

        if(Random.value <= rule.successRate)
        {
            result = rule.enhancedItem;
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool TryFusion(ItemData Item1, ItemData Item2, out ItemData result)
    {
        result = Item1;

        if(Item1.itemGrade != Item2.itemGrade)
        {
            return false;
        }

        var rule = System.Array.Find(upgradeConfig.fusionRules, r => r.fromGrade == Item1.itemGrade);

        if (Random.value <= rule.successRate)
        {
            Debug.Log("융합 성공");
            return true;
        }
        else
        {
            Debug.Log("융합 실패");
            return false;
        }
    }

    private int GetItemCount(ItemData item)
    {
        int total = 0;
        foreach (var slot in InventoryManager.Instance.items)
        {
            if (slot.item == item)
            {
                total += slot.amount;
            }
        }
        return total;
    }

    private void ConsumeItem(ItemData item, int amount)
    {
        for(int i=0; i<amount; i++)
        {
            InventoryManager.Instance.RemoveItem(item);
        }
    }
}
