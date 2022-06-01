using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PerkSystem : MonoBehaviour
{
    [Header("UI")]
   [SerializeField] Image[] heartImages;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public int maxUpgrade =3;
    int upgrade = 0;
    public GameMaster gameMaster;
    public float money = 100;
  // [Header("Cost")]
   // public float cost;
   // [Header("PlayerPrefs")]
    float health = 100;
     
    public void UpgradePerk(float cost)
    {
        PlayerPrefs.SetFloat("Health", gameMaster.PlayerMaxHealth);
        for (int i = 0; i < heartImages.Length; i++)
        {

            if (i > upgrade)
            {
                heartImages[i].sprite = emptyHeart;

            }
            else
            {
                heartImages[i].sprite = fullHeart;
            }


        }
        if (money >= cost && upgrade <= maxUpgrade)
       {

           upgrade += 1;
            // Debug.Log();
           health = PlayerPrefs.GetFloat("Health");
            health += 100;
            Debug.Log(PlayerPrefs.GetFloat("Health"));
       } else
        {
            Debug.Log("Upgrade Limit");
        }
    }
}
