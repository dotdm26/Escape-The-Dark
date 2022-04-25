using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRayControl : MonoBehaviour
{
    //check flashlight on/off status. If on, light will interact
    public FlashlightController flashlight;

    void FixedUpdate()
    {
        RaycastHit hit;
        //checks whether raycast beam hit enemy
        bool hasHit = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit);
        if (hasHit && flashlight.on.activeSelf)
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                if (hit.collider.name == "FlashlightEnemy")
                {
                    hit.transform.SendMessage("HitByLight");
                }
                if (hit.collider.name == "DarknessEnemy")
                {
                    hit.transform.SendMessage("HitByLight");
                }
            }
        }
        else if (!flashlight.on.activeSelf)
        {
            GameObject.Find("FlashlightEnemy").SendMessage("NotHitByLight");
            GameObject.Find("DarknessEnemy").SendMessage("NotHitByLight");
        }
    }
}
