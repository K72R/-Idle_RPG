using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject monsterPrefab;
    public MonsterData monsterData;

    public void Spawn()
    {
        GameObject mon = Instantiate(monsterPrefab, transform.position, Quaternion.identity);

        Monster m = mon.GetComponent<Monster>();
        m.data = monsterData;

        Debug.Log($"{monsterData.monsterName} 스폰 완료!");
    }
}
