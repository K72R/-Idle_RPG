using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;

    private void Awake() => Instance = this;

    [Header("스탯")]
    public int level = 1;
    public int exp = 0;
    public int expToNext = 100;

    public int maxHp = 100;
    public int currentHp = 100;

    public int maxMp = 50;
    public int currentMp = 50;

    public int attackPower = 10;
    public int defensePower = 5;

    public void Heal(int amount)
    {
        currentHp = Mathf.Min(currentHp + amount, maxHp);
    }

    public void GainExp(int amount)
    {
        exp += amount;
        if (exp >= expToNext)
        {
            exp -= expToNext;
            level++;
            expToNext += 50;
        }
    }
}
