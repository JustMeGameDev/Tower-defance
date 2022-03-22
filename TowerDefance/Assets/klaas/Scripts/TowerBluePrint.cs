using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBluePrint : MonoBehaviour
{
    public GameObject barracks_blueprint;
    
    public PopUpZonderCheck Close;
    

    private void Awake()
    {
        Close = GameObject.FindWithTag("ShopMenu").GetComponent<PopUpZonderCheck>();
      
    }
    public void spawn_barracks_blueprint()
    {
       
        Instantiate(barracks_blueprint);
        Close.IsOpen = false;
        Close.canvas.enabled = false;
        Close.Placing = true;
    }
}
