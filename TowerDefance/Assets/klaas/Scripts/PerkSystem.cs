using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class PerkSystem : MonoBehaviour
{
    [Header("Money & Upgrade")]
    public int maxUpgrade;
    public int money;
    public int costHealth;
    public int costTower;
    public int costStart;
    public int costMeteor;
    public TextMeshProUGUI costHealthText;
    public TextMeshProUGUI costTowerText;
    public TextMeshProUGUI costStartText;
    public TextMeshProUGUI costMeteorText;

    [Header("HealthPerk")]
    [SerializeField] Image[] upgradeImages;
    public Sprite fullHeart;
    public int upgrade;
    public float health;

    [Header("TowerPerk")]
    [SerializeField] Image[] towerImage;
    public Sprite towerFull;
    public int towerUpgrade;
    public int towerLevel;

    [Header("MoneyPerk")]
    [SerializeField] Image[] moneyImage;
    public Sprite moneyFull;
    public int moneyUpgrade;
    public float startMoney;

    [Header("MeteorPerk")]
    [SerializeField] Button unlockButton;
    [SerializeField] Button meteorButton;
    [SerializeField] Image[] meteorImage;
    public int unlocked;
    public Sprite meteorFull;
    public int meteorUpgrade;
    public float meteorDamage;

    [Header("PlaceHolder Stuff")]
    public GameMaster gameMaster;
  
    private void Awake()
    {
        //Health Upgrade
        health = PlayerPrefs.GetFloat("Health");
        upgrade = PlayerPrefs.GetInt("maxHealthUpgrade");
        costHealth = 5 + upgrade * 5;
        //Tower Upgrade
        towerLevel = PlayerPrefs.GetInt("towerLevel");
        towerUpgrade = PlayerPrefs.GetInt("towerUpgrade");
        costTower = 5 + towerUpgrade * 5;
        //Money Upgrade
        startMoney = PlayerPrefs.GetFloat("startMoney");
        moneyUpgrade = PlayerPrefs.GetInt("moneyUpgrade");
        costStart = 5 + moneyUpgrade * 5;
        //Meteor Upgrade
        unlocked = PlayerPrefs.GetInt("meteorUnlocked");
        meteorUpgrade = PlayerPrefs.GetInt("meteorUpgrade");
        meteorDamage = PlayerPrefs.GetFloat("meteorDamage");
        costMeteor = 5 + meteorUpgrade * 5;
    }
    private void Start()
    {
        if(unlocked == 1)
        {
            meteorButton.interactable = true;
            unlockButton.gameObject.SetActive(false);
        }
        else if(unlocked == 2)
        {
            meteorButton.interactable = false;
        }

        for (int i = 0; i < upgradeImages.Length; i++)
        {
            if (i < upgrade)
            {
                upgradeImages[i].sprite = fullHeart;
            }
            if (i < towerUpgrade)
            {
                towerImage[i].sprite = towerFull;
            }
            if (i < moneyUpgrade)
            {
                moneyImage[i].sprite = moneyFull;
            }
            if (i < meteorUpgrade)
            {
                meteorImage[i].sprite = meteorFull;
            }
        }
    }

    private void Update()
    {
        money = PlayerPrefs.GetInt("balance");
        if (Input.GetKey(KeyCode.F))
        {
          PlayerPrefs.DeleteKey("Health");
          PlayerPrefs.DeleteKey("maxHealthUpgrade");

          PlayerPrefs.DeleteKey("towerLevel");
          PlayerPrefs.DeleteKey("towerUpgrade");

          PlayerPrefs.DeleteKey("startMoney");
          PlayerPrefs.DeleteKey("moneyUpgrade");

          PlayerPrefs.DeleteKey("meteorUnlocked");
          PlayerPrefs.DeleteKey("meteorUpgrade");
          PlayerPrefs.DeleteKey("meteorDamage");
        }

        costHealthText.text = costHealth.ToString();
        costTowerText.text = costTower.ToString();
        costStartText.text = costStart.ToString();
        costMeteorText.text = costMeteor.ToString();
}
    public void UpgradeHealth()
    {
       
        if (money >= costHealth && upgrade < maxUpgrade)//
        {
            PlayerPrefs.SetInt("balance",PlayerPrefs.GetInt("balance") - costHealth);
            costHealth = 5 * upgrade; 
           // PlayerPrefs.SetInt("maxHealthUpgrade", upgrade);
            upgrade += 1;
            switch (upgrade)
            {
                case 1:
                    health += 100;
                    Debug.Log("Upgrade" + upgrade);

                    PlayerPrefs.SetFloat("Health", health);
                    PlayerPrefs.SetInt("maxHealthUpgrade", upgrade);

                    upgradeImages[0].sprite = fullHeart;
                    return;
                case 2:
                    health += 100;
                    Debug.Log("Upgrade" + upgrade);

                    PlayerPrefs.SetFloat("Health", health);
                    PlayerPrefs.SetInt("maxHealthUpgrade", upgrade);

                    upgradeImages[1].sprite = fullHeart;
                    return;
                case 3:
                    health += 100;
                    Debug.Log("Upgrade" + upgrade);

                    PlayerPrefs.SetFloat("Health", health);
                    PlayerPrefs.SetInt("maxHealthUpgrade", upgrade);

                    upgradeImages[2].sprite = fullHeart;
                    return;
                case 4:
                    health += 100;
                    Debug.Log("Upgrade" + upgrade);

                    PlayerPrefs.SetFloat("Health", health);
                    PlayerPrefs.SetInt("maxHealthUpgrade", upgrade);

                    upgradeImages[3].sprite = fullHeart;
                    return;
                case 5:
                    health += 100;
                    Debug.Log("Upgrade" + upgrade);

                    PlayerPrefs.SetFloat("Health", health);
                    PlayerPrefs.SetInt("maxHealthUpgrade", upgrade);

                    upgradeImages[4].sprite = fullHeart;
                    return;
                case 6:
                    health += 100;
                    Debug.Log("Upgrade" + upgrade);

                    PlayerPrefs.SetFloat("Health", health);
                    PlayerPrefs.SetInt("maxHealthUpgrade", upgrade);

                    upgradeImages[5].sprite = fullHeart;
                    return;
                default:
                    Debug.Log("No Upgrades");
                    return;
            }

           

            //} else
            // {
            //     PlayerPrefs.SetInt("maxHealthUpgrade", upgrade);
            //     Debug.Log("Upgrade Limit");
            // }
        }
    }
    public void UpgradeTower()
    {
        if (money >= costTower && towerUpgrade < maxUpgrade)
        {
            PlayerPrefs.SetInt("balance", PlayerPrefs.GetInt("balance") - costTower);
            costTower = 5 * towerUpgrade;
            towerUpgrade += 1;
            switch (towerUpgrade)
            {
                case 1:
                    PlayerPrefs.SetInt("towerUpgrade", towerUpgrade);
                    PlayerPrefs.SetInt("towerLevel", towerLevel);

                    towerLevel += 3;
                    towerImage[0].sprite = towerFull;
                    return;

                case 2:
                    PlayerPrefs.SetInt("towerUpgrade", towerUpgrade);
                    PlayerPrefs.SetInt("towerLevel", towerLevel);

                    towerLevel += 3;
                    towerImage[1].sprite = towerFull;
                    return;

                case 3:
                    PlayerPrefs.SetInt("towerUpgrade", towerUpgrade);
                    PlayerPrefs.SetInt("towerLevel", towerLevel);

                    towerLevel += 3;
                    towerImage[2].sprite = towerFull;
                    return;

                case 4:
                    PlayerPrefs.SetInt("towerUpgrade", towerUpgrade);
                    PlayerPrefs.SetInt("towerLevel", towerLevel);

                    towerLevel += 3;
                    towerImage[3].sprite = towerFull;
                    return;

                case 5:
                    PlayerPrefs.SetInt("towerUpgrade", towerUpgrade);
                    PlayerPrefs.SetInt("towerLevel", towerLevel);

                    towerLevel += 3;
                    towerImage[4].sprite = towerFull;
                    return;

                case 6:
                    PlayerPrefs.SetInt("towerUpgrade", towerUpgrade);
                    PlayerPrefs.SetInt("towerLevel", towerLevel);

                    towerLevel += 3;
                    towerImage[5].sprite = towerFull;
                    return;

                default: Debug.Log("Something Wrong");
                    return;
            }
        }
    }
    public void UpgradeMoney()
    {
        if (money >= costStart && towerUpgrade < maxUpgrade)
        {
            PlayerPrefs.SetInt("balance", PlayerPrefs.GetInt("balance") - costStart);
            costStart = 5 * moneyUpgrade;
            moneyUpgrade += 1;
            switch (moneyUpgrade)
            {
                case 1:
                    PlayerPrefs.SetFloat("startMoney", startMoney);
                    PlayerPrefs.SetInt("moneyUpgrade", moneyUpgrade);

                    startMoney += 100;
                    moneyImage[0].sprite = moneyFull;
                    return;

                case 2:
                    PlayerPrefs.SetFloat("startMoney", startMoney);
                    PlayerPrefs.SetInt("moneyUpgrade", moneyUpgrade);

                    startMoney += 100;
                    moneyImage[1].sprite = moneyFull;
                    return;

                case 3:
                    PlayerPrefs.SetFloat("startMoney", startMoney);
                    PlayerPrefs.SetInt("moneyUpgrade", moneyUpgrade);

                    startMoney += 100;
                    moneyImage[2].sprite = moneyFull;
                    return;

                case 4:
                    PlayerPrefs.SetFloat("startMoney", startMoney);
                    PlayerPrefs.SetInt("moneyUpgrade", moneyUpgrade);

                    startMoney += 100;
                    moneyImage[3].sprite = moneyFull;
                    return;

                case 5:
                    PlayerPrefs.SetFloat("startMoney", startMoney);
                    PlayerPrefs.SetInt("moneyUpgrade", moneyUpgrade);

                    startMoney += 100;
                    moneyImage[4].sprite = moneyFull;
                    return;

                case 6:
                    PlayerPrefs.SetFloat("startMoney", startMoney);
                    PlayerPrefs.SetInt("moneyUpgrade", moneyUpgrade);

                    startMoney += 100;
                    moneyImage[5].sprite = moneyFull;
                    return;

                default:
                    Debug.Log("Something Wrong");
                    return;
            }
        }
    }
    public void UpgradeMeteor()
    {
        if (money >= costMeteor && towerUpgrade < maxUpgrade)
        {
            PlayerPrefs.SetInt("balance", PlayerPrefs.GetInt("balance") - costMeteor);
            costMeteor = 5 * meteorUpgrade;
            meteorUpgrade += 1;
            switch (meteorUpgrade)
            {
                case 1:
                    PlayerPrefs.SetInt("meteorUpgrade", meteorUpgrade);
                    PlayerPrefs.SetFloat("meteorDamage", meteorDamage);

                    meteorDamage += 50;
                    meteorImage[0].sprite = meteorFull;
                    return;

                case 2:
                    PlayerPrefs.SetInt("meteorUpgrade", meteorUpgrade);
                    PlayerPrefs.SetFloat("meteorDamage", meteorDamage);

                    meteorDamage += 50;
                    meteorImage[1].sprite = meteorFull;
                    return;

                case 3:
                    PlayerPrefs.SetInt("meteorUpgrade", meteorUpgrade);
                    PlayerPrefs.SetFloat("meteorDamage", meteorDamage);

                    meteorDamage += 50;
                    meteorImage[2].sprite = meteorFull;
                    return;

                case 4:
                    PlayerPrefs.SetInt("meteorUpgrade", meteorUpgrade);
                    PlayerPrefs.SetFloat("meteorDamage", meteorDamage);

                    meteorDamage += 50;
                    meteorImage[3].sprite = meteorFull;
                    return;

                case 5:
                    PlayerPrefs.SetInt("meteorUpgrade", meteorUpgrade);
                    PlayerPrefs.SetFloat("meteorDamage", meteorDamage);

                    meteorDamage += 50;
                    meteorImage[4].sprite = meteorFull;
                    return;

                case 6:
                    PlayerPrefs.SetInt("meteorUpgrade", meteorUpgrade);
                    PlayerPrefs.SetFloat("meteorDamage", meteorDamage);

                    meteorDamage += 50;
                    meteorImage[5].sprite = meteorFull;
                    return;

                default:
                    Debug.Log("Something Wrong");
                    return;
            }
        }
    }

    public void UnlockPerk()
    {
        // unlocked 1 = true - unlocked 2 = false 
        unlocked = PlayerPrefs.GetInt("meteorUnlocked");
        if (money >= costMeteor)
        {
            unlocked = 1;
            PlayerPrefs.SetInt("meteorUnlocked", unlocked);
            meteorButton.interactable = true;
            unlockButton.gameObject.SetActive(false);
        }
    }
}
