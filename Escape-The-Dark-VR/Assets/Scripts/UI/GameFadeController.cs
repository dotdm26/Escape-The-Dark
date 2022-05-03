using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFadeController : MonoBehaviour
{
    [SerializeField] private CanvasGroup Title, Win, Lose;
    public bool StartGame, EndGame, WinState;
    float timer;
    
    //call gamestate from otehr script? transfer to WinState

    void Start()
    {
        StartGame = true;
        EndGame = false;
        WinState = false;
        Win.alpha = 0;
        Lose.alpha = 0;
        Title.alpha = 0;
    }

    void Update()
    {
        ShowTitle();
        EndGameCheck();
    }

    void ShowTitle()
    {
        timer += Time.deltaTime;
        if (Title.alpha < 1 && timer > 1f && timer < 5f)
            Title.alpha += Time.deltaTime / 2;

        if (timer > 5f && Title.alpha != 0)
            Title.alpha -= Time.deltaTime / 2;
    }

    //Fades to black/white depending on whether you lost/won
    void EndGameCheck()
    {
        if (EndGame == true)
        {
            if (WinState == false)
            {
                Lose.alpha += Time.deltaTime / 3.25f;
            }
            else
            {
                Win.alpha += Time.deltaTime / 2;
            }

        }
    }

}
