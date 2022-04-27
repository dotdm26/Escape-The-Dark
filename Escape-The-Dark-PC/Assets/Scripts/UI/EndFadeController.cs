using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndFadeController : MonoBehaviour
{
    /*
     * For Win & Lose scenes, where you fade from white/black to the scene.
     */

    [SerializeField] private CanvasGroup White, Black;
    public bool StartGame, EndGame, WinState;
    
    //call gamestate from otehr script? transfer to WinState

    void Start()
    {
        StartGame = true;
        EndGame = false;
        WinState = false;
        White.alpha = 0;
        Black.alpha = 1;
    }

    void Update()
    {
        StartGameCheck();
        EndGameCheck();
    }

    void StartGameCheck()
    {
        if (StartGame == true)
        {
            Black.alpha -= Time.deltaTime / 2;
            if (Black.alpha == 0) StartGame = false;
        }
    }

    void EndGameCheck()
    {
        if (EndGame == true)
        {
            if (WinState == false)
            {
                Black.alpha += Time.deltaTime / 2;
                if (Black.alpha == 1) AfterGame("Lose");
            }
            else
            {
                White.alpha += Time.deltaTime / 2;
                if (White.alpha == 1) AfterGame("Win");
            }

        }
    }

    //Is called in GameConditionController
    void AfterGame(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

}
