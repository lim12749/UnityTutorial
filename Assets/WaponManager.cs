using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponState { None, MainWeapon, Sward=3}

public class WaponManager : MonoBehaviour
{
    public static WaponManager Instace;

    public GameObject[] Weaponlist;
    public WeaponState weaponState { get; set; }

    public Transform[] weaponHold;//총이 생성되고 장착되는 위치
    public Gun startingGun; //처음 시작에 사용하는 무기(권총)
    [SerializeField] private GameObject equippedWeapon;

    private void Awake()
    {
        Instace = this;
    }

    private void Start()
    {
        if (startingGun != null) //
            EquipGun(startingGun.gameObject); 
    }
    public void EquipGun(GameObject _gunToEquip)
    {
        //혹시 총을 쥐고 있다면 삭제함
        if(equippedWeapon != null)
        {
            Destroy(equippedWeapon.gameObject);
        }
        //총 생성해서 
        equippedWeapon = Instantiate(_gunToEquip, weaponHold[0].position, weaponHold[0].rotation);
        equippedWeapon.transform.parent = weaponHold[0];
        weaponState = WeaponState.MainWeapon;
    }
    public void Fire()
    {
        //null 이 아니라면
        if (equippedWeapon != null)
        {
            equippedWeapon.GetComponent<Gun>().Shoot();
        }
    }
    public void SwardAttack()
    {
        Debug.Log("근접 공격");
    }
    public void ChangeWeapon(WeaponState _ws)
    {
        if (equippedWeapon != null)
        {
            Destroy(equippedWeapon.gameObject);
        }
        switch (_ws)
        {
            case WeaponState.None:
                break;
            case WeaponState.MainWeapon:
                weaponState = WeaponState.MainWeapon;
                equippedWeapon = Instantiate(Weaponlist[0], weaponHold[0].position, weaponHold[0].rotation);
                equippedWeapon.transform.parent = weaponHold[0];
                break;
            case WeaponState.Sward:
                weaponState = WeaponState.Sward;
                equippedWeapon = Instantiate(Weaponlist[1], weaponHold[1].position, weaponHold[1].rotation);
                equippedWeapon.transform.parent = weaponHold[1];
                break;
            default:
                break;
        }
    }
}
