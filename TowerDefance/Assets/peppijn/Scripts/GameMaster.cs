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
    public float money = 0;
    private float roundReward = 15;
    private float ecoTimer = 1;
    private float passiveIncome = 10;
    private int ecoCounter;


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
            roundReward = roundReward * 1.05f;
            money = money + roundReward;
            ecoCounter++;
            if (ecoCounter == 5)
            {
                passiveIncome = passiveIncome * 1.1f;
                ecoCounter = 0;
            }
            
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
        if (ecoTimer > 0)
        {
            ecoTimer -= Time.deltaTime;
        }
        if (ecoTimer < 0)
        {
            ecoTimer = 0;
        }
    }

    public void HandleEconemy()
    {
        if (ecoTimer == 0)
        {
            money = money + passiveIncome;
            ecoTimer++;
        }
    }
}
