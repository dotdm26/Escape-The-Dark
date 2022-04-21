using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBobController : MonoBehaviour
{
    [SerializeField] private bool isEnabled = true;
    [SerializeField, Range(0, 0.1f)] private float amplitude = 0.015f;
    [SerializeField, Range(0, 30)] private float frequency = 10.0f;

    [SerializeField] private Transform camObject = null;
    [SerializeField] private Transform camHolder = null;

    private float toggleSpeed = 3.0f;
    private Vector3 startPos;
    private CharacterController cc;

    private void Awake()
    {
        cc = GetComponent<CharacterController>();
        startPos = camObject.localPosition;
    }

    void Update()
    {
        if (!isEnabled) return;

        CheckMotion();
        ResetPosition();
        camObject.LookAt(FocusTarget());
    }

    private void PlayMotion(Vector3 motion)
    {
       camObject.localPosition += motion * Time.deltaTime;
    }

    private void CheckMotion()
    {
        float speed = new Vector3(cc.velocity.x, 0, cc.velocity.z).magnitude;
        if (speed < toggleSpeed) return;
        if (!cc.isGrounded) return;

        PlayMotion(FootStepMotion());
    }

    private Vector3 FootStepMotion()
    {
        Vector3 pos = Vector3.zero;
        pos.y += Mathf.Sin(Time.time * frequency) * amplitude;
        pos.x += Mathf.Cos(Time.time * frequency / 2) * amplitude * 2;
        return pos;
    }

    private void ResetPosition()
    {
        if (camObject.localPosition == startPos) return;
        camObject.localPosition = Vector3.Lerp(camObject.localPosition, startPos, 1 * Time.deltaTime);
    }
    private Vector3 FocusTarget()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + camHolder.localPosition.y, transform.position.z);
        pos += camHolder.forward * 15.0f;
        return pos;
    }

}
