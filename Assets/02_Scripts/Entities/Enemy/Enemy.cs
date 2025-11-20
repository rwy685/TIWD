using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IDamagable
{
    [SerializeField] private EnemyData enemyData;
    [SerializeField] private float minWanderDistance;
    [SerializeField] private float maxWanderDistance;
    [SerializeField] private float wanderDelay = 2f;

    private Player player;
    private NavMeshAgent agent;
    private EnemyState enemyState;

    private float health;

    private float playerDistance;
    private float lastAttackTime;

    private WaitForSeconds wait;
    private Animator animator;

    public float fieldOfView = 120f;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameManager.Instance.characterManager.player;
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        wait = new WaitForSeconds(wanderDelay);
        enemyState = EnemyState.Idle;
        health = enemyData.maxHealth;

        SetState(EnemyState.Wander);
        animator.SetBool("IsSpawn", true);
    }

    private void Update()
    {
        if (player == null) return;

        playerDistance = Vector3.Distance(transform.position, player.transform.position);
        UpdateState();
    }

    private void UpdateState()
    {
        animator.speed = agent.speed / enemyData.walkSpeed;
        if (playerDistance < enemyData.attackDistance && IsPlayerInFieldOfView())
        {
            Debug.Log("1");
            SetState(EnemyState.Attack);

            Attack();
            return;
        }

        if (playerDistance < enemyData.chaseDistance)
        {
            Debug.Log("2");
            SetState(EnemyState.Chase);

            Chase();
            return;
        }

        if (enemyState == EnemyState.Wander)
        {
            if (agent.remainingDistance < 0.1f)
            {
                Debug.Log("3");
                SetState(EnemyState.Idle);
                StartCoroutine(Wander());
            }
            return;
        }
    }

    private void SetState(EnemyState newState)
    {
        enemyState = newState;

        switch (enemyState)
        {
            case EnemyState.Idle:
                agent.isStopped = true;
                animator.SetBool("IsWalk", false);
                break;

            case EnemyState.Wander:
                agent.speed = enemyData.walkSpeed;
                agent.isStopped = false;
                animator.SetBool("IsWalk", true);
                break;

            case EnemyState.Chase:
                agent.speed = enemyData.runSpeed;
                agent.isStopped = false;
                animator.SetBool("IsWalk", true);
                break;

            case EnemyState.Attack:
                agent.isStopped = true;
                animator.SetTrigger("Attack");
                break;
        }
    }

    private void Chase()
    {
        if (playerDistance > enemyData.chaseDistance)
        {
            SetState(EnemyState.Wander);
            return;
        }

        NavMeshPath path = new NavMeshPath();
        if (agent.CalculatePath(player.transform.position, path))
        {
            agent.SetDestination(player.transform.position);
        }

    }

    private void Attack()
    {
        if (Time.time - lastAttackTime < enemyData.attackRate)
            return;

        lastAttackTime = Time.time;

        Ray ray = new Ray(transform.position + Vector3.up * 1f, transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, enemyData.attackDistance))
        {
            if (hit.collider.TryGetComponent(out IDamagable target))
            {
                target.TakePhysicalDamage(enemyData.damage);
            }
        }
    }

    private IEnumerator Wander()
    {
        yield return wait;

        SetState(EnemyState.Wander);
        Vector3 randomPos = transform.position +
            Random.onUnitSphere * Random.Range(minWanderDistance, maxWanderDistance);

        NavMesh.SamplePosition(randomPos, out NavMeshHit hit, maxWanderDistance, NavMesh.AllAreas);
        agent.SetDestination(hit.position);
    }

    bool IsPlayerInFieldOfView()
    {
        Vector3 directionToPlayer = player.transform.position - transform.position;
        float angle = Vector3.Angle(transform.forward, directionToPlayer);
        return angle < fieldOfView * 0.5f;
    }

    public void TakePhysicalDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
        else
        {
            animator.SetTrigger("Hit");
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
