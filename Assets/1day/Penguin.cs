using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Penguin : MonoBehaviour
{
    //내 자신이 움직임
    private PenguinInput _penguInInput;
    private Rigidbody _myRigidbody;
    private SpawnSystem _spawnSystem;
    [Range(0f,10f)] public float moveSpeed;
   
    private void Start()
    {
        _spawnSystem = GameObject.Find("Spawn").GetComponent<SpawnSystem>();
        _myRigidbody = GetComponent<Rigidbody>();
        _penguInInput = GetComponent<PenguinInput>();
    }
    private void OnDisable()
    {
        _spawnSystem.ispenguinDIe = true;
        StopCoroutine(_spawnSystem.CreateIceSystme());
    }

    private void Update()
    {
        Move(_penguInInput.HorizontalMoveDiraction);
        if(_penguInInput.Jumpinput)
        {
            Jump();
        }
    }
    private void Move(Vector3 _direction)
    {
        this.transform.Translate(_direction * moveSpeed * Time.deltaTime);
    }
    private void Jump()
    {
        _myRigidbody.AddForce(Vector3.up * 5f, ForceMode.Impulse);
    }
}
