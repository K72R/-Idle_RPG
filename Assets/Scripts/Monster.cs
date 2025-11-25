using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private Map belongingMap;
    public int hp = 5;

    public void SetMap(Map map)
    {
        belongingMap = map;
    }

    public void TakeDamage(int dmg)
    {
        hp -= dmg;

        if (hp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        belongingMap.MonsterDied(this);
        Destroy(gameObject);
    }
}
