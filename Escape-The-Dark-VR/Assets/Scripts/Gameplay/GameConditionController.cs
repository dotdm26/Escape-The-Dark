using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameConditionController : MonoBehaviour
{
    public GameFadeController GameFadeIO;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            StartCoroutine(PrepForRestart("Game"));
        }
        else if (other.gameObject.CompareTag("Exit"))
        {
            GameFadeIO.WinState = true;
            StartCoroutine(PrepForRestart("Win"));
        }
        else if (other.gameObject.CompareTag("Finish"))
        {
            GameFadeIO.WinState = true;
            StartCoroutine(PrepForRestart("Game"));
        }
        GameFadeIO.EndGame = true;
    }

    IEnumerator PrepForRestart(string name)
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(name);
    }
}
