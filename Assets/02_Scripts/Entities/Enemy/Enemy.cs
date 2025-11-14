using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyData enemyData;
    [SerializeField] private float minWanderDistance;
    [SerializeField] private float maxWanderDistance;


    private Player player;

    private WaitForSeconds wait;
    private NavMeshAgent agent;
    private EnemyState enemyState;
    private float playerDistance;
    private float health;
    private float wanderDelay;


    private void Awake()
    {
        player = GameManager.Instance.characterManager.player;
    }

    private void Start()
    {
        agent.speed = enemyData.walkSpeed;
        health = enemyData.maxHealth;
        wait = new WaitForSeconds(wanderDelay);
    }

    private void Update()
    {
        playerDistance = Vector3.Distance(transform.position, player.transform.position);

        UpdateState();
    }

    private void SetState(EnemyState state)
    {
        enemyState = state;

        switch (enemyState)
        {
            case EnemyState.Idle:
                agent.speed = enemyData.walkSpeed;
                agent.isStopped = true;
                break;
            case EnemyState.Wander:
                agent.speed = enemyData.walkSpeed;
                agent.isStopped = false;
                break;
            case EnemyState.Chase:
                agent.speed = enemyData.runSpeed;
                agent.isStopped = false;
                break;
        }
    }

    private void UpdateState()
    {
        if (enemyState == EnemyState.Wander && agent.remainingDistance < 0.1f)
        {
            SetState(EnemyState.Idle);
            StartCoroutine(Wander());
        }

        if (enemyData.chaseDistance > playerDistance)
        {
            SetState(EnemyState.Chase);
            Attack();
        }
    }

    private void Attack()
    {

    }

    private IEnumerator Wander()
    {
        yield return wait;

        SetState(EnemyState.Wander);

        NavMeshHit hit;
        NavMesh.SamplePosition(transform.position + (Random.onUnitSphere * Random.Range(minWanderDistance, maxWanderDistance)), out hit, maxWanderDistance, NavMesh.AllAreas);

        agent.SetDestination(hit.position);
    }
}
