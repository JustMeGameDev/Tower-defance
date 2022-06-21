using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slimedeath : MonoBehaviour
{
    public EnemyController enemyController;
    public GameObject enemyToSpawn;
    public GameObject spawn;
    
   public void death()
    {
                GameObject enemySpawned = Instantiate(enemyToSpawn, spawn.transform.position, transform.rotation);
                GameObject enemySpawned1 = Instantiate(enemyToSpawn, spawn.transform.position, transform.rotation);
                GameObject enemySpawned2 = Instantiate(enemyToSpawn, spawn.transform.position, transform.rotation);
                
                
    }
    
}
