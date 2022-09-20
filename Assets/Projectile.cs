using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float bulletSpeed { get; private set; }

    public void SetSpeed(float _BulletSpeed)
    {
        bulletSpeed = _BulletSpeed;
    }
    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * bulletSpeed);
    }
}
