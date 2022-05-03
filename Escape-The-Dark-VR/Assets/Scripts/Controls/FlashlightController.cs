using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class FlashlightController : MonoBehaviour
{
    public GameObject off;
    //used Light because we don't want to do on.SetActive(false).
    //Otherwise the colliders will not work when you turn off the flashlight
    public Light LightArea;
    public bool isOn;
/*
    [SerializeField]
    private ActionBasedController rightController;
    private float isPressed;
    private bool isPressed2;*/

    void Start()
    {
        LightArea.enabled = true;
        off.SetActive(false);
        isOn = true;/*

        rightController = GetComponent<ActionBasedController>();
        isPressed = rightController.activateAction.action.ReadValue<float>();
        isPressed2 = rightController.activateAction.action.ReadValue<bool>();*/

    }

    /*void Update()
    {
        //right click to turn on flashlight
        if (isPressed >= 0.5f || isPressed2)
        {
            if (isOn)
            {
                LightArea.enabled = false;
                off.SetActive(true);
            }
            else
            {
                LightArea.enabled = true;
                off.SetActive(false);
            }
            isOn = !isOn;
        }
    }*/

}
