using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    void Start()
    {
        
        
    }

    public void ModeSelect()
    {
        SceneManager.LoadScene("ModeSelect");
    }
    public void quit()
    {
        Application.Quit();
    }

    public void Settings()
    {
        SceneManager.LoadScene("settings menu");
    }   
    public void Mainmenu()
    {
        SceneManager.LoadScene("Mainmenu");
    }
    public void Custom()
    {
        SceneManager.LoadScene("custom");
    }
    public void perks()
    {
        SceneManager.LoadScene("perks");
    }public void contract()
    {
        SceneManager.LoadScene("contract menu");
    }
    public void start()
    {
        SceneManager.LoadScene("MainScene");
        Time.timeScale = 1;

    }
    public void random()
    {
        PlayerPrefs.DeleteKey("gameMode");
        PlayerPrefs.SetString("gameMode", "Random");
        SceneManager.LoadScene("MainScene");
    }
}
