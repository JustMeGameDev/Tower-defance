using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortarShoot : MonoBehaviour
{
    [Range(20.0f, 75.0f)] public float LaunchAngle;
   // public float waitTime;
   [Header("Shoot")]
    public GameObject Bullet;
    public Transform FirePoint;

    [Header("Target")]
    public GameObject Mark;

    public float waitTime;
    private bool bTouchingGround;
    [SerializeField] private bool Reloading;


    public RaycastHit hit;

    void Start()
    {
        
    }


    void Update()
    {
        waitTime  -= Time.deltaTime;
        Shoot();
        if (Input.GetMouseButton(0))
        {
            SpawnTarget();
        }

    }
    
    public void SpawnTarget()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
          //GameObject currentMark =  Instantiate(Mark, hit.point + Vector3.up * 0.01f, Quaternion.Euler(0, 0, 0));
         //   Instantiate(Mark ,transform.position, transform.rotation); 
            Shoot();
          //  Destroy(currentMark.gameObject);
        }
    }
    public void SetTarget()
    {
      //  GameObject currenMark = GameObject.FindGameObjectWithTag("Mark");
     //   if (currenMark.activeInHierarchy)
      //  {
          //  Destroy(currenMark);
            Instantiate(Mark, hit.point + Vector3.up * 0.01f, Quaternion.Euler(0, 0, 0));
      //  }
    }
    public void Shoot()
    {
        if (waitTime <= 0)
        {
            waitTime = 2f;
            
            Instantiate(Bullet, FirePoint.position, transform.rotation);
           
        }
    }

}
