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

    private Animator animator;
    private Coroutine coroutine;

    public float fieldOfView = 120f;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        if (GameManager.Instance != null)
        {
            player = GameManager.Instance.characterManager.player;
        }
        
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        health = enemyData.maxHealth;

        SetState(EnemyState.Wander);
        animator.SetBool("IsSpawn", true);
    }

    private void Update()
    {
        UpdateState();

        if (player == null) return;

        playerDistance = Vector3.Distance(transform.position, player.transform.position);
    }

    private void UpdateState()
    {
        animator.speed = agent.speed / enemyData.walkSpeed;
        if (playerDistance <= enemyData.attackDistance && IsPlayerInFieldOfView())
        {
            SetState(EnemyState.Attack);

            Attack();
            return;
        }

        if (playerDistance <= enemyData.chaseDistance)
        {
            SetState(EnemyState.Chase);

            Chase();
            return;
        }

        if (enemyState != EnemyState.Idle)
        {
            if (agent.remainingDistance < 0.2f)
            {
                SetState(EnemyState.Idle);
                Invoke("Wander", wanderDelay);
            }
        }
    }

    private void SetState(EnemyState newState)
    {
        enemyState = newState;

        switch (enemyState)
        {
            case EnemyState.Idle:
                AgentStopped(true);
                animator.SetBool("IsWalk", false);
                break;

            case EnemyState.Wander:
                agent.speed = enemyData.walkSpeed;
                AgentStopped(false);
                animator.SetBool("IsWalk", true);
                break;

            case EnemyState.Chase:
                agent.speed = enemyData.runSpeed;
                AgentStopped(false);
                animator.SetBool("IsWalk", true);
                break;

            case EnemyState.Attack:
                animator.SetBool("IsWalk", false);
                coroutine = StartCoroutine(StoppedCoroutine(enemyData.attackRate));
                break;
        }
    }

    private IEnumerator StoppedCoroutine(float waitTime)
    {
        agent.isStopped = true;
        yield return new WaitForSeconds(waitTime);
        coroutine = null;
        agent.isStopped = false;
    }

    private void AgentStopped(bool isStopped)
    {
        if (coroutine != null) return;

        agent.isStopped = isStopped;
    }

    private void Chase()
    {
        if(player == null) return;
        if (playerDistance > enemyData.chaseDistance)
        {
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

        animator.SetTrigger("Attack");
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

    private void Wander()
    {
        Debug.Log("배회");
        SetState(EnemyState.Wander);
        agent.SetDestination(GetWanderLocation());
    }

    private Vector3 GetWanderLocation()
    {
        NavMeshHit hit;

        NavMesh.SamplePosition(transform.position + (Random.onUnitSphere * Random.Range(minWanderDistance, maxWanderDistance)), out hit, maxWanderDistance, NavMesh.AllAreas);

        int i = 0;
        while (Vector3.Distance(transform.position, hit.position) < enemyData.attackDistance)
        {
            NavMesh.SamplePosition(transform.position + (Random.onUnitSphere * Random.Range(minWanderDistance, maxWanderDistance)), out hit, maxWanderDistance, NavMesh.AllAreas);
            i++;
            if (i == 30) break;
        }

        return hit.position;
    }

    bool IsPlayerInFieldOfView()
    {
        if(player == null)
            return false;
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
