using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public GameObject enemy_1;
    public GameObject enemy_2;
    
    
    public GameObject enemyToSpawn;
    public Transform spawnPoint;
    public int difficulty;
    public int currentWave = 1;
    public List<GameObject> enemyWave;
    public int waveSize;
    public float spawnTime = 2f;


    //Econemy
    public int money = 0;
    private int roundReward = 15;
    private float ecoTimer = 1;
    private int passiveIncome = 10;


    void Start()
    {
        enemyWave = new List<GameObject>();
    }

    void Update()
    {
        SpawnWave();
        Timer();
        HandleEconemy();
    }


    private void SpawnWave()
    {
        if (enemyWave.Count == 0 && waveSize == 0)
        {
            waveSize = currentWave * difficulty * 3;
            currentWave++;
            roundReward = roundReward * 1.02f;
        }





        if (waveSize > 0) 
        {
            if (spawnTime == 0)
            {

                int i = Random.Range(0, 100);
                if (i > 25)
                {
                    enemyToSpawn = enemy_1;
                    waveSize = waveSize - 1;
                }
                else if (i < 25)
                {
                    enemyToSpawn = enemy_2;
                    waveSize = waveSize - 2;
                }
                GameObject enemyTemp = Instantiate(enemyToSpawn, spawnPoint.position, spawnPoint.rotation);
                enemyWave.Add(enemyTemp);
                spawnTime = 2;
            }
        }
        if (waveSize < 0)
        {
            waveSize = 0;
        }
    }

    private void Timer() 
    {
        if (spawnTime > 0)
        {
            spawnTime -= Time.deltaTime;
        }
        if (spawnTime < 0)
        {
            spawnTime = 0;
        }
        if (spawnTime > 0)
        {
            spawnTime -= Time.deltaTime;
        }
        if (spawnTime < 0)
        {
            spawnTime = 0;
        }
    }

    public void HandleEconemy()
    {

    }
}
