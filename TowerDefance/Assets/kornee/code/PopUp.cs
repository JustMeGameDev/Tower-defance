using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class PopUp : MonoBehaviour
{
    public Canvas canvas;
    private bool IsOpen = false;
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
   
}
