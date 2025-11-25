using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Potion,
    Weapon,
    Armor
}

[CreateAssetMenu(fileName = "NewItem", menuName = "RPG/Item")]
public class ItemData : ScriptableObject
{
    [Header("공통 정보")]
    public ItemType itemType;
    public string itemName;
    [TextArea] public string description;

    [Header("포션")]
    public int healAmount;

    [Header("무기")]
    public int attackPower;

    [Header("방어구")]
    public int defensePower;
}