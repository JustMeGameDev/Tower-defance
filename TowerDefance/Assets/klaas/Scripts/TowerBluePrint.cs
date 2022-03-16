using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBluePrint : MonoBehaviour
{
    public GameObject barracks_blueprint;
   // public int gold = 5;

  
    public void spawn_barracks_blueprint()
    {
       // if (gold >= 1) // Delete
      //  {
            Instantiate(barracks_blueprint);
        //    gold -= 1;
      //  }
    }
}
