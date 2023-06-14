using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI text;
    int score;

    void Start()
    {
        if (instance == null)
        {
            //need to create an instance of this
            instance = this;
        }   
    }

    public void ChangeScore(int coinValue)
    {
        score += coinValue;
        //default value of score is zero because nothing is assigned to it yet, as you earn more coins it's value will go up and add on to coinValue
        text.text = score.ToString();

    }
}
