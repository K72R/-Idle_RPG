using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager Instance;

    private void Awake() => Instance = this;

    public int gold = 0;
    public int gem = 0;

    public void AddGold(int amount)
    {
        gold += amount;
    }

    public void AddGem(int amount)
    {
        gem += amount;
    }
}
