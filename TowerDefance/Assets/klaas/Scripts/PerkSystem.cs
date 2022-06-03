using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PerkSystem : MonoBehaviour
{
    [Header("UI")]
   [SerializeField] Image[] upgradeImages;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public string upgradeString;
    public int maxUpgrade;
   public  int upgrade;
    public GameMaster gameMaster;
    public float money = 100;
    public float cost;
  // [Header("Cost")]
  // public float cost;
  // [Header("PlayerPrefs")]
    public float health = 100;

    private void Awake()
    {
        upgrade = PlayerPrefs.GetInt("maxHealthUpgrade");
    }
    private void Start()
    {
        for (int i = 0; i < upgradeImages.Length; i++)
        {
            if (i < upgrade)
            {
                upgradeImages[i].sprite = fullHeart;
            }

        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
          PlayerPrefs.DeleteKey("maxHealthUpgrade");
                }
    }
    public void UpgradePerk()
    {
       // PlayerPrefs.GetInt("maxHealthUpgrade");
        PlayerPrefs.SetFloat("Health", health);
        if (money >= cost && upgrade < maxUpgrade)//
        {
            PlayerPrefs.SetInt("maxHealthUpgrade", upgrade);
            upgrade += 1;
            switch (upgrade)
            {
                case 1:
                    Debug.Log("Upgrade" + upgrade);

                    upgradeImages[0].sprite = fullHeart;
                    return;
                case 2:
                    Debug.Log("Upgrade" + upgrade);

                    upgradeImages[1].sprite = fullHeart;
                    return;
                case 3:
                    Debug.Log("Upgrade" + upgrade);

                    upgradeImages[2].sprite = fullHeart;
                    return;
                case 4:
                    Debug.Log("Upgrade" + upgrade);
                    upgradeImages[3].sprite = fullHeart;
                    return;
                case 5:
                    Debug.Log("Upgrade" + upgrade);
                    upgradeImages[4].sprite = fullHeart;
                    return;
                case 6:
                    Debug.Log("Upgrade" + upgrade);
                    PlayerPrefs.SetInt("maxHealthUpgrade", upgrade);
                    upgradeImages[5].sprite = fullHeart;
                    return;
                default:
                    Debug.Log("No Upgrades");
                    return;
            }

           

            //} else
            // {
            //     PlayerPrefs.SetInt("maxHealthUpgrade", upgrade);
            //     Debug.Log("Upgrade Limit");
            // }
        }
    }
}
