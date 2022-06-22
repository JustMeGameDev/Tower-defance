using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class customInput : MonoBehaviour
{

    public int seed;
    public string SEED;
   
    public int maplenght;
    public int wavecount;
    public float difficulty;
    public TMP_InputField inputField;
    public Slider map;
    public Slider wave;
    public Slider diff;
    public TextMeshProUGUI count1;
    public TextMeshProUGUI count2;
    public TextMeshProUGUI count3;

    private void Awake()
    {
        PlayerPrefs.DeleteKey("seed");
        PlayerPrefs.DeleteKey("mapLength");
        PlayerPrefs.DeleteKey("finalWave");
        PlayerPrefs.DeleteKey("difficulty");
        PlayerPrefs.DeleteKey("gameMode");
    }
    public void Seed()
    {
        SEED = inputField.text;
        int.TryParse(SEED, out seed);
        PlayerPrefs.SetInt("seed", seed);
    }
    public void Maplenght()
    {
        maplenght = Mathf.RoundToInt(map.value);
        count1.text = "" + maplenght;
        PlayerPrefs.SetInt("mapLength", maplenght);
    }
    public void Wavecount()
    {
        wavecount = Mathf.RoundToInt(wave.value);
        count2.text = ""+wavecount;
        PlayerPrefs.SetInt("finalWave", wavecount);
    }
    public void Diff()
    {
        difficulty = diff.value;
        count3.text = "" + difficulty;
        PlayerPrefs.SetFloat("difficulty", diff.value);
    }
    public void begin()
    {
        PlayerPrefs.SetString("gameMode", "Custom");
        SceneManager.LoadScene("MainScene");

    }
}
