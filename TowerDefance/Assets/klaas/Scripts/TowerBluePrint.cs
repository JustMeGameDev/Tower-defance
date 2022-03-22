using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBluePrint : MonoBehaviour
{
    public GameObject barracks_blueprint;
    public GameObject ShopMenu;
    public PopUpZonderCheck Close;

    private void Start()
    {
        Close = ShopMenu.gameObject.GetComponent<PopUpZonderCheck>();
    }
    public void spawn_barracks_blueprint()
    {
       
            Instantiate(barracks_blueprint);
            Close.IsOpen = false;
            
      
    }
}
