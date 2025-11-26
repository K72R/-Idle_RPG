using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuffSystem : MonoBehaviour
{
    public static PlayerBuffSystem Instance;

    private void Awake() => Instance = this;

    public void ApplyBuff(ItemData item)
    {
        StartCoroutine(BuffRoutine(item));
    }

    IEnumerator BuffRoutine(ItemData item)
    {
        float duration = item.duration;

        int originalAtk = PlayerStats.Instance.attackPower;
        int originalDef = PlayerStats.Instance.defensePower;

        PlayerStats.Instance.attackPower += Mathf.RoundToInt(originalAtk * item.attackPercent);
        PlayerStats.Instance.defensePower += Mathf.RoundToInt(originalDef * item.defensePercent);

        yield return new WaitForSeconds(duration);

        PlayerStats.Instance.attackPower = originalAtk;
        PlayerStats.Instance.defensePower = originalDef;
    }
}
