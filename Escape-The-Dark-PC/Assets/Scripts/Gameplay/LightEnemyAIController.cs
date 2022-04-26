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
    public bool isChasing;

    private Collider EnemyCollider;
    //need a 2nd collider, otherwise raycast won't work when it's not chasing
    [SerializeField] private Collider SubCollider;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").transform;
        isChasing = true;
        EnemyCollider = gameObject.GetComponent<Collider>();
        EnemyCollider.isTrigger = true;
    }

    //light enemy doesn't move, but if you accidentally shine a light on it
    //it will move VERY fast until you turn off your flashlight
    private void Update()
    {
        if (isChasing == false) 
            EnemyCollider.enabled = false;
        else
        {
            EnemyCollider.enabled = true;
            ChasePlayer();
        }
    }

    void ChasePlayer()
    {
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
