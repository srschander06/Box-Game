using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bottomfloor : MonoBehaviour
{
    public int Respawn;
    public AudioSource audioFail;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Bottomfloor")
        {
            Destroy(gameObject);
            SceneManager.LoadScene(Respawn);
            audioFail.Play();
        }
    }
}
