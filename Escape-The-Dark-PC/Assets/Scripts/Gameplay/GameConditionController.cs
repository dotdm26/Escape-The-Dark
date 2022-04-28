using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConditionController : MonoBehaviour
{
    public GameFadeController GameFadeIO;
    public EndFadeController EndFadeIO;
    
    //if there's time, add more conditions (e.g. collect more coins to be able to enter the stairs)

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
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
