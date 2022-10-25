using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : HealthSystem
{
    
    private HealthSystem _target; //추적할 대상 
    private NavMeshAgent _pathFinder; //경로 추적을 담당하는 AI 시스템
    private Animator _myAnimator; //몬스터 에니메이션 처리
    
    [Header("Mostet INFO")]
    public float Damage = 10f;
    public float timeBetAccack = 0.5f; //공격 간격
    public float AttackRange = 10f;
    private float lastAttackTime; //마지막 공격시점

    [SerializeField] LayerMask _whatIsTarget; //레이어를 이용하여 추적할 대상 결정

    [Header("Effect")]
    public AudioSource MyAudiosource; //오디오 소스
    public AudioClip hitSound; //사운드 피격 클립
    public AudioClip deathSound; //사운드 죽음 클립
    
    //추적 대상이 있는지 체크하는 프로퍼티
    private bool _hasTarget
    {
        get
        {
            //클래스가 Null이 아니고 그리고 죽지 않았을경우
            if (_target != null && !_target.isDead)
            {
                //살아있으니 hasTarget = 참
                return true;
            }
            else
                return false;
        }
    }

    private void Awake()
    {
        //클래스 링크
        _pathFinder = GetComponent<NavMeshAgent>();
        _myAnimator = GetComponent<Animator>();
        MyAudiosource = GetComponent<AudioSource>();
    }

    //몬스터를 생성할때 초기 스펙을 결정.
    public void Setup(float _health , float _damage, float _speed)
    {
        StartingHealth = _health; //체력
        Damage = _damage; //공격력
        _pathFinder.speed = _speed; //이동속도 추적대상을 쫒아가는데 속도
    }

    private void Start()
    {
        StartCoroutine(UpdatePath());
    }
    private void Update()
    {
        _myAnimator.SetBool("HasTarget", _hasTarget);
    }
    //추적합니다.
    private IEnumerator UpdatePath()
    {
        //죽지 않았다면
        while(!isDead)
        {
            //추적 대상이 있다면
            if(_hasTarget)
            {
                _pathFinder.isStopped = false; //근처가도 멈추지않고 계속 추적함
                _pathFinder.SetDestination(_target.transform.position);//추적대상위치까지 이동시킴
            }
            else //추적대상이 죽엇거나 없으면
            {
                _pathFinder.isStopped = true; //멈추고 대기상태가됨

                //핵심 기술 b n
                Collider[] colliders = Physics.OverlapSphere(transform.position, AttackRange, _whatIsTarget);

                for(int i=0;i<colliders.Length;i++)
                {
                    //콜라이더에 컴포넌트가 있는 객체가 있는지 확인후 가져옴
                    HealthSystem healthSystem = colliders[i].GetComponent<HealthSystem>();
                    //객체가 있는지 체크
                    if(healthSystem!=null &&!healthSystem.isDead)
                    {
                        _target = healthSystem; //찾은 객체를 다시 타겟으로 삼음

                        break; //반복문 바로 탈출
                    }
                }
            }
            //0.25초를 주기로 반복함
            yield return new WaitForSeconds(0.25f); //
        }
    }

    //상속받은 메소드 
    public override void OnDamage(float _damage )
    {
        //죽지않았다면 
        if(!isDead)
        {
            //효과 사운드 여기서 재생
            //_myAnimator.SetBool("Hit", _isHit);

        }
        //데미지 적용
        base.OnDamage(Damage);
    }
    //사망처리 
    public override void Die()
    {
        base.Die();

        //다른 AI에 방해 안되게 콜라이더 비활성화
        Collider[] enemyCol = GetComponents<Collider>();
        for(int i=0;i<enemyCol.Length; i++)
        {
            enemyCol[i].enabled = false;
        }
        _pathFinder.isStopped = true; //멈춤
        _pathFinder.enabled = false; //네브메시도 끔

        //사망 애니메이션 재생ㄴㄴㅇ
        _myAnimator.SetTrigger("Die");
        //사망 효과음 재생ㅇㅇ
    }
    //몬스터 공격 처리
    public void OnTriggerStay(Collider other)
    {
        //죽지않고 마지막 공격시점에서 + 딜레이 시간 만큼 지났을경우
        if(!isDead && Time.time >= lastAttackTime + timeBetAccack)
        {
            //상대방이 가지고있는지 체크 
            HealthSystem attacTarget = other.GetComponent<HealthSystem>();

            if(attacTarget!=null &&attacTarget ==_target)
            {
                //공격 시간 갱신
                lastAttackTime = Time.time;

                Vector3 hipoint = other.ClosestPoint(transform.position);
                Vector3 hitNomal = transform.position - other.transform.position;

                //공격 처리 피격은 플레이어 헬스에서 처리
                attacTarget.OnDamage(Damage);
            }
        }
    }
}
