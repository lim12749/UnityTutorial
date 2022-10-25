using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    public TextMeshProUGUI Wave; //
    public TextMeshProUGUI AmmoText; //�Ѿ� ǥ�ÿ� �ؽ�Ʈ
    public GameObject GameOverUI; //���� �װԵǸ� Ȱ��ȭ��ų UI
    public GameObject BludeScreen; //���� ���ظ� ������� Ȱ��ȭ��Ŵ.

    private void Awake()
    {
        Instance = this;
    }
    public void UpdateAmmoText(int _magAmmo,int _remainAmmo)
    {
        AmmoText.text = _magAmmo + "/" + _remainAmmo;
    }
    
}
