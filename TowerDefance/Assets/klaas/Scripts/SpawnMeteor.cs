using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMeteor : MonoBehaviour
{
    public GameObject Meteor;
    RaycastHit hit;
    public void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 500000f, 1 << 7))
        {
            transform.position = hit.point; 
        }
        if (Input.GetMouseButton(0))
        {
            Instantiate(Meteor, hit.point, transform.rotation);
            Destroy(gameObject);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Destroy(gameObject); 
        }
    }
}
