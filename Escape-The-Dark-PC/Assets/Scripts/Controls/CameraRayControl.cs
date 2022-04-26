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
        /*
         *Note! Keep the cast on the player cam in PC version.
         *However, try to put it on the flashlight in VR version.
         *Try to use multiple raycasts to expand the light range,
         *or switch to Spherecast.
         */
        bool hasHit = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit);
        if (hasHit && flashlight.on.activeSelf)
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                //sends message to their AI scripts
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
