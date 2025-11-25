using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 플레이어 앞 몬스터 공격
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 3f))
            {
                if (hit.collider.TryGetComponent(out Monster m))
                {
                    m.TakeDamage(1);
                }
            }
        }
    }
}
