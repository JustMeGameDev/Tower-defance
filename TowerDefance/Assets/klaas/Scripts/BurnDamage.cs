using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnDamage : MonoBehaviour
{
    public float burnDamage = 25f;
    public Transform target;

    private void Start()
    {
        StartCoroutine(FireCountDown());
    }
    void Update()
    {
        
    }

    IEnumerator FireCountDown()
    {
        
        yield return new WaitForSeconds(5f);
        Debug.Log("FireRing Destroyed");
        Destroy(gameObject);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
           other.gameObject.GetComponent<EnemyController>().health -= burnDamage * Time.deltaTime;
        }
    }
    
}
