using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    public float bulletPower { get; private set; } //ÃÑ¾Ë¼Óµµ

    [SerializeField] private float bulletDamage = 20f; //ÃÑ¾Ë µ¥¹ÌÁö

    public void SetSpeed(float _BulletSpeed)
    {
        bulletPower = _BulletSpeed;
    }
    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * bulletPower);
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
