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
    public float difficulty;
    public int currentWave;
    public List<GameObject> enemyWave;
    public int waveSize = 1;
    public int spawnTimeValue;
    private float spawnTime = 0f;
    public TextMeshProUGUI WaveCounter;
    public int finalWave;
    public bool win;

    [Header("BossWave")]
    public int bossSpawnChance;
    public GameObject[] Bosses;
    public GameObject bossToSpawn;
    public bool isBossWave;
    public Transform BossSpawn;

    [Header("Economy")]
    public float money = 0;
    private float roundReward = 25;
    private float ecoTimer = 1;
    private float passiveIncome = 12;
    public float StartMoney = 900;
    private int ecoCounter;
    public TextMeshProUGUI moneyText;

    [Header("Pop Up")]
    public List<PopUp> Towers;
    public PopUp OpenTower;
    public PauseMenu pause;

    [Header("PlayerHealth")]
    public float playerHealth;
    public bool isAlive;
    public float PlayerMaxHealth;
    public Slider healthbar;
    public TextMeshProUGUI health;
    public bool healthIsSet = false;


    public float agentAvoidenceTime;

    public bool isSimmed;

    void Start()
    {   
        //pause = GameObject.FindWithTag("pauze").GetComponent<PauseMenu>();
        switch (PlayerPrefs.GetString("gameMode"))
        {
            case "Carreer":
                difficulty = PlayerPrefs.GetFloat("difficulty");
                finalWave = PlayerPrefs.GetInt("finalWave");
                if (PlayerPrefs.GetInt("finalWave") != 0)
                {
                    finalWave = PlayerPrefs.GetInt("finalWave");
                }
                else {
                    finalWave = 20;
                }
                PlayerMaxHealth += PlayerPrefs.GetFloat("Health");
                StartMoney += PlayerPrefs.GetFloat("startMoney");
                break;
            case "Custom":
                difficulty = PlayerPrefs.GetFloat("difficulty");
                finalWave = PlayerPrefs.GetInt("finalWave");
                break;
            case "Random":
                finalWave = 999999999;
                difficulty = Random.Range(0.5f,1.5f);
                break;
        }
 
            enemyWave = new List<GameObject>();
            Towers = new List<PopUp>();
            money += StartMoney;
            WaveCounter.text = "Wave: " + currentWave;
            
            healthbar.maxValue = PlayerMaxHealth;
            healthbar.minValue = 0;
            healthbar = GameObject.FindWithTag("Healthbar").GetComponent<Slider>();
            isAlive = true;

    }

    void Update()
    {
        if (!healthIsSet)
        {
            playerHealth = PlayerMaxHealth;
            healthIsSet = true;
        }
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
            healthbar.value = playerHealth;
            health.text = playerHealth + " / " + PlayerMaxHealth;
            if (playerHealth <= 0)
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
            pause.open();
        }
            
    }


    private void SpawnWave()
    { 
        if (currentWave <= finalWave ) {
            //waveSetup
            if (enemyWave.Count == 0 && waveSize == 0)
            {
                bossSpawnChance += (int) (10 * difficulty);
                float chance = Random.Range(0, 100);
                if (bossSpawnChance > chance)
                {
                    isBossWave = true;
                }
                float waveSizeTemp = currentWave * difficulty * 3;
                waveSize = (int)waveSizeTemp;

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
            if (spawnTime == 0 && (!isBossWave || currentWave < 10)) {
                for (int i = 0; i < spawnPoints.Length; i++)
                {
                    if (waveSize > 0)
                    {
                        int rdm = Random.Range(0, enemyTypes.Count);
                        enemyToSpawn = enemyTypes[rdm];
                        //Debug.Log("now spawning: " + enemyToSpawn + "at: " + i.name );
                        if (!isSimmed)
                        {
                            GameObject enemySpawned = Instantiate(enemyToSpawn, spawnPoints[i].transform.position, spawnPoints[i].transform.rotation);

                            waveSize -= enemySpawned.GetComponent<EnemyController>().spawnValue;
                            enemyWave.Add(enemySpawned);
                        }
                    }
                }
                spawnTime += spawnTimeValue;
            }
            else if (spawnTime == 0 && isBossWave && waveSize > 0)
            {
                int random = Random.Range(0,Bosses.Length);
                GameObject enemySpawned = Instantiate(Bosses[random], spawnPoints[1].transform.position, spawnPoints[1].transform.rotation);

                waveSize -= enemySpawned.GetComponent<EnemyController>().spawnValue;
                enemyWave.Add(enemySpawned);
                bossSpawnChance = 20;
                isBossWave = false;
            }


            if (waveSize < 0)
            {
                waveSize = 0;
            }
        }
        else if (currentWave > finalWave)
        {
            win = true;
            if (win == true) { int menyget = PlayerPrefs.GetInt("balance") + PlayerPrefs.GetInt("reward"); 
                PlayerPrefs.SetInt("balance", menyget); }

            
           
            return;
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
