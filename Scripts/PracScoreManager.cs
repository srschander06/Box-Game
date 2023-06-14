using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PracScoreManager : MonoBehaviour
{
    public PracScoreManager instance;
    public TextMeshProUGUI text;
    int score;

    void Start()
    {
        if (instance == null)
        {
            instance = this;     
        }
    }

    public void ChangeScore(int coinValue)
    {
        score += coinValue;
        text.text = score.ToString();
    }


    int coinValue = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ScoreManager.instance.ChangeScore(coinValue);
        }
    }

}


