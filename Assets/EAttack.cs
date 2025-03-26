using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EAttack : MonoBehaviour
{
    public int damage = 5; //공격 데미지 값
    private float attackRange = 10f; //공격범위
    public LayerMask playerLayer; //공격받을 플레이어 레이어

    private float lastAttack = 0; //마지막 공격 시점
    private float attackCoolTime = 1f; //공격 쿨타임(1s)

    private void EAttackSystem()
    {
        if (Time.time > attackCoolTime)  //현재 시간이 쿨타임보다 크면 (즉, 공격 쿨타임이 끝났다면)
        {
            //현재 위치를 중심으로 공격범위 내에 있는 플레이어를 찾음
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, attackRange, playerLayer);
            //*Colider 오브젝트 간의 충돌체 처리

            if (hitColliders.Length > 0) //범위 내에 플레이어가 존재하면
            {
                HP playerHp = hitColliders[0].GetComponent<HP>(); //첫 번째 충돌 객체에서 hP를 가져옴
                Debug.Log("Attack Player"); //콘솔에 "Attack Player" 메시지 출력
                //*Debug.log=예상못한 동작 추적 및 실행중 객체의 상테나 변수 값 변화 확인, 코드 블록이 실행 또는 조건이 옳은지 체크함.
                playerHp.Damage(damage); //플레이어에게 데미지를 입힘
            }
            lastAttack = Time.time; // 마지막 공격 시점을 현재 시간으로 갱신
        }
    }
    private void Update()
    {
        if (Time.time > lastAttack + attackCoolTime) //시건이 지난 후 공격이 가능한 경우
            //실행 후 경과된 시간 반환
        {
            EAttackSystem(); //공격 시스템 실행
            //*메서드 함수를 추출할떄 사용 /선언- 매개변수,반환값 정의 /호출-실행하는 ㅂ부분
        }
    }
}
