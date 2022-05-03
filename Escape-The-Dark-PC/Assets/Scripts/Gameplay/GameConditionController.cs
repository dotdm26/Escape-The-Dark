using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 
using TMPro;

public class GameConditionController : MonoBehaviour
{
    public GameFadeController GameFadeIO;/*
    public AudioSource source;
    public AudioClip JumpScare;*/

    [SerializeField] private CanvasGroup MainMenu;
    [SerializeField] private CanvasGroup FadeOut;
    [SerializeField] private CanvasGroup GameStatus;
    public TextMeshProUGUI _title;

    //consider making the flashlight flicker randomly, for a scary feeling
    public FlashlightController Flashlight;
    private float Wait;
    private bool reset =false;
    private bool stageTwo = false;
    private bool gameState = true;

    private void Start()
    {
        GameStatus.alpha = 0;
        MainMenu.alpha = 0;
        FadeOut.alpha = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("You lose");
            GameStatus.alpha = 1;
            _title.text = "Game Over";
            gameState = false;
            reset = true;
        }
        else if (other.gameObject.CompareTag("Exit"))
        {
            //GameFadeIO.WinState = true;
            gameState = false;
            stageTwo = true;
            Debug.Log("You Win");
            GameStatus.alpha = 1;
            _title.text = "You have escaped the dark";
            GameFadeIO.WinState = true;
        }
        GameFadeIO.EndGame = true;
    }

    private void Update()
    {
        //slowly fades the Title then the buttons into the screen
        if (!gameState)
        {
            //slowly fades the Title then the buttons into the screen
            Wait += Time.deltaTime;
            if (MainMenu.alpha < 1 && Wait > 1f)
            {
                MainMenu.alpha += Time.deltaTime / 2;
            }
            if (FadeOut.alpha < 1 && Wait > 3f)
            {
                FadeOut.alpha += Time.deltaTime / 2;
            }
        }
    }

    public void ResetGame()
    {
        reset = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
