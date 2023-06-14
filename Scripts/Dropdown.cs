using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Dropdown : MonoBehaviour
{
    //public TextMeshProUGUI output;

    public void HandleInputData(int val)
    {
        if (val == 1)
        {
            SceneManager.LoadScene(2);
        }
        //if (val == 2)
        //{
            //SceneManager.LoadScene(2);
        //}
    }
}
