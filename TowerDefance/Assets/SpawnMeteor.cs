using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMeteor : MonoBehaviour
{
    public GameObject Meteor;
    RaycastHit hit;
    public void Spawn()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 50000.0f, 1 << 6))
        {
            Instantiate(Meteor, hit.point, transform.rotation);
        }
    }
}
