using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Movement
    public CharacterController cc;
    public float speed = 5f;
    public float jumpHeight = 3f;
    private float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    //head bobbing
    public Transform playerCam;
    private Vector3 camOrigin;
    private float movingCounter;

    private void Start()
    {
        camOrigin = playerCam.localPosition;
    }

    void Update()
    {
        //prevent player from landing instantly upon falling
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //movement
        Vector3 move = (transform.right * x + transform.forward * z);
        cc.Move(move * speed * Time.deltaTime);

        //Jump, optional
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        //gravity
        velocity.y += gravity * Time.deltaTime;
        cc.Move(velocity * Time.deltaTime);

        //head bobbing while moving
        if (x != 0 || z != 0) {
            HeadBobbing(movingCounter, 0.25f, 0.25f);
            movingCounter += Time.deltaTime * 4;
        }
        //slowly ease back to original cam position when idle
        else
        {
            playerCam.localPosition = Vector3.MoveTowards(playerCam.localPosition, camOrigin, Time.deltaTime); ;
        }
    }
    void HeadBobbing(float p_z, float p_x_intensity, float p_y_intensity)
    {
        playerCam.localPosition = camOrigin + new Vector3(Mathf.Cos(p_z) * p_x_intensity, Mathf.Sin(p_z * 2) * p_y_intensity, 0);
    }
}
