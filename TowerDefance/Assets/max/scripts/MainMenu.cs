using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public Canvas Settings;
    public Canvas MainMmnu;
    private bool menu;
    private bool settings;
    public void ModeSelect()
    {
        SceneManager.LoadScene(+1);
        Debug.Log("+1");

    }
    public void MenuBack()
    {
        SceneManager.LoadScene(-1);
        Debug.Log("-1");
    }

    private void FixedUpdate()
    {
        if(menu)
        {
            Settings.enabled = false;
            MainMmnu.enabled = true;
            settings = false;
        }
        else if (settings)
        {
            MainMmnu.enabled = false;
            Settings.enabled = true;
            menu = false;
        }
    }

    public void SettingsMenu()
    {
        if (!settings)
        {
            settings = true;
            menu = false;
        }
        else if(settings)
        {
            menu = true;
            settings = false;
        }
    }
    
}
