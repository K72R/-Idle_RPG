using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemUse : MonoBehaviour
{
    public void UseItem(ItemData item)
    {
        if (item.itemType == ItemType.Potion)
        {
            EquipmentManager.Instance.UsePotion(item);
        }
        else
        {
            EquipmentManager.Instance.EquipItem(item);
        }
    }
}
