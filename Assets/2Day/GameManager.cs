using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public ItemBox[] itemBoxes;
    public bool isGameOver = false;
    public GameObject EndUI;

    private void Update()
    {
        //재시작
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(0);
        }
        if(isGameOver ==true)
        {
            return;
        }
        int count = 0;
        for(int i=0; i<itemBoxes.Length; i++)
        {
            if(itemBoxes[i].isOverLap == true)
            {
                count++;
            }
        }
        if(count>= itemBoxes.Length)
        {
            isGameOver = true;
            EndUI.SetActive(true);

            Debug.Log("게임 끝");
        }
    }
}
