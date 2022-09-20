using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    public Transform weaponHold;
    public Gun startingGun;
    Gun equippedGun;

    private void Start()
    {
        if (startingGun != null)
            EquipGun(startingGun);
    }
    public void EquipGun(Gun gunToEquip)
    {

    }
}
