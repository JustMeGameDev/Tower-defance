using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject enemyToSpawn;


    public void SpawnEnemy()
    {
        Instantiate(enemyToSpawn);
    }

    public EnemyController GetEnemy()
    {
        EnemyController i = enemyToSpawn.GetComponent<EnemyController>();
        return i;
    }
}
