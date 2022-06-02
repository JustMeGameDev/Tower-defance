using UnityEngine;
using TMPro;

public class GameSpeed : MonoBehaviour
{
    public GameObject prefab;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI dayText;
    public float timeFloat;
    public float timeStart;
    public float timeEnd;
    public bool night;
    public bool bloodNight;
    public int day = 1;
   
    public Material skyboxDay;
    public Material skyboxDawn;
    public Material skyboxSunset;
    public Material skyboxNight;
    public Material skyboxBlood;


    public void SetGameSpeed(float gameSpeed)
    {    
        Time.timeScale = gameSpeed;
    }
    public void Start()
    {
        timeFloat = timeStart;
    }
    public void Update()
    {
        dayText.text = "day, " + day + " ;";
        timeFloat = Mathf.Clamp(timeFloat, 0, 24.5f);
        timeFloat = timeFloat + 0.1f * Time.deltaTime;
        timeText.text = Mathf.Round(timeFloat) + ":00";       
        if (timeFloat > 24f)
        {
            timeFloat = 1;
            day++;
        }

        if (timeFloat >18f && timeFloat < 20f)
        {
            RenderSettings.skybox = skyboxSunset;
            night = false;

        }
        else if (timeFloat > 20f || timeFloat < 5f)
        {
            if (bloodNight)
            {
                RenderSettings.skybox = skyboxBlood;
                night = true;
            }
            else
            {
                RenderSettings.skybox = skyboxNight;
                night = true;
            }
        }
        
        else if (timeFloat > 5f && timeFloat < 7f)
        {
            RenderSettings.skybox = skyboxDawn;
            night = false;
        }
        else if (timeFloat > 7f && timeFloat < 18f)
        {
            RenderSettings.skybox = skyboxDay; 
            night = false;

        }


    }
}
