using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LightEnemyAIController : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsPlayer;

    public float enemySightRange;
    public bool playerDetected;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //Note: make sure the GameObject is rotated by 90 deg on the Z axis.
        //We want to use the length of the capsule by rotating it to place it on its horizontal side.
        //works better for mazes with small corridors
        playerDetected = Physics.CheckCapsule(transform.position, transform.forward, enemySightRange, whatIsPlayer);

        if (!playerDetected) return;
        else ChasePlayer();
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
        transform.LookAt(player);
    }
}
