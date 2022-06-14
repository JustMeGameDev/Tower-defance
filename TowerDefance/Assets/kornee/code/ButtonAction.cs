using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonAction : MonoBehaviour
{
    public void GameExit()
    {
        Application.Quit();
    }

    public void SceneRandom()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void CareerMode()
    {
        SceneManager.LoadScene("contract menu");
    }
     
}
