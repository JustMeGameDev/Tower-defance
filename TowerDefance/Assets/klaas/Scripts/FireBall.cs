using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float speed = 2f;
    public float damage = 30f;
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

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }


    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            target.gameObject.GetComponent<EnemyController>().health -= damage;
            Destroy(gameObject);
        }
    }
    void HitTarget()
    {
        target.gameObject.GetComponent<EnemyController>().health -= damage * Time.deltaTime;
        Destroy(gameObject);
    }
}
