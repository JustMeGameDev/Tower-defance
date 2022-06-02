using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class GameMaster : MonoBehaviour
{
    [Header("Enemy Prefabs")]
    public List<GameObject> enemyTypes;
    public GameObject enemyToSpawn;
    public Image Coin;

    [Header("Wave System")]

    public MapBuilder mapBuilder;
    public GameObject[] spawnPoints;
    public int difficulty;
    public int currentWave;
    public List<GameObject> enemyWave;
    public int waveSize = 1;
    public int spawnTimeValue;
    private float spawnTime = 0f;
    public TextMeshProUGUI WaveCounter;

    [Header("Economy")]
    public float money = 1000;
    private float roundReward = 25;
    private float ecoTimer = 1;
    private float passiveIncome = 12;
    public float StartMoney = 900;
    private int ecoCounter;
    public TextMeshProUGUI moneyText;

    [Header("Pop Up")]
    public List<PopUp> Towers;
    public PopUp OpenTower;

    [Header("PlayerHealth")]
    public float PlayerHealth;
    public bool isAlive;
    public float PlayerMaxHealth;
    public Slider healthbar;
    public TextMeshProUGUI health;

    public Vault vault;
    public float agentAvoidenceTime;

    void Start()
    {
        vault = GameObject.FindWithTag("Vault").GetComponent<Vault>();
        enemyWave = new List<GameObject>();
        Towers = new List<PopUp>();
        money = money + StartMoney;
        WaveCounter.text = "Wave: " + currentWave;
        PlayerHealth = PlayerMaxHealth;
        healthbar.maxValue = PlayerMaxHealth;
        healthbar.minValue = 0;
        healthbar = GameObject.FindWithTag("Healthbar").GetComponent<Slider>();
        isAlive = true;
    }

    void Update()
    {
        if (spawnPoints.Length < 1 & mapBuilder.finishedMap)
        {
            spawnPoints = GameObject.FindGameObjectsWithTag("spawnPoint");
        }
        SpawnWave();
        Timer();
        HandleEconemy();
        if (money > 1000)
        {
           
           string TempMoney = (money / 1000).ToString("F") + "K";
            moneyText.text = TempMoney;
        }
        else
        {
            moneyText.text = Mathf.Round(money) + "";
        }
        healthbar.value = PlayerHealth;
        health.text = PlayerHealth + " / " + PlayerMaxHealth;
        if (PlayerHealth <= 0)
        {
            isAlive = false;
        }
        if (!isAlive)
        {
            Time.timeScale = 0;
        }
        NavMesh.avoidancePredictionTime = agentAvoidenceTime;
    }
    void FixedUpdate()
    {
        PopUpHandler();
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
            
    }


    private void SpawnWave()
    {
        
        //waveSetup
        if (enemyWave.Count == 0 && waveSize == 0)
        {
            waveSize = currentWave * difficulty * 3;
            currentWave++;
            int WaveCount = currentWave - 1;
            WaveCounter.text = "Wave: " + WaveCount;
            roundReward = roundReward * 1.05f;
            money = money + roundReward;
            ecoCounter++;
            if (ecoCounter == 5)
            {
                passiveIncome = passiveIncome * 1.1f;
                ecoCounter = 0;
            }

            
        }


        //waveEnemySpawning
        //Load The wave
        if (spawnTime == 0) {
            for (int i = 0; i<spawnPoints.Length;i++)
            {
                if (waveSize > 0)
                {
                    int rdm = Random.Range(0, enemyTypes.Count);
                    enemyToSpawn = enemyTypes[rdm];
                    //Debug.Log("now spawning: " + enemyToSpawn + "at: " + i.name );
                    GameObject enemySpawned = Instantiate(enemyToSpawn, spawnPoints[i].transform.position,spawnPoints[i].transform.rotation);
                    waveSize -= enemySpawned.GetComponent<EnemyController>().spawnValue;
                    enemyWave.Add(enemySpawned);
                }
            }
            spawnTime += spawnTimeValue;
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
