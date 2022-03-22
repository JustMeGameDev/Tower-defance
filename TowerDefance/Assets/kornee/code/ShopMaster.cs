using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopMaster : MonoBehaviour
{
    public GameObject Cannon_blueprint;
    public float priceCannon = 25f;
    public PopUpZonderCheck Close;
    public GameMaster gameMaster;
    public TextMeshProUGUI Message;
    public GameObject Mage_blueprint;
    public float priceMage = 45f;

    private void Awake()
    {
        Close = GameObject.FindWithTag("ShopMenu").GetComponent<PopUpZonderCheck>();
        gameMaster = GameObject.FindWithTag("GameMaster").GetComponent<GameMaster>();

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
        if (gameMaster.money >= priceCannon)
        {
            Instantiate(Mage_blueprint);
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

}


