using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    
    public float moveSpeed;
    public float rayDistance; //���� �Ÿ�
    Player controller;
    Camera mainCamera;

    Animator PlayerAnim;

    public int weaponValue=0;
    private void Start()
    {
        controller = GetComponent<Player>();
        PlayerAnim = GetComponent<Animator>();
        
        mainCamera = Camera.main;
    }
    private void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");    

        Vector3 moveInput = new Vector3(hAxis, 0f, vAxis);
        //������ Normalized�� �̿��Ͽ� 1���� ���͸� ����� * ���ǵ带��.
        Vector3 moveVelocity = moveInput.normalized * moveSpeed;

        controller.Move(moveVelocity);

        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit rayhit;

        if (Physics.Raycast(ray, out rayhit))
        {
            Debug.DrawLine(ray.origin, rayhit.point, Color.red);
            controller.LookAt(rayhit.point);
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("�ֹ���");
            weaponValue = 1;
            WaponManager.Instace.ChangeWeapon(WeaponState.MainWeapon);
        }
        else if( Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("3 ��������");
            weaponValue = 3;
            WaponManager.Instace.ChangeWeapon(WeaponState.Sward);
        }

        PlayerAnim.SetInteger("WeaponChange", weaponValue);

        PlayerAnim.SetFloat("Horizontal", hAxis);
        PlayerAnim.SetFloat("Vertical", vAxis);

    }
    
}
