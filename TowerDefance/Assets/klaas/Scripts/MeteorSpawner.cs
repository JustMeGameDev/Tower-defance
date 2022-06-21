using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameMaster gameMaster;
    public GameObject MetoerMark;
    public Button button;
    public int unlocked = 0;
    public float cost;
   public float countDown;
    private void Awake()
    {
        unlocked = PlayerPrefs.GetInt("meteorUnlocked");
    }

    private void Start()
    {
        if (unlocked == 1)
        {
            button.interactable = true;
        }
        else
        {
            button.interactable = false;
        }
    }
    private void Update()
    {
        countDown -= Time.deltaTime;
    }

    public void Spawn()
    {
        if (gameMaster.money >= cost && unlocked == 1 && countDown <= 0)
        {
            Instantiate(MetoerMark, transform.position, transform.rotation);
            countDown = 10;
            gameMaster.money -= cost;
        }
    }    

}
