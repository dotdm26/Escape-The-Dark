using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRayControl : MonoBehaviour
{
    void FixedUpdate()
    {
        RaycastHit hit;
        bool hasHit = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit);
        if (hasHit)
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
        else
        {
            GameObject.Find("FlashlightEnemy").SendMessage("NotHitByLight");
            GameObject.Find("DarknessEnemy").SendMessage("NotHitByLight");
        }
    }
}
