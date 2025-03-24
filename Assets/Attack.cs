using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int damage = 5;
    private float attackRange = 10f;
    public LayerMask enemyLayr;
    public Camera cam;
    private Ray ray;
    RaycastHit hit;

    private float lastAttack = 0;
    private float attackCoolTime = 1f;

    private void AttackSystem()
    {
        if (Time.time > attackCoolTime) 
        {
            if (Physics.Raycast(ray, out hit, attackRange, enemyLayr))
            {
                HP enemyHp = hit.collider.GetComponent<HP>();
                Debug.Log("Attack Enemy");
                enemyHp.Damage(damage);
            }
            lastAttack = Time.time;
        }
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); ;

            if (Physics.Raycast(ray, out hit, attackRange, enemyLayr))
            {
                if (hit.collider.gameObject.CompareTag("Enemy"))
                {
                    AttackSystem();
                }
            }
        }
    }
}
