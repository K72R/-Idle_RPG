using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public List<InventorySlot> items = new List<InventorySlot>();

    public void AddItem(ItemData item)
    {
        // 중복 아이템이면 개수만 증가
        foreach (var slot in items)
        {
            if (slot.item == item)
            {
                slot.amount++;
                Debug.Log($"{item.itemName} 획득 (x{slot.amount})");
                return;
            }
        }

        // 새 슬롯 추가
        items.Add(new InventorySlot(item));
        Debug.Log($"{item.itemName} 획득");
    }

    public void RemoveItem(ItemData item)
    {
        InventorySlot target = items.Find(x => x.item == item);

        if (target != null)
        {
            target.amount--;

            if (target.amount <= 0)
                items.Remove(target);
        }
    }
}
