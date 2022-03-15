using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent navAgent;
    public Transform target;
    // Update is called once per frame
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
            Destroy(gameObject);
        }
    }
}
