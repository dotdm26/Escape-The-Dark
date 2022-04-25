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
    public bool playerDetected, isChasing;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        isChasing = false;
    }

    //light enemy doesn't move, but if you accidentally shine a light on it
    //it will move VERY fast until you stop pointing your flashlight at it
    private void Update()
    {
        playerDetected = Physics.CheckCapsule(transform.position, transform.forward, enemySightRange, whatIsPlayer);

        if (isChasing == false) 
            gameObject.GetComponent<Collider>().isTrigger = false;
        else ChasePlayer();
    }

    void ChasePlayer()
    {
        gameObject.GetComponent<Collider>().isTrigger = true;
        agent.SetDestination(player.position);
        transform.LookAt(player);
    }

    void HitByLight()
    {
        Debug.Log("Light enemy hit by light");
        agent.isStopped = false;
        isChasing = true;
    }

    void NotHitByLight()
    {
        agent.isStopped = true;
        isChasing = false;
    }
}
