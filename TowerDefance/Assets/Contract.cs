using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Contract : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI rewardText;
    public TextMeshProUGUI seedText;
    public TextMeshProUGUI nameText;
    public Image image;
    [Header("data")]
    public string title;
    public string description;
    public int reward;
    public int seed;
    public string namePerson;
    public int waves;
    public int finalWave;
    public int mapLength;
    public float difficulty;

    public void ContractAssemble(string title_, string name_,Sprite image_)
    {
        title = title_;
        namePerson = name_;
        image.sprite = image_;
        seed = Random.Range(0,999999999);
        mapLength = Random.Range(10,25);
        finalWave = Random.Range(30,40);
        difficulty = Random.Range(0.5f,1.5f);
        CalculateReward();
        Render();
    }

    public void CalculateReward()
    {
        reward = Random.Range(0, 50);
    }

    public void PickContract()
    {
        PlayerPrefs.SetString("gameMode","Carreer");
        PlayerPrefs.SetInt("seed",seed);
        PlayerPrefs.SetInt("reward", reward);
        PlayerPrefs.SetInt("mapLength", mapLength);
        PlayerPrefs.SetInt("finalWave", finalWave);
        PlayerPrefs.SetFloat("difficulty",difficulty);
        SceneManager.LoadScene("MainScene");
    }
    public void Render()
    {
        nameText.text = namePerson;
        titleText.text = title;
        seedText.text = "seed: " + seed.ToString();
        rewardText.text = reward.ToString();
    }


}
