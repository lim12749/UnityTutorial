using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    public TextMeshProUGUI AmmoText; //총알 표시용 텍스트
    public GameObject GameOverUI; //내가 죽게되면 활성화시킬 UI
    public GameObject BludeScreen; //내가 피해를 입을경우 활성화시킴.
    private void Awake()
    {
        Instance = this;
    }
    public void UpdateAmmoText(int _magAmmo,int _remainAmmo)
    {
        AmmoText.text = _magAmmo + "/" + _remainAmmo;
    }
    
}
