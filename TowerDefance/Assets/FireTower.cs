using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTower : MonoBehaviour
{
    public ParticleSystem Flame;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    //    Collider[] colliders = Physics.OverlapBox(transform.position,);
        if (Input.GetKey(KeyCode.G))
        {
            Flame.Play();
        }
        else
        {
            Flame.Stop();
        }
    }
}
