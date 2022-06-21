using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeTower : MonoBehaviour
{
    [Header("Scripts")]
    public TowerTest towerTest;
    public GameMaster gameMaster;
    [Header("Floats")]
    public float specialUpgradeOne;
    public float specialUpgradeTwo;
    public float costMultiplier;
    public float cost;
    [Header("Ints")]
    public int level;
    public int maxLevel;
    [Header("UI")]
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI CostText;
    public TextMeshProUGUI CostText1;
    public TextMeshProUGUI CostText2;
    public Button upgradeOne;
    public Button upgradeTwo;


    void Awake()
    {
        gameMaster = GameObject.FindWithTag("GameMaster").GetComponent<GameMaster>();
        CostText.text = "Cost: " + cost + " $";
        CostText1.text = "" + specialUpgradeOne + " $";
        CostText2.text = "" + specialUpgradeTwo + " $";
        switch (PlayerPrefs.GetString("gameMode"))
        {
            case "Carreer":
                maxLevel += PlayerPrefs.GetInt("towerLevel");
                break;
            case "Custom":

                break;
            case "Random":

                break;
        }
    }
    
    public void Upgrade()
    {
        if (gameMaster.money > cost && level < maxLevel)
        {
            towerTest.range = towerTest.range * 1.15f;
            towerTest.damage = towerTest.damage * 1.5f;
            level++;
            levelText.text = "level: " + level;
            gameMaster.money = gameMaster.money - cost;
            cost = cost * costMultiplier;
            CostText.text = "Cost: " + cost + " $";
            return;
        }
    }
}
