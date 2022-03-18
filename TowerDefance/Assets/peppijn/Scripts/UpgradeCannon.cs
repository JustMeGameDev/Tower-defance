using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeCannon : MonoBehaviour
{
    public TowerTest towerTest;
    public GameMaster gameMaster;
    public float costMultiplier;
    public float cost;
    public int level;
    public int maxLevel;
    public TextMeshProUGUI levelText;


    void Awake()
    {
        gameMaster = GameObject.FindWithTag("GameMaster").GetComponent<GameMaster>();
    }
    
    public void Upgrade()
    {
        if (gameMaster.money > cost && level < maxLevel)
        {
            towerTest.range = towerTest.range * 1.15f;
            towerTest.damage = towerTest.damage * 1.5f;
            cost = cost * costMultiplier;
            level++;
            levelText.text = "level: " + level;
            gameMaster.money = gameMaster.money - cost;
        }
    }
}
