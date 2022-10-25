using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : HealthSystem
{
    
    private HealthSystem _target; //������ ��� 
    private NavMeshAgent _pathFinder; //��� ������ ����ϴ� AI �ý���
    private Animator _myAnimator; //���� ���ϸ��̼� ó��
    
    [Header("Mostet INFO")]
    public float Damage = 10f;
    public float timeBetAccack = 0.5f; //���� ����
    public float AttackRange = 10f;
    private float lastAttackTime; //������ ���ݽ���

    [SerializeField] LayerMask _whatIsTarget; //���̾ �̿��Ͽ� ������ ��� ����

    [Header("Effect")]
    public AudioSource MyAudiosource; //����� �ҽ�
    public AudioClip hitSound; //���� �ǰ� Ŭ��
    public AudioClip deathSound; //���� ���� Ŭ��
    
    //���� ����� �ִ��� üũ�ϴ� ������Ƽ
    private bool _hasTarget
    {
        get
        {
            //Ŭ������ Null�� �ƴϰ� �׸��� ���� �ʾ������
            if (_target != null && !_target.isDead)
            {
                //��������� hasTarget = ��
                return true;
            }
            else
                return false;
        }
    }

    private void Awake()
    {
        //Ŭ���� ��ũ
        _pathFinder = GetComponent<NavMeshAgent>();
        _myAnimator = GetComponent<Animator>();
        MyAudiosource = GetComponent<AudioSource>();
    }

    //���͸� �����Ҷ� �ʱ� ������ ����.
    public void Setup(float _health , float _damage, float _speed)
    {
        StartingHealth = _health; //ü��
        Damage = _damage; //���ݷ�
        _pathFinder.speed = _speed; //�̵��ӵ� ��������� �i�ư��µ� �ӵ�
    }

    private void Start()
    {
        StartCoroutine(UpdatePath());
    }
    private void Update()
    {
        _myAnimator.SetBool("HasTarget", _hasTarget);
    }
    //�����մϴ�.
    private IEnumerator UpdatePath()
    {
        //���� �ʾҴٸ�
        while(!isDead)
        {
            //���� ����� �ִٸ�
            if(_hasTarget)
            {
                _pathFinder.isStopped = false; //��ó���� �������ʰ� ��� ������
                _pathFinder.SetDestination(_target.transform.position);//���������ġ���� �̵���Ŵ
            }
            else //��������� �׾��ų� ������
            {
                _pathFinder.isStopped = true; //���߰� �����°���

                //�ٽ� ��� b n
                Collider[] colliders = Physics.OverlapSphere(transform.position, AttackRange, _whatIsTarget);

                for(int i=0;i<colliders.Length;i++)
                {
                    //�ݶ��̴��� ������Ʈ�� �ִ� ��ü�� �ִ��� Ȯ���� ������
                    HealthSystem healthSystem = colliders[i].GetComponent<HealthSystem>();
                    //��ü�� �ִ��� üũ
                    if(healthSystem!=null &&!healthSystem.isDead)
                    {
                        _target = healthSystem; //ã�� ��ü�� �ٽ� Ÿ������ ����

                        break; //�ݺ��� �ٷ� Ż��
                    }
                }
            }
            //0.25�ʸ� �ֱ�� �ݺ���
            yield return new WaitForSeconds(0.25f); //
        }
    }

    //��ӹ��� �޼ҵ� 
    public override void OnDamage(float _damage )
    {
        //�����ʾҴٸ� 
        if(!isDead)
        {
            //ȿ�� ���� ���⼭ ���
            //_myAnimator.SetBool("Hit", _isHit);

        }
        //������ ����
        base.OnDamage(Damage);
    }
    //���ó�� 
    public override void Die()
    {
        base.Die();

        //�ٸ� AI�� ���� �ȵǰ� �ݶ��̴� ��Ȱ��ȭ
        Collider[] enemyCol = GetComponents<Collider>();
        for(int i=0;i<enemyCol.Length; i++)
        {
            enemyCol[i].enabled = false;
        }
        _pathFinder.isStopped = true; //����
        _pathFinder.enabled = false; //�׺�޽õ� ��

        //��� �ִϸ��̼� ���������
        _myAnimator.SetTrigger("Die");
        //��� ȿ���� �������
    }
    //���� ���� ó��
    public void OnTriggerStay(Collider other)
    {
        //�����ʰ� ������ ���ݽ������� + ������ �ð� ��ŭ ���������
        if(!isDead && Time.time >= lastAttackTime + timeBetAccack)
        {
            //������ �������ִ��� üũ 
            HealthSystem attacTarget = other.GetComponent<HealthSystem>();

            if(attacTarget!=null &&attacTarget ==_target)
            {
                //���� �ð� ����
                lastAttackTime = Time.time;

                Vector3 hipoint = other.ClosestPoint(transform.position);
                Vector3 hitNomal = transform.position - other.transform.position;

                //���� ó�� �ǰ��� �÷��̾� �ｺ���� ó��
                attacTarget.OnDamage(Damage);
            }
        }
    }
}
