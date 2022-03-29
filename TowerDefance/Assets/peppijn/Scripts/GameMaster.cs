using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameMaster : MonoBehaviour
{
    [Header("Enemy Prefabs")]
    public GameObject enemy_1;
    public GameObject enemy_2;
    
    [Header("Wave System")]
    public GameObject enemyToSpawn;
    public Transform spawnPoint;
    public int difficulty;
    public int currentWave = 1;
    public List<GameObject> enemyWave;
    public int waveSize;
    public float spawnTime = 2f;


    [Header("Economy")]
    public float money = 0;
    private float roundReward = 15;
    private float ecoTimer = 1;
    private float passiveIncome = 10;
    private int ecoCounter;
    public TextMeshProUGUI moneyText;

    [Header("Pop Up")]
    public List<PopUp> Towers;
    public PopUp OpenTower;


    void Start()
    {
        enemyWave = new List<GameObject>();
        Towers = new List<PopUp>();
    }

    void Update()
    {
        SpawnWave();
        Timer();
        HandleEconemy();
        moneyText.text = Mathf.Round(money) + "$";
    }
    void FixedUpdate()
    {
        PopUpHandler();
    }


    private void SpawnWave()
    {
        if (spawnPoint == null)
        {
            spawnPoint = GameObject.FindWithTag("spawnPoint").transform;
        }
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

    private void PopUpHandler()
    {
        foreach (PopUp i in Towers)
        {
            if (OpenTower == null)
            {
                OpenTower = i;
            }
            if (i.GetIsOpen() == true && OpenTower != i)
            {
                OpenTower.IsOpen = false;
                OpenTower = i;
            }
        }
    }
}
