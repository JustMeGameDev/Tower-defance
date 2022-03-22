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

    private void Start()
    {
        
    }
    public void open()
    {
        
        if (!IsOpen && !Placing)
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
}
