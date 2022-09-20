using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//총 발사용
public class Gun : MonoBehaviour
{
    public Transform muuzle;
    public Projectile projectile;//투사체
    public float msBetweenShots = 100f;
    public float muzzleVelocity = 35f;

    public float nextShotTime; //발사 간격
    
    public void Shoot()
    {
        if(Time.time > nextShotTime)
        {
            nextShotTime = Time.time + msBetweenShots / 1000f;
            Projectile _projectile = Instantiate(projectile, muuzle.position, muuzle.rotation);
            _projectile.SetSpeed(muzzleVelocity);
        }
    }
}
