using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//내가 입력받는 값을 전달

public class PenguinInput : MonoBehaviour
{
    public string HorizontalName = "Horizontal";
    public string JumpInputName = "Jump";

    public Vector3 HorizontalMoveDiraction { get; private set; }
    public bool Jumpinput;

    private void Update()
    {
        MoveSystem();
    }

    private void MoveSystem()
    {
        //좌우 움직임을 담당할예정
        HorizontalMoveDiraction = new Vector3(
            Input.GetAxis(HorizontalName), 0f, 0f);
        Debug.Log(HorizontalMoveDiraction);

        Jumpinput = Input.GetButtonDown(JumpInputName);

    }
}
