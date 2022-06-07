using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBall : MonoBehaviour
{
    public float speed = 2f;
    public float explosiveDamage = 200f;
    public Transform target;
    public GameObject explosion;
    

  
   
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }

    public void OnTriggerEnter(Collider other)
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        if (other.gameObject.tag == "Enemy")
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, 4f, 1<< 10);
           

            foreach(var enemy in hitColliders)
            {
              if(enemy.gameObject.CompareTag("Enemy"))
              {
                    enemy.gameObject.GetComponent<EnemyController>().health -= explosiveDamage;
              }
            }
            target.gameObject.GetComponent<EnemyController>().health -= explosiveDamage;
            Destroy(gameObject);
        }
    }
}
