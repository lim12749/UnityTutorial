using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector3 velocity;
    [SerializeField] Rigidbody myRigidbody;
    [SerializeField] WaponManager waponManager;

    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        waponManager = GetComponent<WaponManager>();
    }
    private void FixedUpdate()
    {
        myRigidbody.MovePosition(myRigidbody.position + velocity * Time.deltaTime);
        
        //ฐ๘ฐÝ
        if(Input.GetMouseButton(0))
        {
            if(waponManager.weaponState == WeaponState.MainWeapon)
            {
                Debug.Log("รั น฿ป็");
                waponManager.Fire();
            }
            else if(waponManager.weaponState == WeaponState.Sward)
            {
                waponManager.SwardAttack();
            }

        }
    }
    public void Move(Vector3 _move)
    {
        velocity = _move;
    }
    public void LookAt(Vector3 lookPoint)
    {
        Vector3 CorrectedPoint = new Vector3(lookPoint.x, transform.position.y, lookPoint.z);
        transform.LookAt(CorrectedPoint);
    }
    

}
