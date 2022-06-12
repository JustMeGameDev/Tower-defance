using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public GameObject impactExplosion;
    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(impactExplosion, transform.position,transform.rotation);
        if(collision.gameObject.tag == "Enemy")
        {

            Destroy(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }
}
