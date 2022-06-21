using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class PopUpZonderCheck : MonoBehaviour
{
    public Canvas canvas;
    public bool IsOpen = false;
    public TowerPlace towerPlace;
    public bool Placing;
    public ButtonObject buttonObject;
    public bool shop;
    public GameMaster gameMaster;

    private void Start()
    {
        gameMaster = GameObject.FindWithTag("GameMaster").GetComponent<GameMaster>();
        

    }
    public void open()
    {
        
        if (!IsOpen && !Placing)
        {
            canvas.enabled = true;
            IsOpen = true;
            foreach (var a in gameMaster.Towers)
            {
                a.gameObject.GetComponent<ButtonObject>().shopactive = true;
            }
        }
        else if (IsOpen)
        {
            canvas.enabled = false;
            IsOpen = false;
            foreach (var a in gameMaster.Towers)
            {
                a.gameObject.GetComponent<ButtonObject>().shopactive = false;
            }
        }
    }
}
