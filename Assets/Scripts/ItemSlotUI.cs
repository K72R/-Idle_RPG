using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotUI : MonoBehaviour
{
    public Image icon;
    public TMP_Text amountText;

    private ItemData item;

    public void Setup(InventorySlot slot)
    {
        item = slot.item;
        icon.sprite = item.icon;
        icon.enabled = (item.icon != null);
        amountText.text = slot.amount.ToString();
    }

    public void OnClick()
    {
        switch (item.itemType)
        {
            case ItemType.Potion:
                EquipmentManager.Instance.UsePotion(item);
                break;

            case ItemType.Weapon:
            case ItemType.Armor:
                EquipmentManager.Instance.EquipItem(item);
                break;

            case ItemType.BuffItem:
            case ItemType.Consumable:
                PlayerBuffSystem.Instance.ApplyBuff(item);
                InventoryManager.Instance.RemoveItem(item);
                break;
        }

        InventoryUI ui = FindObjectOfType<InventoryUI>();
        ui.Refresh();
    }
}