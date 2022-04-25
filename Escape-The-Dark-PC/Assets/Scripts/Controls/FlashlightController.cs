using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    public GameObject on, off;
    private bool isOn;

    void Start()
    {
        on.SetActive(true);
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
                on.SetActive(false);
                off.SetActive(true);
            }
            else
            {
                on.SetActive(true);
                off.SetActive(false);
            }
            isOn = !isOn;
        }
    }
}
