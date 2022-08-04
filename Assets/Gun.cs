using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public enum GunState
    {
        //총알이 다있는경우, 비어있는 겨우, 재장전이 필요한 경우,
        Ready, 
        Emtpy, 
        Reloading
    }

    //get은 다른 사용자가 값을 가져갈수 있음.
    //set 변수에 값을 할당할수 있음.
    public GunState gunState { get; private set; }

    public AudioSource audioSource; //소리를 관리하는 기능
    public AudioClip gunFireSound; //소리를 가진 칩

    public LineRenderer bulletLine; //화면에 선을 그리는 기능
    public Transform gunFirePosition; //위치를 관리하는 기능
    
    public float timenow;
    
    //총연사 관련 정보
    public float lastFireTime;// 총을 마지막으로 발사한 시점
    public float fireDelayTime =0.12f; //총을 발사한 지연시간 (연사력)

    //총 상태 정보
    public float damage = 10f;
    public float distance;
    public int ammoToFill; //남은 총알 계산

    public int ammoReMain; //남은 전체 총알 270
    public int magazineSize; //탄창크기 30
    public int magazineAmmo; //탄창에 남은 총알 30
    public float reloadTime; //재장전이 걸리는 시간

    private void Start()
    {
        //소리를 관리하는 기능을 가져옴
        audioSource = GetComponent<AudioSource>();
        bulletLine = GetComponent<LineRenderer>();
        //총 상태를 준비상태로 만듬
        gunState = GunState.Ready;
    }
    private void Update()
    {
        timenow = Time.time;
        //마우스 클릭
        if (Input.GetButton("Fire1"))
        {
            if (gunState == GunState.Ready && Time.time >= lastFireTime + fireDelayTime)
            {
                RaycastHit hit;

                if (Physics.Raycast(gunFirePosition.position, gunFirePosition.forward * distance, out hit))
                {
                    Debug.Log(hit.collider.name);
                }
                Debug.DrawRay(gunFirePosition.position, gunFirePosition.forward * distance,
                    Color.red);

                StartCoroutine(ShotEffect(hit.point));
                lastFireTime = Time.time;
                magazineAmmo --;
                if(magazineAmmo<=0)
                {
                    gunState = GunState.Emtpy;
                }
            }
        }
        //제장전 코드
        if(Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("재장전 버튼 누름");
            if(gunState ==GunState.Reloading || ammoReMain <= 0
                || magazineAmmo >= magazineSize)
            {
                return;
            }
            StartCoroutine(ReloadingSystem());
        }
    }

    public IEnumerator ReloadingSystem()
    {
        //재장전
        gunState = GunState.Reloading;
        yield return new WaitForSeconds(reloadTime);
        //var = 뒤에 오는 값을 보고 형태를 변환함;
         ammoToFill = Mathf.Clamp(magazineSize - magazineAmmo,
            0, ammoReMain);
        magazineAmmo += ammoToFill;
        ammoReMain -= ammoToFill;

        gunState = GunState.Ready;


    }
    public IEnumerator ShotEffect(Vector3 hitPotion)
    {
        bulletLine.enabled = true;
        bulletLine.SetPosition(0, gunFirePosition.position);
        bulletLine.SetPosition(1, hitPotion);
        audioSource.PlayOneShot(gunFireSound);
        yield return new WaitForSeconds(0.03f);

        bulletLine.enabled = false;
    }
}
