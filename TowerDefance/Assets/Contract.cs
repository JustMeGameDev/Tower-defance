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
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI rewardText;
    public TextMeshProUGUI seedText;
    public TextMeshProUGUI nameText;
    public Image image;
    [Header("data")]
    public string title;
    public string description;
    public int reward;
    public int seed;
    public string name;
    public int waves;

    public Contract(string title_, string name_, string description_,Image image_)
    {
        title = title_;
        name = name_;
        description = description_;
        image = image_;
        seed = Random.Range(0,999999999);
    }

    public void CalculateReward()
    {

    }



}
