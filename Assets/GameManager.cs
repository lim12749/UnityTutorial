using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instace{ get; private set; }

    public bool isGameOver = false;
    public int _Score=0;
    private void Awake()
    {
        Instace = this;
    }

    public void AddScore(int _num)
    {
        _Score += _num;
        UIManager.Instance.UpdateScore(_Score);
    }
}
