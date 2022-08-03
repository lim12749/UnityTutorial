using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public LineRenderer bulletLine;
    public Transform gunFirePosition;
    public float distance;

    private void Start()
    {
        bulletLine = GetComponent<LineRenderer>();
    }
    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Debug.Log("¿ÞÂÊ Å¬¸¯");
            RaycastHit hit;

            if(Physics.Raycast(gunFirePosition.position,
                gunFirePosition.forward*distance, out hit))
            {
                Debug.Log(hit.collider.name);
               
            }
            Debug.DrawRay(gunFirePosition.position, 
                gunFirePosition.forward * distance, 
                Color.red);

            StartCoroutine(ShotEffect(hit.point));
        }
    }

 
    public IEnumerator ShotEffect(Vector3 hitPotion)
    {
        bulletLine.enabled = true;
        bulletLine.SetPosition(0, gunFirePosition.position);
        bulletLine.SetPosition(1, hitPotion);
        yield return new WaitForSeconds(0.03f);

        bulletLine.enabled = false;
    }
}
