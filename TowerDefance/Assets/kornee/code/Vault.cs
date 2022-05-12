using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Vault : MonoBehaviour
{
    [Header("scripts")]
    public ContractSystem contractSystem;
    public MapBuilder mapBuilder;
    public ShopMaster shopMaster;
    public GameMaster gameMaster;
    public EnemyController enemyController;

    [Header("var")]
    public bool contractseed;
    public int currentseed;

    public Scene scene;
    private void Awake()
    {
        scene = SceneManager.GetActiveScene();
        if (scene.buildIndex == 0)
        {
            contractSystem = GameObject.FindWithTag("ContractSystem").GetComponent<ContractSystem>();
        }
        else
        {
        mapBuilder = GameObject.FindWithTag("MapBuilder").GetComponent<MapBuilder>();
        gameMaster = GameObject.FindWithTag("GameMaster").GetComponent<GameMaster>();
        shopMaster = GameObject.FindWithTag("ShopMaster").GetComponent<ShopMaster>();
        enemyController = GameObject.FindWithTag("EnemyController").GetComponent<EnemyController>();
        }
        
    }
    public void Update()
    {
        currentseed = PlayerPrefs.GetInt("SelectedSeed");
        if (contractSystem.contractseed)
        {
            contractseed = true;
        }
    }
}
