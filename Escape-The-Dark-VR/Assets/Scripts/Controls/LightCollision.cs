using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * There is a cone child object of the flashlight's Spotlight.
 * It's meant to simulate the areas covered by the flashlight's range and radius,
 * using colliders.
 */

public class LightCollision : MonoBehaviour
{
    public FlashlightController flashlight;

    void Start()
    {
        //hide collision cone
        gameObject.GetComponent<Renderer>().enabled = false;
    }


    //while the cone triggers the enemy
    private void OnTriggerStay(Collider other)
    {
        if (flashlight.isOn) 
        {
            if (other.gameObject.name == "FlashlightEnemy" || other.gameObject.name == "FlashlightEnemy (1)" 
                || other.gameObject.name == "DarknessEnemy" || other.gameObject.name == "DarknessEnemy (1)" )
            {
                other.gameObject.SendMessage("HitByLight");
            }
        }
        else
        {
            if (other.gameObject.name == "FlashlightEnemy" || other.gameObject.name == "FlashlightEnemy (1)"
                || other.gameObject.name == "DarknessEnemy" || other.gameObject.name == "DarknessEnemy (1)")
            {
                other.gameObject.SendMessage("NotHitByLight");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        other.gameObject.SendMessage("NotHitByLight");
    }
}
