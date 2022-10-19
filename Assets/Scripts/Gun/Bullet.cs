using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    public float bulletPower { get; private set; } //�Ѿ˼ӵ�

    [SerializeField] private float bulletDamage = 20f; //�Ѿ� ������

    public void SetBullet(float _BulletSpeed)
    {
        bulletPower = _BulletSpeed;
    }
    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * bulletPower);
    }

    private void OnCollisionEnter(Collision collision)
    {
        HealthSystem target = collision.collider.GetComponent<HealthSystem>();
     
        if(target != null)
        {
            target.OnDamage(bulletDamage);
            Destroy(this.gameObject);
            Debug.Log(target.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }


    }
}
