using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConditionController : MonoBehaviour
{
    public GameFadeController GameFadeIO;/*
    public AudioSource source;
    public AudioClip JumpScare;*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {/*
            source.Stop();
            source.clip = JumpScare;
            source.Play();*/
            Debug.Log("You lose");
        }
        else if (other.gameObject.CompareTag("Exit"))
        {
            GameFadeIO.WinState = true;
            Debug.Log("You Win");
        }
        GameFadeIO.EndGame = true;
    }
}
