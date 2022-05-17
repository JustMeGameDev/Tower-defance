using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    Rigidbody rigid;
    public GameObject Mortar;
    private Quaternion initialRotation;


    void Start()
    {
        Mortar = GameObject.FindGameObjectWithTag("Mortar");

        rigid = GetComponent<Rigidbody>();
        initialRotation = transform.rotation;
        Launch(Mortar.GetComponent<MortarTower>().hit.point, Mortar.GetComponent<MortarTower>().LaunchAngle);
    }

    private void Update()
    {
        rigid.rotation = Quaternion.LookRotation(rigid.velocity) * initialRotation;
    }
    void Launch(Vector3 hit, float LaunchAngle)
    {
        //GameObject Disparo = Instantiate(Bullet, Canon.transform.position, Quaternion.identity);

   
        Vector3 projectileXZPos = new Vector3(transform.position.x, 0.0f, transform.position.z);
        Vector3 targetXZPos = new Vector3(hit.x, 0.0f, hit.z);


        transform.LookAt(targetXZPos);


        float R = Vector3.Distance(projectileXZPos, targetXZPos);
        float G = Physics.gravity.y;
        float tanAlpha = Mathf.Tan(LaunchAngle * Mathf.Deg2Rad);
        float H = hit.y - transform.position.y;
        float Vz = Mathf.Sqrt(G * R * R / (2.0f * (H - R * tanAlpha)));

        float Vy = tanAlpha * Vz;


        Vector3 localVelocity = new Vector3(0f, Vy, Vz);
        Vector3 globalVelocity = transform.TransformDirection(localVelocity);


        rigid.velocity = globalVelocity;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}