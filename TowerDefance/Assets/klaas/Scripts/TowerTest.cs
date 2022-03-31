using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTest : MonoBehaviour
{
    private Transform target;
    
    
    [Header("Stats")]
    public float range = 15;
    public float damage = 10;
    public float attackSpeed = 10;
    
    [Header("GameMaster")]
    public GameMaster gameMaster;

    [Header("Aim Setup")]
    [SerializeField]
    Transform rotator = null;
    public Transform firePoint = null;
    float turnSpeed = 10;
    string enemyTag = "Enemy";

    [Header("Mage")]
    public LightningBoltScript lightningBolt = null;
    public LineRenderer lineRenderer = null;
    public bool useNormal;
    public bool useLightning = false;
    public bool useFire = false;
    public bool useMage;
   
    void Start()
    {
        InvokeRepeating("SelectTarget", 0, 1f);
    }
  
    void Update()
    {

        if (target == null) //!=
        {
           
              if (useMage)
              {
                  if (lineRenderer.enabled)
                  {
                      lineRenderer.enabled = false;
                  }
              }

              return;
           
        }
        LookAtTarget();

        if (useMage)
        {
            Laser();
        }/* else
        {
            Shoot Function 
        } */
    }

    void SelectTarget()
    {     

        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
       // lightningBolt.EndObject = nearestEnemy;
      
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

    void Laser()   // Fix Bools
    {
        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
           
        }

<<<<<<< HEAD
        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);

        target.gameObject.GetComponent<EnemyController>().health -= damage *Time.deltaTime;
=======
        if(useLightning)
        {
            lightningBolt.EndPosition = target.position;
            lightningBolt.Generations = 6;
        }
        if (useNormal)
        {
           lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, target.position);
            lightningBolt.Generations = 0;
        }
        target.gameObject.GetComponent<PlayerController>().health -= damage *Time.deltaTime;
>>>>>>> MageAttack2
       
    }
}
