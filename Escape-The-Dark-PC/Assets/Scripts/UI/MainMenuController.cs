using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private CanvasGroup MainMenu;
    [SerializeField] private CanvasGroup Buttons;
    [SerializeField] private CanvasGroup FadeOut;

    public FlashlightController Flashlight;
    private float Wait;
    private bool StartGame;

    private void Start()
    {
        StartGame = false;
        MainMenu.alpha = 0;
        Buttons.alpha = 0;
        FadeOut.alpha = 0;
    }

    private void Update()
    {
        Wait += Time.deltaTime;
        if (MainMenu.alpha < 1 && Wait > 1f)
        {
            MainMenu.alpha += Time.deltaTime / 2;
            Buttons.alpha = 0;
        }
        if (Buttons.alpha < 1 && Wait > 1.5f) Buttons.alpha += Time.deltaTime / 2;


        if (FadeOut.alpha < 1 && Buttons.alpha == 1 && StartGame == true)
        {
            FadeOut.alpha += Time.deltaTime / 2;
        }
        if (FadeOut.alpha == 1)
        {
            SceneManager.LoadScene("Game");
        }

    }

    public void PlayGame()
    {
        StartGame = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
