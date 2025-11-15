using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : ScriptableObject
{
    public string enemyName;
    public float maxHealth;
    public float walkSpeed;
    public float runSpeed;
    public float attackDistance; //공격사거리
    public float chaseDistance; //추적범위
    public float attackRate;
    public float damage;
}
