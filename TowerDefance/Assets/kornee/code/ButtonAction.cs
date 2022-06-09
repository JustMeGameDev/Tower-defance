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

    public void SceneUp()
    {
        SceneManager.LoadScene("MainScene");
    }
     
}
