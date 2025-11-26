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

    public int maxSlots = 50;

    public List<InventorySlot> items = new List<InventorySlot>();

    public void AddItem(ItemData item)
    {
        if (item.itemType == ItemType.Potion ||
            item.itemType == ItemType.BuffItem ||
            item.itemType == ItemType.Consumable)
        {
            foreach (var slot in items)
            {
                if (slot.item == item)
                {
                    slot.amount++;
                    return;
                }
            }
        }

        if (items.Count >= maxSlots)
        {
            Debug.Log("인벤토리 가득 찼음!");
            return;
        }

        items.Add(new InventorySlot(item));
    }

    public void RemoveItem(ItemData item)
    {
        var slot = items.Find(x => x.item == item);
        if (slot != null)
        {
            slot.amount--;
            if (slot.amount <= 0)
                items.Remove(slot);
        }
    }
}