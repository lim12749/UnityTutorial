using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : HealthSystem
{
    public Slider HealthValue; //ä�� UI

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void OnDamage(float _damage)
    {
        HealthValue.value -= _damage;
        
    }

}
