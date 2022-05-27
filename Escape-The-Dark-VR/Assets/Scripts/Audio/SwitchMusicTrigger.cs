using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMusicTrigger : MonoBehaviour
{
    public AudioClip NormalMusic, EnemyNearbyMusic, RunningMusic, LoseMusic;
    AudioSource BGM;

    public GameFadeController GameFadeIO;

    public FlashlightController flashlight;
    public LayerMask whatIsEnemy;
    public GameObject Player;
    public float SphereRadius;
    float timer;

    void Start()
    {
        BGM = GetComponent<AudioSource>();
        ChangeBGM(NormalMusic);
        SphereRadius = 10f;
    }

    void Update()
    {
        if (Physics.CheckSphere(Player.transform.position, SphereRadius, whatIsEnemy))
        {
            if (GameFadeIO.WinState == false && GameFadeIO.EndGame == true) {
                 if (BGM.clip != LoseMusic)
                 {
                    Debug.Log("End the game with jumpscare");
                    ChangeBGM(LoseMusic);
                 }
            }
            else
            {
                if (BGM.clip == RunningMusic)
                    return;
                else if (BGM.clip != EnemyNearbyMusic)
                    ChangeBGM(EnemyNearbyMusic);
            }
        }
        else
        {
            timer += Time.deltaTime;
            if (timer > 9f && BGM.clip != NormalMusic)
                ChangeBGM(NormalMusic);
        }

    }


    // changes music when player collides with enemies
    void OnTriggerEnter(Collider other)
    {
        //If the flashlight shines on an enemy

        if (other.name == "FlashlightEnemy" && flashlight.isOn)
        {
            if (BGM.clip != RunningMusic)
                ChangeBGM(RunningMusic);
        }
    }

    public void ChangeBGM(AudioClip music)
    {
        BGM.Stop();
        BGM.clip = music;
        BGM.Play();
    }
}
