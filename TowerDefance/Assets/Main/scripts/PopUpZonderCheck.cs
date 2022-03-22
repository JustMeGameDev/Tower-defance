using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class PopUpZonderCheck : MonoBehaviour
{
    public Canvas canvas;
    public bool IsOpen = false;
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
        if (!IsOpen)
        {
            canvas.enabled = false;
        }
    }
}
