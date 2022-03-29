using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public NavMeshAgent navAgent;
    public Transform target;
    public GameMaster gameMaster;

    [Header("EnemyValu's")]
    public float health;
    public float maxHealth;
    public int baseValue;
    public int Damage;
    

    void Awake()
    {
        gameMaster = GameObject.FindWithTag("GameMaster").GetComponent<GameMaster>();
        health = maxHealth;

    }

    void Update()
    {
        GetTarget();
        MoveToTarget();
        Health();
    }

    private void GetTarget()
    {
        target = GameObject.FindWithTag("TargetEnd").transform;
    }
    private void MoveToTarget()
    {
        if (transform.position != target.position)
        {
            navAgent.SetDestination(target.position);
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "TargetEnd")
        {
            gameMaster.PlayerHealth -= Damage;
            Die(true);
        }
    }

    private void Health()
    {
        if(health <= 0)
        {
            Die(false);
        }
    }

    private void Die(bool ReachedEnd)
    {
        gameMaster.enemyWave.Remove(gameObject);
        Destroy(gameObject);
        if (!ReachedEnd)
        {
            gameMaster.money = gameMaster.money + baseValue;
        }
    }
}
