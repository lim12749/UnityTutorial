using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    public NavMeshAgent pathFinder; //경로계산 AI 에이전트
    public Transform playerTr;
    public Transform MonsterTr;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("ATTACK"))
        {
            Debug.Log("피격");
            Destroy(collision.gameObject);
        }
    }
}
