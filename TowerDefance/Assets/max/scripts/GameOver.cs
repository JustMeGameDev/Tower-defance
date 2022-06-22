using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{

    [Header("death screen custom")]
    public TextMeshProUGUI roundsText;
    public GameObject gameOver;
    [Header("death screen endless")]
    public TextMeshProUGUI roundsTextE;
    public GameObject gameOverE;
    [Header("death screen career")]
    public TextMeshProUGUI roundsTextC;
    public GameObject gameOverC;
    [Header("win screen career")]
    public TextMeshProUGUI rewardsTextCw;
    public GameObject gameOverCw;
    [Header("win screen custom")]
    public GameObject gameOverCW;
    [Header("")]

    public string TempScore;
    public GameMaster gameMaster;
    void Start()
    {
        gameMaster = GameObject.FindWithTag("GameMaster").GetComponent<GameMaster>();
    }


    void Update()
    {
        int tempscore = gameMaster.currentWave - 1;
        TempScore = tempscore.ToString();
        roundsText.text = "rounds survived: " + TempScore;
        roundsTextE.text = "rounds survived: " + TempScore;
        roundsTextC.text = "rounds survived: " + TempScore;
        
        switch (PlayerPrefs.GetString("gameMode"))
        {
            case "Carreer":
                if (!gameMaster.isAlive)
                {
                    gameOverC.SetActive(true);
                    Time.timeScale = 0;

                }
                else if (gameMaster.win)
                {
                    gameOverCw.SetActive(true);
                    int tempreward = PlayerPrefs.GetInt("reward");
                    rewardsTextCw.text = "your reward is " + tempreward.ToString() + " gems";
                    Time.timeScale = 0;
                }
                break;
            case "Custom":
                if (!gameMaster.isAlive)
                {
                    gameOver.SetActive(true);
                    Time.timeScale = 0;

                }
                else if (gameMaster.win == true)
                {
                    gameOverCW.SetActive(true);
                    Time.timeScale = 0;
                }
                break;
            case "Random":
                if (!gameMaster.isAlive)
                {
                    gameOverE.SetActive(true);
                    Time.timeScale = 0;

                }
                break;
        }




        
    }
    public void Retry()
    {
       // SceneManager.LoadScene();
    }

    public void Menu()
    {

    }
}
