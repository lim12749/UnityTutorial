using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimLabSpawnSystem : MonoBehaviour
{
    public Transform[] points;
    public GameObject targetModel;
    public float maxCount;
    private bool isGameStart =false;
     
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.P))
        {
            StartCoroutine(CreateTarget());
        }
    }

    IEnumerator CreateTarget()
    {
        while (!isGameStart)
        {
            int targetCount = (int)GameObject.FindGameObjectsWithTag("Target").Length;
            //스폰된 카운트가 맥스카운트보다 크다면
            print(targetCount);
            if (targetCount < maxCount)
            {
                yield return new WaitForSeconds(3.0f);
                int idx = UnityEngine.Random.Range(1, points.Length);
                print(targetCount);
                Instantiate(targetModel, points[idx]);
            }
            else
            {
                yield return null;
            }
        }
    }
}
