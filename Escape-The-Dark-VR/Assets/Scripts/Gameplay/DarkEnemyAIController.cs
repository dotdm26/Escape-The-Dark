using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DarkEnemyAIController : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsPlayer;

    public bool isChasing;

    private Collider EnemyCollider;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").transform;
        isChasing = true;
        EnemyCollider = gameObject.GetComponent<Collider>();
        EnemyCollider.isTrigger = true;
    }

    //dark enemy moves all the time.
    //stops moving temporarily if you shine a light on it
    private void Update()
    {
        if (isChasing == true)
        {
            ChasePlayer();
        }
        else
        {
            agent.isStopped = true;
        }
    }

    void ChasePlayer()
    {
        agent.SetDestination(player.position);
        transform.LookAt(player);
    }
    
    //below called by CameraRayControl
    void HitByLight()
    {
        agent.isStopped = true;
        isChasing = false;
    }

    void NotHitByLight()
    {
        agent.isStopped = false;
        isChasing = true;
    }
}
