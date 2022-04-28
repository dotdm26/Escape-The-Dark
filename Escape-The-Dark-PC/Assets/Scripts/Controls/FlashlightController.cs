using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    public GameObject off;
    //used Light because we don't want to do on.SetActive(false).
    //Otherwise the colliders will not work when you turn off the flashlight
    public Light LightArea;
    public bool isOn;

    void Start()
    {
        off.SetActive(false);
        isOn = true;
    }

    void Update()
    {
        //right click to turn on flashlight
        if (Input.GetKeyDown(KeyCode.Mouse1))
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
    }
}
