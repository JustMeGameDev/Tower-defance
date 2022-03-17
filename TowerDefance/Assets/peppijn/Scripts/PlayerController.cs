using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent navAgent;
    public Transform target;
    public GameMaster gameMaster;

    
    public float health;
    public float maxHealth;
    public int baseValue;

    void Awake()
    {
        gameMaster = GameObject.FindWithTag("GameMaster").GetComponent<GameMaster>();
        health = maxHealth;
    }

    void Update()
    {
        GetTarget();
        MoveToTarget();
        
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
            Die(true);
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
