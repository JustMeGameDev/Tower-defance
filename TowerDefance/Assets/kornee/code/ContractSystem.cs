using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ContractSystem : MonoBehaviour
{

    public Contract[] Contracts;
    public string[] names = new string[] {"mark","jan","maurice","Bernadethe","amber","boris","djanga"};
    public string[] titles = new string[] {"HELP!! my farm is dying.","ill compansate royaly.","i dont have much but need help.","ola help porfavor.","i have money.","i cant stand these goblins.","oh nooo.","how are you?","Please help im under the water"};
    public Sprite[] images;
    public List<string> namesFinal;
    public List<string> titlesFinal;
    public List<Sprite> imagesFinal;

    private void Awake()
    {
        namesFinal = names.ToList();
        titlesFinal = titles.ToList();
        imagesFinal = images.ToList();
        for (int i = 0;i < Contracts.Length;i++)
        {
            int nameInt = Random.Range(0,namesFinal.Count);
            int titleInt = Random.Range(0, titlesFinal.Count);
            int imageInt = Random.Range(0, imagesFinal.Count);
            Contracts[i].ContractAssemble(titlesFinal[titleInt],namesFinal[nameInt],imagesFinal[imageInt]);
            titlesFinal.RemoveAt(titleInt);
            namesFinal.RemoveAt(nameInt);
            imagesFinal.RemoveAt(imageInt);
        }
    }
}
