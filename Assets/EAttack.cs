using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EAttack : MonoBehaviour
{
    public int damage = 5;
    private float attackRange = 10f;
    public LayerMask playerLayer;

    private float lastAttack = 0;
    private float attackCoolTime = 1f;

    private void EAttackSystem()
    {
        if (Time.time > attackCoolTime)
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, attackRange, playerLayer);
            if (hitColliders.Length > 0)
            {
                HP playerHp = hitColliders[0].GetComponent<HP>();
                Debug.Log("Attack Player");
                playerHp.Damage(damage);
            }
            lastAttack = Time.time;
        }
    }
    private void Update()
    {
        if (Time.time > lastAttack + attackCoolTime)
        {
            EAttackSystem();
        }
    }
}