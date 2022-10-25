using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instace{ get; private set; }

    public bool isGameOver = false;

    private void Awake()
    {
        Instace = this;
    }

    public void AddScore(int _num)
    {

    }
}
