using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocobanPlayer : MonoBehaviour
{
    public Rigidbody myRigidbody;
    public float moveSpeed;
    public GameManager _gameManager;


    private void Update()
    {
        if(_gameManager.isGameOver ==true)
        {
            return;
        }
        PlayerMove();
    }

    public void PlayerMove()
    {
        //аб©Л -1.0  ~ 0 ~ +1.0
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");
        float fallSpeed = myRigidbody.velocity.y;

        Vector3 _velocity = new Vector3(inputX, 0, inputZ);
        _velocity = _velocity * moveSpeed;
        _velocity.y = fallSpeed;
        myRigidbody.velocity = _velocity;
    }
}
