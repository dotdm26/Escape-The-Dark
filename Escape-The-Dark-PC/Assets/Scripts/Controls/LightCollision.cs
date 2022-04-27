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
    private MeshCollider meshcoll;

    void Start()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
        meshcoll = gameObject.GetComponent<MeshCollider>();
        meshcoll.enabled = true;
        //make cone-shaped object/collider invisible, but still active
    }


    //while the cone triggers the enemy
    private void OnTriggerStay(Collider other)
    {
        if (flashlight.isOn) 
        {
            if (other.gameObject.name == "FlashlightEnemy" || other.gameObject.name == "DarknessEnemy")
            {
                other.gameObject.SendMessage("HitByLight");
            }
        }
        else
        {
            if (other.gameObject.name == "FlashlightEnemy" || other.gameObject.name == "DarknessEnemy")
            {
                other.gameObject.SendMessage("NotHitByLight");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit trigger");
        other.gameObject.SendMessage("NotHitByLight");
    }
}
