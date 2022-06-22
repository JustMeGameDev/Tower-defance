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
    public TextMeshProUGUI descriptionText;
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

    [Header("CalculateReward")]
    public int minReward;
    public int maxReward;
    public int rewardPos;

    public void ContractAssemble(string title_, string name_,Sprite image_)
    {
        title = title_;
        namePerson = name_;
        image.sprite = image_;
        seed = Random.Range(0,999999999);
        mapLength = Random.Range(10,20);
        finalWave = Random.Range(15,44);
        float difficultyTemp = Random.Range(0.5f,1.5f);
        difficulty = Mathf.Round(difficultyTemp * 100.0f) * 0.01f;
        CalculateReward();
        Render();
    }

    public void CalculateReward()
    {
        rewardPos = (int) Mathf.Round(difficulty * finalWave);
        

        switch (title)
        {
            case "ill compansate royaly.":
                rewardPos += 10;
                break;
            case "i dont have much but need help.":
                rewardPos -= 10;
                break;
        }
        minReward = rewardPos - 5;
        maxReward = rewardPos + 5;
        reward = Random.Range(minReward, maxReward);
        if (reward <= 0)
        {
            reward = 6;
        }
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
        descriptionText.text = "Path Length: " + mapLength.ToString() + "\nFinal Wave: " + finalWave.ToString() + "\nDifficulty: " + difficulty;
    }


}
