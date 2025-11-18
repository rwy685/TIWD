using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public interface IDamagable
{
    void TakePhysicalDamage(float damage);
}
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

    private Coroutine wanderCoroutine;
    private WaitForSeconds wait;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameManager.Instance.characterManager.player;
    }

    private void Start()
    {
        wait = new WaitForSeconds(wanderDelay);
        enemyState = EnemyState.Idle;
        health = enemyData.maxHealth;
    }

    private void Update()
    {
        if (player == null) return;

        playerDistance = Vector3.Distance(transform.position, player.transform.position);
        UpdateState();
    }

    private void UpdateState()
    {
        if (playerDistance < enemyData.attackDistance)
        {
            Debug.Log("1");
            if (enemyState != EnemyState.Attack)
                SetState(EnemyState.Attack);

            Attack();
            return;
        }

        if (playerDistance < enemyData.chaseDistance)
        {
            Debug.Log("2");
            if (enemyState != EnemyState.Chase)
                SetState(EnemyState.Chase);

            Chase();
            return;
        }

        if (enemyState == EnemyState.Wander)
        {
            if (!agent.pathPending && agent.remainingDistance < 0.2f)
            {
                Debug.Log("3");
                SetState(EnemyState.Idle);
            }
            return;
        }

        if (enemyState == EnemyState.Idle)
        {
            Debug.Log("4");
            SetState(EnemyState.Wander);
            return;
        }
    }

    private void SetState(EnemyState newState)
    {
        if (enemyState == newState) return;

        enemyState = newState;

        switch (enemyState)
        {
            case EnemyState.Idle:
                agent.isStopped = true;

                if (wanderCoroutine != null)
                {
                    StopCoroutine(wanderCoroutine);
                    wanderCoroutine = null;
                }
                break;

            case EnemyState.Wander:
                agent.speed = enemyData.walkSpeed;
                agent.isStopped = false;

                wanderCoroutine = StartCoroutine(Wander());
                break;

            case EnemyState.Chase:
                agent.speed = enemyData.runSpeed;
                agent.isStopped = false;
                break;

            case EnemyState.Attack:
                agent.isStopped = true;
                break;
        }
    }

    private void Chase()
    {
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

        Vector3 randomPos = transform.position +
            Random.onUnitSphere * Random.Range(minWanderDistance, maxWanderDistance);

        NavMesh.SamplePosition(randomPos, out NavMeshHit hit, maxWanderDistance, NavMesh.AllAreas);
        agent.SetDestination(hit.position);
    }

    public void TakePhysicalDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
