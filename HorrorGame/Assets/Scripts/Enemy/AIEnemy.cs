using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIEnemy : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;

    //Patrolling
    public Vector3 walkPoint;
    [HideInInspector] public bool walkPointSet;
    public float walkPointRange;

    //States
    public float sightRange;
    public bool playerInSightRange;

	private void Awake()
	{
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
	}

	private void Update()
	{
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        if (!playerInSightRange) Patrolling();
        else ChasePlayer();
    }

	private void Patrolling()
	{
        if (!walkPointSet) SearchWalkPoint();
        else if (walkPointSet) agent.SetDestination(walkPoint);

        
        if (Vector3.Distance(transform.position, walkPoint) < 1f) walkPointSet = false; 
	}

    private void SearchWalkPoint()
	{
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        
        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround)) walkPointSet = true;
    }

    private void ChasePlayer()
	{
        agent.SetDestination(player.position);
	}
}
