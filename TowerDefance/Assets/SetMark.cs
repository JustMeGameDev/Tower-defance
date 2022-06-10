using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMark : MonoBehaviour
{
    RaycastHit hit;
    public GameObject mark;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
         if(Physics.Raycast(ray, out hit, 50000.0f, 1 << 6))
         {
            transform.position = hit.point;
         }

         if(Input.GetMouseButton(0))
        {
           GameObject currentMark =  Instantiate(mark, transform.position, transform.rotation);
           //if(currentMark.activeInHierarchy)
           // {
               // Destroy(currentMark);
          // }
            Destroy(gameObject);
            
        }
    }
}
