using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Movement
    public CharacterController cc;
    public float speed = 2f;
    public float jumpHeight = 3f;
    private float gravity = -9.81f;
    private float ogSpeed;
    public bool isRunning;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;

    //head bobbing
    public Transform playerCam;
    private Vector3 camOrigin;
    private float movingCounter;

    private void Start()
    {
        ogSpeed = speed;
        camOrigin = playerCam.localPosition;
        isRunning = false;
    }

    void Update()
    {

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //movement
        Vector3 move = (transform.right * x + transform.forward * z);
        cc.Move(move * speed * Time.deltaTime);
        Running(z);

        //gravity
        velocity.y += gravity * Time.deltaTime;
        cc.Move(velocity * Time.deltaTime);

        //head bobbing while moving
        if (x != 0 || z != 0) {
            HeadBobbing(movingCounter, 0.25f, 0.25f);
            movingCounter += Time.deltaTime * 4.5f;
        }
        //slowly ease back to original cam position when idle
        else
        {
            playerCam.localPosition = Vector3.MoveTowards(playerCam.localPosition, camOrigin, Time.deltaTime); ;
        }

    }
    void HeadBobbing(float p_z, float p_x_intensity, float p_y_intensity)
    {
        if (isRunning == true)
        {
            Debug.Log("bobbing run");
            p_x_intensity = 1f;
            p_y_intensity = 1f;
        }
        else
        {
            Debug.Log("bobbing walk");
            p_x_intensity = 0.25f;
            p_y_intensity = 0.25f;
        }
        playerCam.localPosition = Vector3.MoveTowards(
            playerCam.localPosition, 
            camOrigin + new Vector3(Mathf.Cos(p_z) * p_x_intensity, Mathf.Sin(p_z * 2) * p_y_intensity, 0), 
            Time.deltaTime);
    }

    void Running(float z)
    {
        if (Input.GetKey(KeyCode.LeftShift) && z > 0 && isRunning == false)
        {
            isRunning = true;
            speed = speed * 4 + 1f;
        }
        else if (!Input.GetKey(KeyCode.LeftShift) || z > 0)
        {
            isRunning = false;
            speed = ogSpeed;
        }
    }
}
