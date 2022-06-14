using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CareerMenu : MonoBehaviour
{   
    [Header("menuManager")]
    public PerkSystem perkSystem;
    public ContractSystem contractSystem;
    public Canvas perkCanvas;
    public Canvas contractCanvas;
    public Canvas MainCanvas;

    public void PerkStart()
    {
        perkCanvas.enabled = true;
        MainCanvas.enabled = false;
    }

    public void ContractStart()
    {
        contractCanvas.enabled = true;
        MainCanvas.enabled = false;
    }
    
    public void Back()
    {
        contractCanvas.enabled = false;
        perkCanvas.enabled = false;
        MainCanvas.enabled = true;
    }

    public void Settings()
    {
        SceneManager.LoadScene("Mainmenu");
    }

}
