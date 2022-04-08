using UnityEngine;

public class GameSpeed : MonoBehaviour
{
    public GameObject prefab;

  public void SetGameSpeed(float gameSpeed)
    {    
        Time.timeScale = gameSpeed;
    }
}
