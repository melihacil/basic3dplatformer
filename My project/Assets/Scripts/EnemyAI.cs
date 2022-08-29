using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyAI : MonoBehaviour
{

    public NavMeshAgent agent;

    public Transform player;
    public Transform shootingPoint;

    public LayerMask whatIsGround, whatIsPlayer;

    public Rigidbody rb;

    [Header("Patrol")]
    public Vector3 walkPoint;
    public bool walkPointSet;
    public float walkPointRange;
    public GameObject projectile;


    [Header("Attack Options")]
    public bool isBomber = false;
    public bool alreadyAttacked = false;
    public float timeBetweenAttacks = 3f;
    [Header("States")]
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;
    // Start is called before the first frame update

    private ObjectPool objectPool;

    private void Awake()
    {
        //Assigning important stuff
        //player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        objectPool = GetComponent<ObjectPool>();
    }
    void Start()
    {
        rb.freezeRotation = true;
        if (isBomber)
            objectPool.Initialize(projectile, 2);
    }

    // Update is called once per frame
    void Update()
    {
        //Checks if the player is in radius of enemy
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        if (!playerInSightRange)
        {
            Patrolling();
        }
        else if (playerInSightRange && !playerInAttackRange)
        {
            ChasePlayer();
        }
        else if (playerInAttackRange)
        {
            //agent.Stop();
            AttackPlayer();
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && !isBomber)
        {
            //Gets the player damaged
            collision.gameObject.GetComponentInParent<PlayerStats>().damagePlayer(20);
            Debug.Log("Got Hit");
            //GetDamaged(collision.transform);
            collision.gameObject.GetComponent<PlayerMovement>().GetDamaged(this.transform);
        }
        else if (isBomber && collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
    private void Patrolling()
    {
        if (!walkPointSet)
            SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;


    }

    private void SearchWalkPoint()
    {
        //Calculate random point in range

        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);


        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);


        //Check if the next point is on ground
        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        if (agent.isStopped)
            agent.isStopped = false;
        agent.SetDestination(new Vector3(player.position.x,0,player.position.z));
    }


    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);


        if (isBomber)
            transform.LookAt(player);
        //transform.LookAt(player);

        if (!alreadyAttacked)
        {
            //Attacking code
            if (isBomber)
            {
                
                Debug.Log("Attacking");
                //Rigidbody rb = Instantiate(projectile, shootingPoint.position, Quaternion.identity).GetComponent<Rigidbody>();

                var bomb = objectPool.CreateObject();
                bomb.transform.position = shootingPoint.position;
                bomb.transform.rotation = shootingPoint.rotation;
                Rigidbody rb = bomb.GetComponent<Rigidbody>();
                rb.velocity = new Vector3(0, 0, 0);
                // Can be made scaling with distance !! Vector3.Distance(transform.position, player.position);
                rb.AddForce(shootingPoint.forward * 6f, ForceMode.Impulse);
                rb.AddForce(shootingPoint.up * 8f, ForceMode.Impulse);
            }

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }



    }


    private void ResetAttack()
    {
       alreadyAttacked = false;
    }
}
