using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopMaster : MonoBehaviour
{
    public GameObject Mage_blueprint;
    public GameObject Morter_blueprint;
    public GameObject Cannon_blueprint;
    public float priceMage = 45f;
    public float priceMorter = 65f;
    public float priceCannon = 25f;
    public TextMeshProUGUI CannonPrice;
    public TextMeshProUGUI MorterPrice;
    public TextMeshProUGUI MagePrice;
    public PopUpZonderCheck Close;
    public GameMaster gameMaster;
    public TextMeshProUGUI Message;

    private void Awake()
    {
        Close = GameObject.FindWithTag("ShopMenu").GetComponent<PopUpZonderCheck>();
        gameMaster = GameObject.FindWithTag("GameMaster").GetComponent<GameMaster>();
        CannonPrice.text = "$ " + priceCannon;
        MorterPrice.text = "$ " + MorterPrice;
        MagePrice.text = "$ " + priceMage;


    }
    public void spawn_Cannon_blueprint()
    {
        if (gameMaster.money >= priceCannon)
        {
            Instantiate(Cannon_blueprint);
            Close.IsOpen = false;
            Close.canvas.enabled = false;
            Close.Placing = true;
            gameMaster.money -= priceCannon;
        }
        else
        {
            Message.text = "Not Enough Funds";
        }
    }
    public void spawn_Mage_blueprint()
    {
        if (gameMaster.money >= priceMage)
        {
            Instantiate(Mage_blueprint);
            Close.IsOpen = false;
            Close.canvas.enabled = false;
            Close.Placing = true;
            gameMaster.money -= priceMage;
            
        }
        else
        {
            Message.text = "Not Enough Funds";
        }
    }
    public void spawn_Morter_blueprint()
    {
        if (gameMaster.money >= priceMorter)
        {
            Instantiate(Morter_blueprint);
            Close.IsOpen = false;
            Close.canvas.enabled = false;
            Close.Placing = true;
            gameMaster.money -= priceMorter;

        }
        else
        {
            Message.text = "Not Enough Funds";
        }
    }


}


