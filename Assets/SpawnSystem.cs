using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    public GameObject IceObj;
    public float PopTime;

    public bool ispenguinDIe { get; set; }
    private void Start()
    {
        ispenguinDIe = false;
        StartCoroutine(CreateIceSystme());  
    
    }

    public void Spawn()
    {
        Instantiate(IceObj,this.transform.position,
            Quaternion.Euler(0f,180f,0f));
    }

     public IEnumerator CreateIceSystme()
    {
        do
        {
            Spawn();
            yield return new WaitForSeconds(PopTime);
        } while (!ispenguinDIe);
    }
}
