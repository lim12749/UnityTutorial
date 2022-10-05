 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum GunState
{
    //발사준비됨, 탄창빔, 재장전
    Ready, Empty, Reloading
}
//총 발사용
public class Gun : MonoBehaviour
{
    // 내 총 상태
    public GunState myGunState { get; private set; }

    public Transform muuzle;
    public Bullet projectile;//투사체
    public float msBetweenShots = 100f; //
    public float muzzleVelocity = 35f;

    public float nextShotTime; //발사 간격

    public int ammoRemaining;//남은 전체 총알
    public int magcapacity; //탄창 크기
    public int magAmmo;//탄창에 남은 총알

    private float reloadTime = 2.0f;

    private void OnEnable()
    {
        // 게임이 시작되거나 아이템을 줍거나할때 초기화해줌
        ammoRemaining = 30;
        magcapacity = 10;
        //현재탄창 = 탄창 크기
        magAmmo = magcapacity;
        myGunState = GunState.Ready; 
        UIManager.Instance.UpdateAmmoText(magAmmo,ammoRemaining);

    }
    public void Shoot()
    {
        Debug.Log("총알 생성");
        if (myGunState == GunState.Ready)
        {
            if (Time.time > nextShotTime)
            {
                nextShotTime = Time.time + msBetweenShots / 1000f;
                Bullet _projectile = Instantiate(projectile, muuzle.position, muuzle.rotation);
                _projectile.SetSpeed(muzzleVelocity);

                Destroy(_projectile.gameObject, 5f);

                magAmmo--; //총알 감소
                if (magAmmo <= 0) //0보다 작거나 같은경우 
                {
                    //비어있음으로 변경
                    myGunState = GunState.Empty;
                }
            }
        }
        UIManager.Instance.UpdateAmmoText(magAmmo, ammoRemaining);
    }

    public bool Reload()
    {
        Debug.Log("재장전 실행");
        if (ammoRemaining <=0 || magAmmo >= magcapacity)
        {
            Debug.Log("재장전 불가");
            return false; 
        }
        StartCoroutine(Reloaded());
        return true;
    }
    private IEnumerator Reloaded()
    {
        myGunState = GunState.Reloading;

        //사운드 재생

        //재장전 시간만큼 시간을 미룸
        yield return new WaitForSeconds(reloadTime);

        //시간이 다끝나면 값을 다 변경해줌
        
        //탄창크기만큼 채움
        magAmmo = magcapacity;
        //탄창크기만큼 남아있는 총알을 감소시킴 
        ammoRemaining -= magcapacity;
        //다시 쏠수 있는 상태로 변경
        myGunState = GunState.Ready;
        //장전후 UI변경
        UIManager.Instance.UpdateAmmoText(magAmmo, ammoRemaining);
    }
}
