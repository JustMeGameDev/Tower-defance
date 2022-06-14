using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameMaster gameMaster;
    public GameObject MetoerMark;
    public float cost;
    public void Spawn()
    {
        if (gameMaster.money >= cost)
        {
            Instantiate(MetoerMark, transform.position, transform.rotation);
        }
    }    

}
