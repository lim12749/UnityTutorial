 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//총 발사용
public class Gun : MonoBehaviour
{
    public Transform muuzle;
    public Bullet projectile;//투사체
    public float msBetweenShots = 100f;
    public float muzzleVelocity = 35f;

    public float nextShotTime; //발사 간격
    
    public void Shoot()
    {
        Debug.Log("총알 생성");
        if(Time.time > nextShotTime)
        {
            nextShotTime = Time.time + msBetweenShots / 1000f;
            Bullet _projectile = Instantiate(projectile, muuzle.position, muuzle.rotation);
            _projectile.SetSpeed(muzzleVelocity);
            
            Destroy(_projectile.gameObject, 5f);
        }
    }
}
