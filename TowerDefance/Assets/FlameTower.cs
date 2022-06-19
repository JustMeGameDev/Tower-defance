using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameTower : MonoBehaviour
{
    [Header("Fire FX")]
    public ParticleSystem flame;
    public bool isActive;
    public float Damage = 25;
    void Start()
    {
        //TowerTest towerTest = 
    }

    // Update is called once per frame
    void Update()
    {
       if(isActive == true)
        {
            flame.Play();
        }
        if(isActive == false)
        {
            flame.Stop();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyController>().health -= Damage * Time.deltaTime;
            isActive = true;
            Debug.Log("true");
        } 
        
            
        
              
    }
    private void OnTriggerExit(Collider other)
    {
       other.gameObject.GetComponent<EnemyController>().health -= Damage;
        Debug.Log("false");
        isActive = false;
    }
}
