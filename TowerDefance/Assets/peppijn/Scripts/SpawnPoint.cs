using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject enemyToSpawn;
    public GameObject enemySpawned;

    public void SpawnEnemy()
    {
        enemySpawned = Instantiate(enemyToSpawn);
    }

    public EnemyController GetEnemy()
    {
        EnemyController i = enemySpawned.GetComponent<EnemyController>();
        return i;
    }
}
