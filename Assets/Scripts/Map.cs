using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Map : MonoBehaviour
{
    [Header("Monster spawn points")]
    public Transform[] spawnPoints;

    [Header("Monster Prefab")]
    public GameObject monsterPrefab;

    private List<Monster> monsters = new List<Monster>();

    private void Start()
    {
        SpawnAllMonsters();
    }

    private void SpawnAllMonsters()
    {
        foreach (Transform point in spawnPoints)
        {
            GameObject m = Instantiate(monsterPrefab, point.position, Quaternion.identity, this.transform);
            Monster monster = m.GetComponent<Monster>();
            monster.SetMap(this);

            monsters.Add(monster);
        }
    }

    public void MonsterDied(Monster monster)
    {
        monsters.Remove(monster);

        if (monsters.Count == 0)
        {
            Debug.Log("맵 클리어! 다음 맵으로 이동");
            MapManager.Instance.LoadNextMap();
        }
    }
}
