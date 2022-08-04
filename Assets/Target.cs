using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public UIContoller uiContoller;
    public int CurrnetHealth = 20;

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
