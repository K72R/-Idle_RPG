using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;

    private void Awake()
    {
        Instance = this;
    }

    [Header("기본 스탯")]
    public int maxHp = 100;
    public int currentHp = 100;
    public int attackPower = 10;
    public int defensePower = 5;

    public void Heal(int amount)
    {
        currentHp += amount;
        if (currentHp > maxHp)
            currentHp = maxHp;

        Debug.Log($"체력 회복: +{amount}, 현재 체력: {currentHp}");
    }
}
