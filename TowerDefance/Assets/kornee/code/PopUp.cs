using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class PopUp : MonoBehaviour
{
    public Canvas canvas;
    public bool IsOpen = false;
    public GameMaster gameMaster;
    public ButtonObject buttonObject;
    private void Awake()
    {
        gameMaster = GameObject.FindWithTag("GameMaster").GetComponent<GameMaster>();
        buttonObject = gameObject.GetComponent<ButtonObject>();
    }
    public void open()
    {
        if (!IsOpen)
        {
            canvas.enabled = true;
            IsOpen = true;
        }
        else if (IsOpen)
        {
            canvas.enabled = false;
            IsOpen = false;
        }
    }
    private void FixedUpdate()
    {
        if (buttonObject.shopactive == true)
        {
            canvas.enabled = false;
        }
        if (!IsOpen)
        {
            canvas.enabled = false;
        }
    }
    public bool GetIsOpen()
    {
        return IsOpen;
    }
    public void close()
    {
        
            canvas.enabled = false;
            IsOpen = false;
        
    }
   
}
