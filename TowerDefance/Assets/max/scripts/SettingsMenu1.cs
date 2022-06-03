using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu1 : MonoBehaviour
{

    public AudioMixer audioMixer;

    Resolution[] resolutions;

    void start ()
    {
       resolutions = Screen.resolutions;
    }

    public void SetVolume (float volume)

    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void setFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }


}
