using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallistaTower : MonoBehaviour
{
    private Transform target;
    private float range = 45f;
    private float angleTreshold = 5f;

    [Header("Setup Fields")]
    public string enemyTag = "Enemy";
    public float fireDelay = 10f;
    public Transform rotator;
    public Transform firePoint;
    public float turnSpeed = 7f;
    public GameObject bullet;

    void Start()
    {
        InvokeRepeating("SelectTarget", 0, 1f);
    }


    void Update()
    {
        fireDelay -= Time.deltaTime;
        if (target != null)
        {
            RotateToTarget();
            float angle = Vector3.SignedAngle(rotator.forward, target.position - transform.position, Vector3.up);
            if (fireDelay <= 0 && Mathf.Abs(angle) <= angleTreshold)
            {
                Shoot();
                fireDelay = 4f;
            }
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
        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    void RotateToTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(rotator.rotation, lookRotation, turnSpeed * Time.deltaTime).eulerAngles;
        rotator.rotation = Quaternion.Euler(0, rotation.y, 0);

    }

    void Shoot()
    {
        GameObject BulletGO = Instantiate(bullet, firePoint);
        BulletGO.GetComponent<Bullet>().target = target;
    }
}

