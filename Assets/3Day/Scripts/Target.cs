using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public UIContoller uiContoller;
    public int CurrnetHealth = 20;

    private void Start()
    {
        //게임오브젝트.Find는 게임화면에 존재하는 오브젝트의 이름으로 찾는 기능이다.
        //찾은 오브젝트 내부에 기능을 가져옵니다. 만약에 원하는 기능이 없으면 에러가 납니다.
        uiContoller = GameObject.Find("Canvas").GetComponent<UIContoller>();
    }
    //총이쏜 데미지를 값으로 받음
    public void Damage(int damageAmount)
    {
        CurrnetHealth -= damageAmount;
        if(CurrnetHealth<=0)
        {
            uiContoller.UpdateScore(10);
            Destroy(this.gameObject);
        }
    }
}
