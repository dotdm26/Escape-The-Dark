using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMusicTrigger : MonoBehaviour
{
    public AudioClip newTrack;

    private AudioControlManagerInGame theAM;

    void Start()
    {
        theAM = FindObjectOfType<AudioControlManagerInGame>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // changes music when player collides with enemies
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(newTrack != null)
                theAM.ChangeBGM(newTrack);
        }    
    }
}
