using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewStage", menuName = "RPG/Stage")]
public class StageData : ScriptableObject
{
    public string stageName;

    [Header("스테이지 몬스터 구성")]
    public MonsterData[] monsterList;
    public float spawnDelay = 1f;

    [Header("보상")]
    public RewardTable rewardTable;
}
