using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMusic : MonoBehaviour
{
    public AudioClip[] soundtrack;

    void Update()
    {


        if (!GetComponent<AudioSource>().isPlaying)
        {
            GetComponent<AudioSource>().clip = soundtrack[Random.Range(0, soundtrack.Length)];
            GetComponent<AudioSource>().Play();
        }
    }

    // Here will be all the buttons to play individual songs according to their order in the Array

    public void Song01()
    {
        GetComponent<AudioSource>().clip = soundtrack[0];
        GetComponent<AudioSource>().Play();
        Debug.Log("Now playing: desert sirens");
    }
}
