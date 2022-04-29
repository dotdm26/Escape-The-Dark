using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControlManagerInGame : MonoBehaviour


{

    public AudioSource BGM;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeBGM(AudioClip music)
    {
        BGM.Stop();
        BGM.clip = music;
        BGM.Play();
    }
}
