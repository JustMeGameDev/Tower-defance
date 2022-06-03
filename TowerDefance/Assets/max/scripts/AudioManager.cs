using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

 
public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public string scene;
    public AudioSource[] musics;
    public bool themeIsPlaying;

    public static AudioManager instance;

    void Awake()
    {

        if (instance == null)       
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        
        DontDestroyOnLoad(gameObject);

        foreach(Sound s in sounds)
        {
           s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.outputAudioMixerGroup = s.mixer;         
            s.source.volume = s.volume;
            // s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    void Start()
    {
        // if(SceneManager.GetActiveScene().name == "MainMenu"){ Play("Theme"); }
        Play("MainTheme");

    }
    
   
    public void Play(string name)
    {
       Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;
     
        s.source.Play();
    }

    public void Mute(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;

        s.source.Pause();
        s.source.Stop();
    }
}
