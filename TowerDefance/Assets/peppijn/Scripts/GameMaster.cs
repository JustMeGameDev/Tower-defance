using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    [Header("Enemy Prefabs")]
    public GameObject enemy_1;
    public GameObject enemy_2;
    public Image Coin;

    [Header("Wave System")]
    public GameObject enemyToSpawn;
    public Transform spawnPoint;
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



    void Start()
    {
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
        healthbar.value = PlayerHealth; // Time.deltaTime;
        health.text = PlayerHealth + " / " + PlayerMaxHealth;
        if (PlayerHealth <= 0)
        {
            isAlive = false;
        }
        if (!isAlive)
        {
            Time.timeScale = 0;
        }
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
        if (spawnPoint == null)
        {
            spawnPoint = GameObject.FindWithTag("spawnPoint").transform;
        }
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
                spawnTime = spawnTimeValue;
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
