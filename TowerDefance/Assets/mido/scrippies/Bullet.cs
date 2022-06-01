using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 2f;
    public float damage = 25f;
    public Transform target;

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
           // HitTarget();
        }
        //dir.normalized
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    
       //transform.LookAt(target, Vector3.up);
    }


    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            target.gameObject.GetComponent<EnemyController>().health -= damage;
            Destroy(gameObject);

        }
    }
    //void HitTarget()
    //{
    //    target.gameObject.GetComponent<EnemyController>().health -= damage * Time.deltaTime;
    //    Destroy(gameObject);
    //}
}


