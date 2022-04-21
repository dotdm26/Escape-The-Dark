using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepsController : MonoBehaviour
{
    public AudioClip footsteps;
    AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
        source.clip = footsteps;
    }

    void Update()
    {
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical") && !source.isPlaying)
        {
            source.volume = Random.Range(0.75f, 1f);
            source.pitch = Random.Range(0.75f, 1f);
            source.Play();
        }
        else if (!Input.GetButton("Horizontal") && !Input.GetButton("Vertical") && source.isPlaying) 
        {
            source.Stop();
        }
    }
}
