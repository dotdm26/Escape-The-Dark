using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DarkEnemyAIController : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsPlayer;

    public float enemySightRange;
    public bool isChasing;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        isChasing = true;
    }

    //dark enemy is considerably slower, but moves all the time.
    //stops moving temporarily if you shine a light on it
    private void Update()
    {
        if (isChasing == false)
        {
            gameObject.GetComponent<Collider>().isTrigger = false;
        }
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
        Debug.Log("Dark enemy hit by light");
        agent.isStopped = true;
        isChasing = false;
    }

    void NotHitByLight()
    {
        agent.isStopped = false;
        isChasing = true;
    }
}
