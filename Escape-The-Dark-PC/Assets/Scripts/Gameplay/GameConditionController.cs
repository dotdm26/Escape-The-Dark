using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConditionController : MonoBehaviour
{
    //put this on enemy units.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("You lose");
        }
    }
}
