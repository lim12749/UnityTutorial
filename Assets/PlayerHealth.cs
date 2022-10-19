using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : HealthSystem
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void OnDamage(float _damage)
    {
        base.OnDamage(_damage);
    }
    public override void Die()
    {
        base.Die();
    }
}
