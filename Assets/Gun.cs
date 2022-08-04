using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public AudioSource audioSource; //소리를 관리하는 기능
    public AudioClip gunFireSound; //소리를 가진 칩

    public LineRenderer bulletLine; //화면에 선을 그리는 기능
    public Transform gunFirePosition; //위치를 관리하는 기능
    public float distance;

    public float timenow;
    public float lastFireTime;// 총을 마지막으로 발사한 시점
    public float fireDelayTime =0.12f; //총을 발사한 지연시간 (연사력)

    private void Start()
    {
        //소리를 관리하는 기능을 가져옴
        audioSource = GetComponent<AudioSource>();
        bulletLine = GetComponent<LineRenderer>();
    }
    private void Update()
    {
        timenow = Time.time;
        //마우스 클릭
        if (Input.GetButton("Fire1"))
        {

            if (Time.time >= lastFireTime + fireDelayTime)
            {
                RaycastHit hit;

                if (Physics.Raycast(gunFirePosition.position, gunFirePosition.forward * distance, out hit))
                {
                    Debug.Log(hit.collider.name);
                }
                Debug.DrawRay(gunFirePosition.position, gunFirePosition.forward * distance,
                    Color.red);

                StartCoroutine(ShotEffect(hit.point));
                lastFireTime = Time.time;
            }
        }
    }

 
    public IEnumerator ShotEffect(Vector3 hitPotion)
    {
        bulletLine.enabled = true;
        bulletLine.SetPosition(0, gunFirePosition.position);
        bulletLine.SetPosition(1, hitPotion);
        audioSource.PlayOneShot(gunFireSound);
        yield return new WaitForSeconds(0.03f);

        bulletLine.enabled = false;
    }
}
