using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpider : MonoBehaviour
{
    public Transform player;
    public LayerMask whatIsPlayer;

    public float enemySightRange;
    public bool playerDetected;

    private bool TurnAndLook  = false;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
    }

    //Normal enemy, moves when player is close. Unstoppable but slow
    private void Update()
    {
        playerDetected = Physics.CheckSphere(transform.position, enemySightRange, whatIsPlayer);
        if (!playerDetected) return;
        else LookAtPlayer();
    }

    private void LookAtPlayer()
    {
        
        transform.LookAt(player);
    }

}
