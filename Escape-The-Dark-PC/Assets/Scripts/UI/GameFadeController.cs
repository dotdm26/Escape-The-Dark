using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFadeController : MonoBehaviour
{
    /*
     *Start the game by fading from MainMenu into the game, 
     *fades out when game ends
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

    //When starting the game, fades from black screen to the scene
    void StartGameCheck()
    {
        if (StartGame == true)
        {
            Black.alpha -= Time.deltaTime / 2;
            if (Black.alpha == 0) StartGame = false;
        }
    }

    //Fades to black/white depending on whether you lost/won
    void EndGameCheck()
    {
        if (EndGame == true)
        {
            if (WinState == false)
            {
                Black.alpha += Time.deltaTime / 3.25f;
                if (Black.alpha == 1) AfterGame("MainMenu");
            }
            else
            {
                White.alpha += Time.deltaTime / 2;
                if (White.alpha == 1) AfterGame("Win 1");
            }

        }
    }

    //Is called in GameConditionController
    void AfterGame(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

}
