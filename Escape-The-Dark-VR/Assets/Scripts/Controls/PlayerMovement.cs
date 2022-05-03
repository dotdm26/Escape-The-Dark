using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

/**
 * Simple player movement system.
 * Included are walking, running, some head bobbing.
 */

public class PlayerMovement : MonoBehaviour
{
    /*[SerializeField]
    private ActionBasedController leftController;*/
    private float isHeld;
    private float ogSpeed;
    //public float speed;
    public bool isRunning;
/*
    private void Start()
    {
        //speed = 2f;
        isRunning = false;
        leftController = GetComponent<ActionBasedController>();
        isHeld = leftController.activateAction.action.ReadValue<float>();
    }

    void Update()
    {
        if (isHeld >= 0.5f && isRunning == false)
        {
            isRunning = true;
            speed = speed * 3 + 1f;
        }
        else if (isHeld == 0f && isRunning == true)
        {
            isRunning = false;
            speed = ogSpeed;
        }

    }*/

}
