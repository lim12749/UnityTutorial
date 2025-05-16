using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody myRigidboy;

    private Vector3 mvoeInput;
    private Vector3 MoveVelocity;

    private Camera mainCamera;

  
    // Start is called before the first frame update
    void Start()
    {
        myRigidboy = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
    }

    private void FixedUpdate()
    {
        myRigidboy.linearVelocity = MoveVelocity;
    }
    // Update is called once per frame
    void Update()
    {
        //������
        mvoeInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        MoveVelocity = mvoeInput * moveSpeed;

        //ȸ��
        Ray CameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if(groundPlane.Raycast(CameraRay, out rayLength))
        {
            Vector3 pointToLook = CameraRay.GetPoint(rayLength);
            Debug.DrawLine(CameraRay.origin, pointToLook, Color.blue);

            transform.LookAt(new Vector3(pointToLook.x,transform.position.y,pointToLook.z));
        }
    }
}
