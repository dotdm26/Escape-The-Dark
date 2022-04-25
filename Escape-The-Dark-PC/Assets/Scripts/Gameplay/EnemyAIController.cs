using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/*
 * Referenced from https://www.youtube.com/watch?v=UjkSFoLxesw
 */

public class EnemyAIController : MonoBehaviour
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
        playerDetected = Physics.CheckSphere(transform.position, enemySightRange, whatIsPlayer);
        if (!playerDetected) return;
        else ChasePlayer();
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
        transform.LookAt(player);
    }
}
