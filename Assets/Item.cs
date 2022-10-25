using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int AmmoSize = 30;

    public void UseItem(GameObject _object)
    {
        //부디친 오브젝트의 정보를 가져옴
        Gun _gun = _object.GetComponent<WaponManager>().equippedWeapon.GetComponent<Gun>();

        if(_gun !=null)
        {
            _gun.ammoRemaining += AmmoSize;
        }
        UIManager.Instance.UpdateAmmoText(_gun.magAmmo, _gun.ammoRemaining);
        Destroy(gameObject);
    }
   

}
