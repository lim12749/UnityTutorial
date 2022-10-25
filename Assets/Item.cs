using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemState { Ammo,Health }
public class Item : MonoBehaviour
{
    public ItemState _itemState;

    public int HealthSize = 50;
    public int AmmoSize = 30;

    public void UseItem(GameObject _object)//매개변수 
    {

        switch (_itemState)
        {
            case ItemState.Ammo:
                // 오브젝트의 정보를 가져옴
                Gun _gun = _object.GetComponent<WaponManager>().equippedWeapon.GetComponent<Gun>();

                if (_gun != null)
                {
                    _gun.ammoRemaining += AmmoSize;
                }
                UIManager.Instance.UpdateAmmoText(_gun.magAmmo, _gun.ammoRemaining);
                Destroy(gameObject);
                break;

            case ItemState.Health:
                PlayerHealth _playerHP = _object.GetComponent<PlayerHealth>();
                if(_playerHP !=null)
                {
                    if (_playerHP.HealthValue.value < _playerHP.HealthValue.maxValue)
                    {
                        _playerHP.HealthValue.value += HealthSize;
                    }
                    else if (_playerHP.HealthValue.value > _playerHP.HealthValue.maxValue)
                    {
                        _playerHP.HealthValue.value = 100;
                    }
                    Destroy(gameObject);
                }
                break;
        }



    }
   

}
