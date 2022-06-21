using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{


    public TextMeshProUGUI roundsText;
    string TempScore;

    void OnEnable()
    {
    }

    public Canvas gameOver;
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
        if (!gameMaster.isAlive)
        {
            gameOver.enabled = true;
            Time.timeScale = 0;

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
