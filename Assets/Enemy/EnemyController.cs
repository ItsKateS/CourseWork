using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform target;

    NavMeshAgent agent;

    Animator animator;
    float attackDistance = 3.5f;
    public int health = 1;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        agent.SetDestination(target.position);
        agent.stoppingDistance = attackDistance;
    }

    void LateUpdate()
    {
        float distance = Vector3.Distance(transform.position, target.position);

        if (distance <= attackDistance)
            animator.SetBool("Attack", true);
    }

    public void Death()
    {
        animator.SetBool("Death", true);
        agent.SetDestination(transform.position);
        Destroy(gameObject, 1.3f);
        health--;
    }
}
