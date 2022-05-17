using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public NavMeshAgent navAgent;
    public Transform target;
    public GameMaster gameMaster;

    [Header("EnemyValues")]
    public float health;
    public float maxHealth;
    public int baseValue;
    public int Damage;
    public bool death = false;

    [Header("Animation")]
    public Animator animetion;
    

    

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
        if (death)
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            gameObject.GetComponent<CapsuleCollider>().enabled = false;
            gameObject.GetComponent<NavMeshAgent>().enabled = false;
            navAgent.isStopped = true;

        }
        else if (transform.position != target.position )
        {
            navAgent.SetDestination(target.position);
            animetion.SetBool("walking", true);
        }
    }

    IEnumerator TargetDead()
    {
        yield return new WaitForSeconds(0.7f);
        Die(true);
    }
    IEnumerator Dead()
    {
        yield return new WaitForSeconds(2f);
        Die(false);
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "TargetEnd")
        {
            gameMaster.PlayerHealth -= Damage;
            animetion.SetBool("attack", true);
            StartCoroutine(TargetDead());

        }
    }

    private void Health()
    {
        if(health <= 0 )
        {
            death = true;
            animetion.SetBool("die", true);
            StartCoroutine(Dead());
        }
      
    }

    private void Die(bool ReachedEnd)
    {
        gameMaster.enemyWave.Remove(gameObject);
        if (!ReachedEnd)
        {
            gameMaster.money = gameMaster.money + baseValue;
            
        }
        Destroy(gameObject);
        return;
    }

    //private void Empty()
    //{
    //    gameObject
    //}
}
