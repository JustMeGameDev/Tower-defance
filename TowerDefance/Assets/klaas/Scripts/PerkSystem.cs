using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PerkSystem : MonoBehaviour
{
    [Header("Money & Upgrade")]
    public int maxUpgrade;
    public float money;
    public float cost;

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

    [Header("PlaceHolder Stuff")]
    public GameMaster gameMaster;
  
    private void Awake()
    {
        //Health Upgrade
        health = PlayerPrefs.GetFloat("Health");
        upgrade = PlayerPrefs.GetInt("maxHealthUpgrade");

        //Tower Upgrade
        towerLevel = PlayerPrefs.GetInt("towerLevel");
        towerUpgrade = PlayerPrefs.GetInt("towerUpgrade");
    }
    private void Start()
    {
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
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
          PlayerPrefs.DeleteKey("Health");
          PlayerPrefs.DeleteKey("maxHealthUpgrade");

          PlayerPrefs.DeleteKey("towerLevel");
          PlayerPrefs.DeleteKey("towerUpgrade");
        }
    }
    public void UpgradeHealth()
    {
       
        if (money >= cost && upgrade < maxUpgrade)//
        {
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
        if (money >= cost && towerUpgrade < maxUpgrade)
        {
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
}
