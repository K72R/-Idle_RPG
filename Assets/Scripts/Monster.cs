using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public MonsterData data;

    private int currentHp;

    private void Start()
    {
        currentHp = data.maxHp;
    }

    public void TakeDamage(int dmg)
    {
        int finalDmg = Mathf.Max(1, dmg - data.defensePower);

        currentHp -= finalDmg;

        Debug.Log($"{data.monsterName} 피격: -{finalDmg}, 남은 체력 {currentHp}");

        if (currentHp <= 0)
            Die();
    }

    private void Die()
    {
        Debug.Log($"{data.monsterName} 사망!");
        Destroy(gameObject);
    }
}
