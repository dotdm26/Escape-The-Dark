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

    private Collider EnemyCollider;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").transform;
        EnemyCollider = gameObject.GetComponent<Collider>();
        EnemyCollider.isTrigger = true;
    }

    //Normal enemy, moves when player is close. Unstoppable but slow
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
