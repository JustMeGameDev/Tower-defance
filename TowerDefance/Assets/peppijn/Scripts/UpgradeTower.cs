using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeTower : MonoBehaviour
{
    public TowerTest towerTest;
    public GameMaster gameMaster;
    public float costMultiplier;
    public float cost;
    public int level;
    public int maxLevel;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI CostText;


    void Awake()
    {
        gameMaster = GameObject.FindWithTag("GameMaster").GetComponent<GameMaster>();
        CostText.text = "Cost: " + cost + " $";
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
