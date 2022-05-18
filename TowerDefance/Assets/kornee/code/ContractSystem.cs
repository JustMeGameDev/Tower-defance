using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ContractSystem : MonoBehaviour
{
    [Header("script calling")]
    public GameMaster gamemaster;
    public MapBuilder mapbuilder;
    public Vault vault;

    [Header("seed generator")]
    public int seed1;
    public int seed2;
    public int seed3;
    public int seed4;
    

    [Header("contract text generator")]
    public TextMeshProUGUI contractTitle1;
    public TextMeshProUGUI contractTitle2;
    public TextMeshProUGUI contractTitle3;
    public TextMeshProUGUI contractTitle4;

    public TextMeshProUGUI contractText1;
    public TextMeshProUGUI contractText2;
    public TextMeshProUGUI contractText3;
    public TextMeshProUGUI contractText4;

    [Header("needs")]
    public bool contractSeed;

    
    void awake()
    {
        vault = GameObject.FindWithTag("Vault").GetComponent<Vault>();
        gamemaster = GameObject.FindWithTag("GameMaster").GetComponent<GameMaster>();
        mapbuilder = GameObject.FindWithTag("MapBuilder").GetComponent<MapBuilder>();
    }
    private void Start()
    {
        PlayerPrefs.DeleteKey("SelectedSeed");
        ContractGr();
    }
   private void ContractGr()
    {
        seed1 = Random.Range(0, 99999);
        seed2 = Random.Range(0, 99999);
        seed3 = Random.Range(0, 99999);
        seed4 = Random.Range(0, 99999);
    }

    public void Contract1()
    {
        contractSeed = true;
        PlayerPrefs.DeleteKey("SelectedSeed");
        PlayerPrefs.SetInt("SelectedSeed", seed1);
        SceneManager.LoadScene(+1);
    }
    public void Contract2()
    {
        contractSeed = true;
        PlayerPrefs.DeleteKey("SelectedSeed");
        PlayerPrefs.SetInt("SelectedSeed", seed2);
        SceneManager.LoadScene(+1);
    }
    public void Contract3()
    {
        contractSeed = true;
        PlayerPrefs.DeleteKey("SelectedSeed");
        PlayerPrefs.SetInt("SelectedSeed", seed3);
        SceneManager.LoadScene(+1);
    }
  

}
