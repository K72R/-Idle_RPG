using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    Move,
    Attack,
}

public class PlayerAI : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float attackRange = 2f;
    public float attackInterval = 1f;

    private PlayerState state = PlayerState.Move;
    private bool isAttacking = false;

    private void Update()
    {
        switch (state)
        {
            case PlayerState.Move:
                MoveForward();
                DetectEnemy();
                break;

            case PlayerState.Attack:
                if (!isAttacking)
                    StartCoroutine(AttackRoutine());
                break;
        }
    }

    void MoveForward()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    void DetectEnemy()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, attackRange))
        {
            if (hit.collider.TryGetComponent(out Monster monster))
            {
                state = PlayerState.Attack;
            }
        }
    }

    IEnumerator AttackRoutine()
    {
        isAttacking = true;

        Ray ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, attackRange))
        {
            if (hit.collider.TryGetComponent(out Monster monster))
            {
                monster.TakeDamage(PlayerStats.Instance.attackPower);
            }
        }

        yield return new WaitForSeconds(attackInterval);
        isAttacking = false;

        state = PlayerState.Move;
    }
}
