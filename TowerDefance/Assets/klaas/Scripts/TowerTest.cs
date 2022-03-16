using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTest : MonoBehaviour
{
    private Transform target;
    private float range = 15;

    [Header("Aim Setup")]
    [SerializeField]
    Transform rotator;
    float turnSpeed = 10;
    string enemyTag = "Enemy";

    void Start()
    {
        InvokeRepeating("SelectTarget", 0, 1f);
    }
  
    void Update()
    {

        if (target != null)
        {
            LookAtTarget();
        }
    }

    void SelectTarget()
    {     

        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        Collider[] colliders = Physics.OverlapSphere(transform.position, range);
        foreach (Collider c in colliders)
        {
            if (c.gameObject.CompareTag(enemyTag))
            {
                float distanceToEnemy = Vector3.Distance(transform.position, c.gameObject.transform.position);
                if (distanceToEnemy < shortestDistance)
                {
                    shortestDistance = distanceToEnemy;
                    nearestEnemy = c.gameObject;
                }
            }
        }
        if (nearestEnemy != null && shortestDistance < range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }

    }

    void LookAtTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(rotator.rotation, lookRotation, turnSpeed * Time.deltaTime).eulerAngles;
        rotator.rotation = Quaternion.Euler(0, rotation.y, 0);
    }
}
