using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRayControl : MonoBehaviour
{

    void FixedUpdate()
    {
        //For the flashlight to trigger certain enemies
        //ask the teacher if it's possible to use SphereCast (which doesn't work on triggers)
        RaycastHit hit;
        bool hasHit = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit);
        if (hasHit)
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                Debug.Log("Look at enemy");
            }
        }
    }
}
