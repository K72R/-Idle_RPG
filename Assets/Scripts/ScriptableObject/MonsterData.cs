using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewMonster", menuName = "RPG/Monster")]
public class MonsterData : ScriptableObject
{
    public string monsterName;
    [TextArea] public string description;

    [Header("전투 능력치")]
    public int maxHp;  // 최대체력
    public int attackPower; // 공격력
    public int defensePower; // 방어력

    [Header("행동 스탯")]
    public float moveSpeed; // 이동속도
    public float attackSpeed; // 공격속도.
}
