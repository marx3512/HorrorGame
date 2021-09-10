using UnityEngine;
using UnityEngine.AI;

public class AIEnemy : MonoBehaviour
{
    
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    public HandlePlayer playerScript;

    //Patrolling
    public Vector3 walkPoint;
    [HideInInspector] public bool walkPointSet;
    public float walkPointRange;

    //States
    public float sightRange;
    public bool playerInSightRange;

    //Sounds
    [Header("Sounds")]
    [SerializeField] private AudioSource sound;
    [SerializeField] private AudioClip soundClip;
    int condPlay = 0;

	private void Awake()
	{
        player = GameObject.Find("Player1").transform;
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

        
        if (Vector3.Distance(transform.position, walkPoint) < 5f) walkPointSet = false; 
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
        
        if (Vector3.Distance(transform.position, player.position) < 5f)
		{
            if(condPlay == 0){
                sound.Stop();
                sound.PlayOneShot(soundClip,1f);
                condPlay = 1;
            }
            playerScript.ImDead = true;
		}
    }

}
