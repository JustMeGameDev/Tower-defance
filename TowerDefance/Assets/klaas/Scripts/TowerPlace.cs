using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlace : MonoBehaviour
{ 
    RaycastHit hit;

    public GameObject prefab;
    public Material nonPlaceMat;
    Material startMat;
    MeshRenderer mr;
    bool isPlaceAble;

     void Start()
    {
        mr = GetComponent<MeshRenderer>();
        startMat = mr.material;
    }
    void Update()
    {
     
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 50000.0f, 1 << 6))
        {
            transform.position = hit.point;
           isPlaceAble = true;
            mr.material = startMat;

        }
        else
        {
           isPlaceAble = false;
            mr.material = nonPlaceMat;
        }

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 0.75f, 1 << 8);
      
        if(hitColliders.Length < 1)
        {
            
           if (Input.GetMouseButton(0) && isPlaceAble == true)
           {                           
                    Instantiate(prefab, transform.position, transform.rotation); // Fix Transform 
                    Destroy(gameObject);            
           }
        } else
        {
            mr.material = nonPlaceMat;
        }
    }
}
