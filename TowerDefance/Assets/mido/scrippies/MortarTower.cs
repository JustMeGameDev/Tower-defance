using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortarTower : MonoBehaviour
{
    [Range(20.0f, 75.0f)] public float LaunchAngle;
    public float waitTime;
    public float wait;
    [Header("Shoot")]
    public GameObject Bullet;
    public GameObject Canon;
    public GameObject Mark;

    [Header("VFX")]
    public GameObject explosion;

    private bool bTouchingGround;
    [SerializeField] private bool Reloading;


    public RaycastHit hit;



    void Start()
    {

    }

    void Update()
    {

        waitTime -= Time.deltaTime;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                Instantiate(Mark, hit.point + Vector3.up * 0.01f, Quaternion.Euler(0, 0, 0));
            }
        }
        if (waitTime <= 0)
        {
            waitTime = 2f;
           GameObject currentExplosion = Instantiate(explosion, Canon.transform.position, Quaternion.identity);
            Instantiate(Bullet, Canon.transform.position, Quaternion.Euler(new Vector3(90, 0, 90)));
        
        }
       
    }
    public void Target()
    {
        
       
       // if (Input.GetMouseButton(0))
       //{
         



            Debug.DrawLine(Camera.main.transform.position, hit.point, Color.red);
       //         //Debug.Log(hit.transform.position.x);

       //         if (hit.transform != null)
       //         {
       //            // waitTime = 2f;
              Instantiate(Mark, hit.point + Vector3.up * 0.01f, Quaternion.Euler(0, 0, 0));
       //             //  Instantiate(Bullet, Canon.transform.position, Quaternion.Euler(new Vector3(90, 0, 90)));


          
       //     }
       // }
    }
    public void SetTarget()
    {
       
            GameObject currenMark = GameObject.FindGameObjectWithTag("Mark");
            if (currenMark.activeInHierarchy)
            {
                Destroy(currenMark);
             
            } else
        {
            Instantiate(Mark, hit.point + Vector3.up * 0.01f, Quaternion.Euler(0, 0, 0));
        }
        }
  
    }

