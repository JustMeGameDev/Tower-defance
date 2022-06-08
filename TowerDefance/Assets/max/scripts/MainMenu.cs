using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("maintheme");
    }

    public void ModeSelect()
    {
        SceneManager.LoadScene(+1);
        Debug.Log("+1");

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
}
