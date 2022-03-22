using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBluePrint : MonoBehaviour
{
    public GameObject barracks_blueprint;
    public void SpawnTowerBlueprint()
    {
        Instantiate(barracks_blueprint);
    }
}
