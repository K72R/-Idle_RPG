using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public static EquipmentManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public ItemData equippedWeapon;
    public ItemData equippedArmor;

    public void EquipItem(ItemData item)
    {
        if (item.itemType == ItemType.Weapon)
        {
            equippedWeapon = item;
            PlayerStats.Instance.attackPower = item.attackPower;
            Debug.Log($"{item.itemName} 장착 완료! 공격력: {item.attackPower}");
        }
        else if (item.itemType == ItemType.Armor)
        {
            equippedArmor = item;
            PlayerStats.Instance.defensePower = item.defensePower;
            Debug.Log($"{item.itemName} 장착 완료! 방어력: {item.defensePower}");
        }
        else
        {
            Debug.Log("장착할 수 없는 아이템입니다.");
        }
    }

    public void UsePotion(ItemData item)
    {
        if (item.itemType == ItemType.Potion)
        {
            PlayerStats.Instance.Heal(item.healAmount);
            InventoryManager.Instance.RemoveItem(item);
            Debug.Log($"포션 사용: {item.itemName}");
        }
    }
}
