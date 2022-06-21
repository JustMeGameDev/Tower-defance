using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))] //A collider is needed to receive clicks
public class ButtonObject : MonoBehaviour
{
    public bool shopactive;
    public UnityEvent interactEvent;
    private void OnMouseDown()
    {
        if(!shopactive)
        {
            interactEvent.Invoke();
        }
    }  
}

