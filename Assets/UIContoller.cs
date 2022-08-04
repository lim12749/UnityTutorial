using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIContoller : MonoBehaviour
{
    public TextMeshProUGUI scoreNum;
    public int totalScore;
    public void UpdateScore(int score)
    {
        //점수를 UI로 보여주고 Tostring은 숫자를 문자로 바꿔줌
        // +=    a = a+b;     totalscore = totalscore + score
        totalScore += score;
        scoreNum.text = totalScore.ToString();
    }
}
