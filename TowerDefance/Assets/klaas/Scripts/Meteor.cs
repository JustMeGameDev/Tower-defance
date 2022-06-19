using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public GameObject impactExplosion;
    public float range = 100f;
    public float damage = 500f;
    private void Start()
    {
        damage += PlayerPrefs.GetFloat("meteorDamage");
    }
    public void OnCollisionEnter(Collision collision)
    {
        Instantiate(impactExplosion, transform.position,transform.rotation);
        Collider[] hitCollider = Physics.OverlapSphere(transform.position, range, 10);
       
        if(collision.gameObject.tag == "Enemy")
       {
           collision.gameObject.GetComponent<EnemyController>().health -= damage;
            foreach (var e in hitCollider)
            {
                e.gameObject.GetComponent<EnemyController>().health -= damage;
            }
            Destroy(gameObject);
        } else
        {
          
            Destroy(gameObject);
       }
    }
}
