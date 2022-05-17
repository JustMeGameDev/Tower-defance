using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortarTower : MonoBehaviour
{

    [Range(20.0f, 75.0f)] public float LaunchAngle;
    public float waitTime;

    public GameObject Bullet;
    public GameObject Canon;
    public GameObject Mark;


    private bool bTouchingGround;
    private bool Reloading = false;


    public RaycastHit hit;


    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                Debug.DrawLine(Camera.main.transform.position, hit.point, Color.red);
                //Debug.Log(hit.transform.position.x);
                if (hit.transform != null & Reloading == false)
                {
                    Instantiate(Mark, hit.point + Vector3.up * 0.01f, Quaternion.Euler(-90, 0, 0));
                    Instantiate(Bullet, Canon.transform.position, Quaternion.Euler(new Vector3(90, 0, 90)));
                    StartCoroutine(Reload(waitTime));
                }
            }

        }

    }
    IEnumerator Reload(float waitTime)
    {
        Reloading = true;
        yield return new WaitForSeconds(waitTime);
        Reloading = false;
    }

}