using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject monsterPrefab;

    public IEnumerator SpawnStage(StageData data)
    {
        foreach (var monsterData in data.monsterList)
        {
            GameObject obj = Instantiate(monsterPrefab, transform.position, Quaternion.identity);

            Monster monster = obj.GetComponent<Monster>();
            monster.data = monsterData;

            yield return new WaitForSeconds(data.spawnDelay);
        }
    }
}
