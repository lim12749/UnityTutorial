using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthSystem : MonoBehaviour 
{
    public float StartingHealth = 100f; //처음 시작 체력
    public float Health { get; private set; } //현재 체력
    public bool isDead { get; private set; } //죽엇는지 체크

    public event Action OnDeath; //이벤트를 등록해서 나중에 호출하여 처리

    
    protected virtual void OnEnable()
    {
        isDead = false;
        Health = StartingHealth; //처음 체력으로 초기화
    }
    //체력 감소 메소드
    public virtual void OnDamage(float _damage)
    {
        Health -= _damage; //체력 감소

        if(Health <=0 && !isDead)
        {
            Die();
        }
    }
    //체력 회복 기능
    public virtual void RestoreHealth(float _newHealth)
    {
        if(isDead)
        {
            return; //이미 죽었다면 회복 못함
        }
        Health -= _newHealth; //체력 회복
    }

    //사망처리 메소드
    public virtual void Die()
    {
        //이벤트에 연결된 OnDeath 이벤트에 연결된 메소드가 있다면
        if(OnDeath !=null)
        {
            OnDeath(); //일괄 이벤트 실행함
        }
        isDead = true; //사망 상태 변경
    }

}
