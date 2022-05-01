using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LightEnemyAIController : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsPlayer;

    public bool isChasing;

    private Collider EnemyCollider;
    private float ogSpeed;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").transform;
        isChasing = false;
        ogSpeed = agent.speed;
        EnemyCollider = gameObject.GetComponent<Collider>();
        EnemyCollider.isTrigger = true;
    }

    //most dangerous enemy unit
    //light enemy doesn't move, but if you accidentally shine a light on it
    //it will move VERY fast until you turn off your flashlight, where it stalks you at slow speed
    private void Update()
    {
        if (isChasing == true)
        {
            ChasePlayer();
        }
    }

    void ChasePlayer()
    {
        agent.SetDestination(player.position);
        transform.LookAt(player);
    }

    //Is called by CameraRayController
    void HitByLight()
    {
        agent.speed = ogSpeed;
        isChasing = true;
    }

    void NotHitByLight()
    {
        agent.speed = ogSpeed / 3f;
    }
}
