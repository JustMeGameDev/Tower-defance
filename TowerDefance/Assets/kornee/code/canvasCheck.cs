using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canvasCheck : MonoBehaviour
{
    public List<PopUp> Towers;
    public PopUp OpenTower;
    public void Start()
    {
        Towers= new List<PopUp>();
    }
    public void FixedUpdate()
    {
        foreach (PopUp i in Towers)
        {
            if (OpenTower == null)
            {
                OpenTower = i;
            }
            if (i.GetIsOpen() == true && OpenTower != i)
            {
                OpenTower.IsOpen = false;
                OpenTower = i;
            }
        }
        
    }

}
