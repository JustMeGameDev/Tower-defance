using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public GameObject enemy_1;
    public GameObject enemy_2;
    
    
    public GameObject enemyToSpawn;
    public Transform spawnPoint;
    public float difficulty;
    private int currentWave = 1;
    private int waveSize;
    public float spawnTime = 2f;

    void Start()
    {
    }

    void Update()
    {
        SpawnWave();
        SpawnTimer();
    }


    private void SpawnWave()
    {







        if (spawnTime == 0)
        {
            
            int i = Random.Range(0,100);
            if (i > 25)
            {
                enemyToSpawn = enemy_1;
            }
            else if (i < 25)
            {
                enemyToSpawn = enemy_2;
            }
            Instantiate(enemyToSpawn, spawnPoint.position, spawnPoint.rotation);
            spawnTime = 2;
        }
    }

    private void SpawnTimer() 
    {
        if (spawnTime > 0)
        {
            spawnTime -= Time.deltaTime;
        }
        if (spawnTime < 0)
        {
            spawnTime = 0;
        }
    }

}
