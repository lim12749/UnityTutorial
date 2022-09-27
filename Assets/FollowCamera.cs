using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;

    public Transform camTr;

    [Range(2.0f, 20.0f)]
    public float distance = 10.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        camTr.position = new Vector3(target.position.x, -target.position.y * distance, target.position.z);
        camTr.LookAt(target);
    }
}
