using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    public Item[] items;

    public void SpawnItem(Transform _Tr)
    {
        int idx = Random.Range(0, items.Length);
        
        GameObject _item =  Instantiate(items[idx].gameObject, _Tr.position, _Tr.rotation);    
        
    }
}
