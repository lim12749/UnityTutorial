using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AImLabPlayer : MonoBehaviour
{
    public Camera playerCamera;
    public Rigidbody myRigidbody;
    public float moveSpeed;
    float MouseY;
    public Vector3 moveInput;

    //게임이 시작되면 한번 실행함
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
        myRigidbody = GetComponent<Rigidbody>();
        playerCamera = GetComponentInChildren<Camera>();
    }
    private void Update()
    {
        Move();
        PlayerRotate();
        PlayerCamRotate();
    }
    void Move()
    {
        float InputX = Input.GetAxis("Horizontal");
        float InputZ = Input.GetAxis("Vertical");

        var _movHoritontal = transform.right * InputX;
        var _movVertical = transform.forward * InputZ;

        moveInput = (_movHoritontal + _movVertical);

        myRigidbody.MovePosition(myRigidbody.position 
            + moveInput * moveSpeed * Time.deltaTime);
    }
    void PlayerRotate()
    {
        float mouseX = Input.GetAxis("Mouse X");

        Vector3 rot = new Vector3(0, mouseX, 0);
        myRigidbody.MoveRotation(myRigidbody.rotation 
            * Quaternion.Euler(rot));
    }

    //위아래 회전
    void PlayerCamRotate()
    {
        MouseY -= Input.GetAxis("Mouse Y");

        MouseY = Mathf.Clamp(MouseY, -90, 90);
        playerCamera.transform.localEulerAngles  = new Vector3(MouseY, 0f, 0f);
    }
}
