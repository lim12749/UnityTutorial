using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthSystem : MonoBehaviour 
{
    public float StartingHealth = 100f; //ó�� ���� ü��
    public float Health { get; private set; } //���� ü��
    public bool isDead { get; private set; } //�׾����� üũ

    public event Action OnDeath; //�̺�Ʈ�� ����ؼ� ���߿� ȣ���Ͽ� ó��

    
    protected virtual void OnEnable()
    {
        isDead = false;
        Health = StartingHealth; //ó�� ü������ �ʱ�ȭ
    }
    //ü�� ���� �޼ҵ�
    public virtual void OnDamage(float _damage)
    {
        Health -= _damage; //ü�� ����

        if(Health <=0 && !isDead)
        {
            Die();
        }
    }
    //ü�� ȸ�� ���
    public virtual void RestoreHealth(float _newHealth)
    {
        if(isDead)
        {
            return; //�̹� �׾��ٸ� ȸ�� ����
        }
        Health -= _newHealth; //ü�� ȸ��
    }

    //���ó�� �޼ҵ�
    public virtual void Die()
    {
        //�̺�Ʈ�� ����� OnDeath �̺�Ʈ�� ����� �޼ҵ尡 �ִٸ�
        if(OnDeath !=null)
        {
            OnDeath(); //�ϰ� �̺�Ʈ ������
        }
        isDead = true; //��� ���� ����
    }

}
