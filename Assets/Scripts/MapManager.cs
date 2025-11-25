using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public static MapManager Instance;

    [Header("Map Prefabs (Map/1, Map/2, Map/3)")]
    public GameObject[] mapPrefabs;

    private GameObject currentMap;
    private int currentIndex = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        LoadNextMap();
    }

    public void LoadNextMap()
    {
        // ÀÌÀü ¸Ê Á¦°Å
        if (currentMap != null)
        {
            Destroy(currentMap);
        }

        // ¸Ê ÀÎµ¦½º Áõ°¡ (¼øÈ¯)
        currentIndex = (currentIndex + 1) % mapPrefabs.Length;

        // »õ ¸Ê »ý¼º
        currentMap = Instantiate(mapPrefabs[currentIndex], transform);

        Debug.Log($"Map Loaded: {currentIndex + 1}");
    }
}
