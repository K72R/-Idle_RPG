using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAI : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float attackRange = 1.5f;
    public float attackInterval = 1f;

    private bool isAttacking = false;
    private Transform player;

    private Monster monster;
    private MonsterData data;

    private void Start()
    {
        player = PlayerStats.Instance.transform;

        monster = GetComponent<Monster>();
        data = monster.data;
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance > attackRange)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                player.position,
                moveSpeed * Time.deltaTime
            );
        }
        else
        {
            if (!isAttacking)
                StartCoroutine(AttackRoutine());
        }
    }

    IEnumerator AttackRoutine()
    {
        isAttacking = true;

        PlayerStats.Instance.currentHp -= data.attackPower;

        yield return new WaitForSeconds(attackInterval);

        isAttacking = false;
    }
}
