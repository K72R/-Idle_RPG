using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    private void Awake() => Instance = this;

    public List<InventorySlot> items = new List<InventorySlot>();

    public void AddItem(ItemData item)
    {
        foreach (var slot in items)
        {
            if (slot.item == item)
            {
                slot.amount++;
                return;
            }
        }

        items.Add(new InventorySlot(item));
    }

    public void RemoveItem(ItemData item)
    {
        var slot = items.Find(x => x.item == item);
        if (slot != null)
        {
            slot.amount--;
            if (slot.amount <= 0) items.Remove(slot);
        }
    }
}