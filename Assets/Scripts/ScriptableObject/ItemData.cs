using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Potion,
    Weapon,
    Armor,
    BuffItem,
    Consumable
}

public enum ItemGradde
{
    Normal,
    Rare,
    Epic,
    Legendary
}

[CreateAssetMenu(fileName = "NewItem", menuName = "RPG/Item")]
public class ItemData : ScriptableObject
{
    [Header("기본 정보")]
    public ItemType itemType;
    public string itemName;
    [TextArea] public string description;
    public Sprite icon;

    [Header("포션")]
    public int healAmount;

    [Header("무기")]
    public int attackPower;

    [Header("방어구")]
    public int defensePower;

    [Header("버프/소모품 공통")]
    public float duration;          // 지속시간
    public float attackPercent;
    public float defensePercent;

    [Header("아이템 등급")]
    public ItemGradde itemGrade;
    public int itemLevel;
}